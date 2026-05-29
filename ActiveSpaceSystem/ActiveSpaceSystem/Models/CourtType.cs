using System.Collections.Generic;

namespace ActiveSpace.Models
{
    public class CourtType
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }

        private static List<CourtType> _types = new List<CourtType>
        {
            new CourtType { TypeID = 1, TypeName = "كرة قدم" },
            new CourtType { TypeID = 2, TypeName = "بادل" },
            new CourtType { TypeID = 3, TypeName = "كرة سلة" }
        };

        public static List<CourtType> GetFakeData()
        {
            return _types;
        }

        public static void Add(CourtType type)
        {
            _types.Add(type);
        }
    }
}