using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRestAPI
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string email { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string avatar_url { get; set; }
    }
}
