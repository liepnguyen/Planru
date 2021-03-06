﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Configuration.Elements
{
    public class ModuleElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name 
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
    }
}
