using System;
using System.Linq;
using AutoMapper;
using Planru.Crosscutting.Adapter;

namespace Planru.Crosscutting.Adapter.Automapper
{
    public class AutomapperTypeAdapterFactory
        : ITypeAdapterFactory
    {
        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }
    }
}
