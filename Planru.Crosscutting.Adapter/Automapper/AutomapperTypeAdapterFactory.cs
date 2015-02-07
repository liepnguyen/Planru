using System;
using System.Linq;
using AutoMapper;
using Planru.Crosscutting.Adapter;

namespace Planru.Crosscutting.Adapter.Automapper
{
    public class AutomapperTypeAdapterFactory
        : ITypeAdapterFactory
    {
        #region Constructor

        /// <summary>
        /// Create a new Automapper type adapter factory
        /// </summary>
        //public AutomapperTypeAdapterFactory()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        foreach (var mapping in AdapterProfile.GetAllMappings())
        //        {
        //            cfg.CreateMap(mapping.TSource, mapping.TTarget);
        //        }
        //    });
        //}
        
        #endregion

        #region ITypeAdapterFactory Members

        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion
    }
}
