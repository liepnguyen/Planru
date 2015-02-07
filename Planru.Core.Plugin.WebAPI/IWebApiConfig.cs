using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Plugin.WebAPI
{
    public interface IWebApiConfig
    {
        void RegisterTypes(IContainer container);
        void CreateMappings(ITypeAdapter typeAdapter);
    }
}
