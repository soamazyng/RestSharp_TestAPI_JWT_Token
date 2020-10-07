using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRestAPI.Appointments.Entities
{
    public class Appointment
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string provider_id { get; set; }
        public DateTime date { get; set; }        
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
