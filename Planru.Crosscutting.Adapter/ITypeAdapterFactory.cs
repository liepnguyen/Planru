using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planru.Crosscutting.Adapter
{
    /// <summary>
    /// Base contract for adapter factory
    /// </summary>
    public interface  ITypeAdapterFactory
    {
        /// <summary>
        /// Create a type adapter
        /// </summary>
        /// <returns>The created ITypeAdapter</returns>
        ITypeAdapter Create();
    }
}
