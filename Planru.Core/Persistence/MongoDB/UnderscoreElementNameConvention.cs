using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Planru.Core.Persistence.MongoDB
{
    public class UnderscoreElementNameConvention : IMemberMapConvention
    {
        public void Apply(BsonMemberMap memberMap)
        {
            memberMap.SetElementName(Regex.Replace(
                memberMap.MemberName, @"([A-Z])", "_$1").TrimStart('_').ToLower());
        }

        public string Name
        {
            get { return "Undersore Element Name"; }
        }
    }
}
