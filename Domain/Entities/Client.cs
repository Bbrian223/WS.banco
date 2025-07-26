using System.Reflection;

namespace Domain.Entities
{
    public class Client
    {
        public long id { get; set; }
        public string name { get; set; }
        public string pass { get; set; }
        public string type { get; set; }
        public bool status { get; set; }

    }
}
