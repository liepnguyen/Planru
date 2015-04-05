using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Domain
{
    /// <summary>
    /// Entity base class (Handles equality and identity).
    /// </summary>
    /// <typeparam name="TID">Type of Id</typeparam>
    public abstract class Entity<TID>
    {
        /// <summary>
        /// Entity base class (Handles equality and identity).
        /// </summary>
        public virtual TID Id { get; protected set; }

        /// <summary>
        /// Indicates whether the current object 
        /// is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal 
        /// to the <paramref name="other"/> parameter; 
        /// otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Entity<TID> other)
        {
            if (other == null)
                return false;

            // Handle the case of comparing two NEW objects    
            var otherIsTransient = Equals(other.Id, default(TID));
            var currentIsTransient = Equals(this.Id, default(TID));

            if (otherIsTransient && currentIsTransient)
                return ReferenceEquals(other, this);

            return other.Id.Equals(this.Id);
        }

        /// <summary>
        /// Equality
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = obj as Entity<TID>;

            return Equals(other);
        }

        /// <summary>
        /// Get hash code
        /// </summary>
        public override int GetHashCode()
        {
            var thisIsTransient = Equals(this.Id, default(TID));

            // When this instance is transient, we use the base GetHashCode()    
            return thisIsTransient ? base.GetHashCode() : this.Id.GetHashCode();
        }

        /// <summary>
        /// Equal operator
        /// </summary>
        public static bool operator ==
            (Entity<TID> x, Entity<TID> y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        public static bool operator !=
            (Entity<TID> x, Entity<TID> y)
        {
            return !(x == y);
        }
    }
}
