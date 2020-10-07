using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRestAPI.Appointments.DTOS
{
    public class AppointmentDTO
    {
        public string token { get; set; }

        public string provider_id { get; set; }
        public DateTime date { get; set; }
    }
}
