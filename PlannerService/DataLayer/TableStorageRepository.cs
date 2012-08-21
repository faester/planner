namespace PlannerService.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.WindowsAzure.StorageClient;
    using Microsoft.WindowsAzure.StorageClient.Protocol;
    using Microsoft.WindowsAzure;
    using PlannerService.DataLayer;
    using PlannerService.Models;
    using PlannerService.Conversion;
    using System.Data;

    public class TableStorageRepositoryBase<TableServiceEntityType, EventDomainType, ParentType>
        : IRepository<EventDomainType, ParentType>
        where EventDomainType : IEventObject<ParentType>
        where ParentType : IdentifiableObject
        where TableServiceEntityType : TableServiceEntity
    {
        public string TableAddress { get; set; }

        CloudStorageAccount StorageAccount { get; set; }

        /// <summary>
        /// Initializes a new instance of the TableStorageRepositoryBase class.
        /// </summary>
        public TableStorageRepositoryBase(
                    Converter<EventDomainType, TableServiceEntityType> eventToCloudTypeConverter,
                    Converter<TableServiceEntityType, EventDomainType> cloudTypeToEventConverter)
        {
            if (cloudTypeToEventConverter == null)
            {
                throw new ArgumentNullException("cloudTypeToEventConverter");
            }
            if (eventToCloudTypeConverter == null)
            {
                throw new ArgumentNullException("eventToCloudTypeConverter");
            }

            this.eventToCloudTypeConverter = eventToCloudTypeConverter;
            this.cloudTypeToEventConverter = cloudTypeToEventConverter;
        }

        public TableStorageRepositoryBase(IConverter<EventDomainType, TableServiceEntityType> converter, CloudStorageAccount storageAccount)
        {
            if (converter == null)
            {
                throw new ArgumentNullException("converter");
            }

            if (storageAccount == null)
            {
                throw new ArgumentNullException("storageAccount");
            }
            this.StorageAccount = storageAccount;
            this.converter = converter;
            this.eventToCloudTypeConverter = converter.Convert;
            this.cloudTypeToEventConverter = converter.Convert;
        }

        private Converter<EventDomainType, TableServiceEntityType> eventToCloudTypeConverter;
        private Converter<TableServiceEntityType, EventDomainType> cloudTypeToEventConverter;
        private IConverter<EventDomainType, TableServiceEntityType> converter;

        private ILogger Logger { get; set; }

        public string TABLE_NAME
        {
            get
            {
                return typeof(EventDomainType).Name;
            }
        }

        public void Init()
        {
            //Logger = WebRole.GetLogger(GetType());

            Logger.Debug("Creating table client");
            var client = CreateTableClient();
            if (client.DoesTableExist(TABLE_NAME))
            {
                Logger.Debug("Table already existed: " + TABLE_NAME);
                return;
            }

            Logger.Info("Creating table: " + TABLE_NAME);
            var createTableCallback = client.BeginCreateTable(TABLE_NAME, WaitForTableCreation, null);

            createTableCallback.AsyncWaitHandle.WaitOne();
            Logger.Info("Table created: " + TABLE_NAME);
        }

        private void WaitForTableCreation(object a)
        {
            Logger.Info("Creating table: " + TABLE_NAME);
        }

        public IEnumerable<EventDomainType> GetAll(string parentID)
        {
            var query = GetQueryable();

            var items = query.Where(x => x.PartitionKey == parentID.ToString());

            return from s in items
                   select cloudTypeToEventConverter(s);
        }

        public EventDomainType Get(string identifier, string parentIdentifier)
        {
            var item = GetInternal(identifier, parentIdentifier);

            if (item == null)
            {
                throw new ObjectNotFoundException("Could not find object of type: with identifier: " + identifier);
            }

            return cloudTypeToEventConverter(item);
        }

        private TableServiceEntityType GetInternal(string identifier, string parentIdentifier)
        {
            var query = GetQueryable();

            var item = query.Where(x => x.RowKey == identifier.ToString() && x.PartitionKey == parentIdentifier.ToString()).FirstOrDefault();

            return item;
        }


        private IEnumerable<TableServiceEntityType> GetQueryable()
        {
            var context = CreateContextInstance();

            var query = context.CreateQuery<TableServiceEntityType>(TABLE_NAME).AsTableServiceQuery<TableServiceEntityType>();

            return query.ToArray();
        }

        public void Delete(string id, string parentId)
        {
            TableServiceContext context = CreateContextInstance();

            var query = context.CreateQuery<TableServiceEntityType>(TABLE_NAME);

            context.DeleteObject(query.Where(
                x => x.RowKey == id 
                && x.PartitionKey == parentId).First()
                );

            context.SaveChanges();
        }

        private TableServiceContext CreateContextInstance()
        {
            return new TableServiceContext(StorageAccount.TableEndpoint.ToString(), StorageAccount.Credentials);
        }

        public void Add(EventDomainType item)
        {
            var context = CreateContextInstance();

            var cloudStorageEntity = eventToCloudTypeConverter(item);

            var existingItem = GetInternal(item.Identifier, item.Parent.Identifier);

            if (existingItem != null)
            {
                throw new PlannerService.Exceptions.DublicateObjectIdentifierException(existingItem.RowKey, existingItem.PartitionKey);
            }

            context.AddObject(TABLE_NAME, cloudStorageEntity);

            context.SaveChanges();
        }

        public void Update(EventDomainType item)
        {
            var context = CreateContextInstance();

            var query = context.CreateQuery<TableServiceEntityType>(TABLE_NAME);

            var tableItem = Convert(item);

            var existing = query.Where(x => x.RowKey == tableItem.RowKey && x.PartitionKey == tableItem.PartitionKey).First();

            context.DeleteObject(existing);

            context.AddObject(TABLE_NAME, tableItem);

            context.SaveChanges();
        }

        private TableServiceEntityType Convert(EventDomainType item)
        {
            return eventToCloudTypeConverter(item);
        }

        private EventDomainType Convert(TableServiceEntityType item)
        {
            return cloudTypeToEventConverter(item);
        }

        private CloudTableClient CreateTableClient()
        {
            return new CloudTableClient(StorageAccount.TableEndpoint.ToString(), StorageAccount.Credentials);
        }
    }
}