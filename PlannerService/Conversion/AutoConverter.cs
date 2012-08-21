using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlannerService.DataLayer.TableEntityType;

namespace PlannerService.Conversion
{
    public class AutoConverter
    {
        public static IConverter<TsT, PlT, PaT> Create<TsT, PlT, PaT>()
            where TsT : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
            where PlT : Models.IEventObject<PaT>
            where PaT : Models.IdentifiableObject
        {
            var mapper = AutoMapper.Mapper.CreateMap<TsT, PlT>();

            return new AutoMapperConverter<TsT, PlT, PaT>
            (
             ts => AutoMapper.Mapper.Map<TsT, PlT>(ts),
             pl => AutoMapper.Mapper.Map<PlT, TsT>(pl)
            );
        }

        private class AutoMapperConverter<TsT, PlT, PaT>
            : IConverter<TsT, PlT, PaT>
            where TsT : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
            where PlT : Models.IEventObject<PaT>
            where PaT : Models.IdentifiableObject
        {
            public AutoMapperConverter(Func<TsT, PlT> t2p, Func<PlT, TsT> p2t)
            {
                this.t2p = t2p;
                this.p2t = p2t;
            }

            public PlT Convert(TsT source)
            {
                return t2p(source);
            }

            public TsT Convert(PlT source)
            {
                return p2t(source);
            }

            private Func<TsT, PlT> t2p;

            private Func<PlT, TsT> p2t;
        }
    }
}