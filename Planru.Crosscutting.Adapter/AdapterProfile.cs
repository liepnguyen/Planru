using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Adapter
{
    public class AdapterProfile
    {
        public IList<Mapping> Mappings { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdapterProfile()
        {
            Mappings = new List<Mapping>();
            Configure();
        }

        public virtual void Configure() { }

        /// <summary>
        /// Create a mapping from source type to target type
        /// </summary>
        /// <typeparam name="TSource">Type of source</typeparam>
        /// <typeparam name="TTarget">Type of target</typeparam>
        public void CreateMap<TSource, TTarget>()
        {
            Mappings.Add(new Mapping(typeof(TSource), typeof(TTarget)));
        }

        /// <summary>
        /// Scans all assemblies finding Adapter Profile
        /// </summary>
        /// <returns>The List of profiles</returns>
        public static IEnumerable<AdapterProfile> FindAllProfiles()
        {
            var profileTypes = AppDomain.CurrentDomain
                                    .GetAssemblies()
                                    .SelectMany(a => a.GetTypes())
                                    .Where(t => t.BaseType == typeof(AdapterProfile));

            foreach (var profileType in profileTypes)
            {
                AdapterProfile profile = (AdapterProfile)Activator.CreateInstance(profileType);
                yield return profile;
            }
        }

        /// <summary>
        /// Finds all mappings that configured in Adapter Profile
        /// </summary>
        /// <returns>The list of mappings</returns>
        public static IEnumerable<Mapping> GetAllMappings()
        {
            var profiles = FindAllProfiles();
            foreach (var profile in profiles)
            {
                foreach (var mapping in profile.Mappings)
                {
                    yield return mapping;
                }
            }
        }

    }
}
