using System;
using System.Linq;
using AutoMapper;
using Planru.Crosscutting.Adapter;

namespace Planru.Crosscutting.NetFramework.Adapter
{
    public class AutomapperTypeAdapterFactory
        :ITypeAdapterFactory
    {
        #region Constructor

        /// <summary>
        /// Create a new Automapper type adapter factory
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {
            //scan all assemblies finding Automapper Profile
            var profiles = AppDomain.CurrentDomain
                                    .GetAssemblies()
                                    .SelectMany(a => a.GetTypes())
                                    .Where(t => t.BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                } 
            });
        }

        #endregion

        #region ITypeAdapterFactory Members

        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion
    }
}
