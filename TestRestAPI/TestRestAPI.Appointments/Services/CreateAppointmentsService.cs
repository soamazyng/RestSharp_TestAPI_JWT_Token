using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRestAPI.Appointments.DTOS;
using TestRestAPI.Appointments.Entities;

namespace TestRestAPI.Appointments.Services
{
    public static class CreateAppointmentsService
    {
        public static Appointment Execute(AppointmentDTO appointmentDTO) 
        {
            string clientURL = ConfigurationManager.AppSettings["clientURL"];

            IRestClient restClient = new RestClient(clientURL);
            restClient.Authenticator = new JwtAuthenticator(appointmentDTO.token);

            var requestLogin = new RestRequest("/appointments", Method.POST);
            requestLogin.RequestFormat = DataFormat.Json;
            requestLogin.AddBody(new { date = appointmentDTO.date, provider_id = appointmentDTO.provider_id });            
            
            IRestResponse responseRequest = restClient.Post(requestLogin);

            if (string.IsNullOrEmpty(responseRequest.Content))
                throw new Exception("error login API");

            var appointment = JsonConvert.DeserializeObject<Appointment>(responseRequest.Content);

            if (string.IsNullOrEmpty(appointment.id))
                throw new Exception("Appointment does not created");

            return appointment;
        }
    }
}
