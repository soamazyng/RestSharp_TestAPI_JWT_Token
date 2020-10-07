using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;
using System.Threading.Tasks;
using TestRestAPI.Users.DTOS;
using TestRestAPI.Users.Entities;

namespace TestRestAPI.Users.Services
{
    public static class AuthenticateUserService
    {
        public static Authenticate Execute(AuthenticateUserDTO authenticateUserDTO)
        {
            string clientURL = ConfigurationManager.AppSettings["clientURL"];

            IRestClient restClient = new RestClient(clientURL);

            var requestLogin = new RestRequest("/sessions", Method.POST);
            requestLogin.RequestFormat = DataFormat.Json;
            requestLogin.AddBody(new { email = authenticateUserDTO.Login, password = authenticateUserDTO.Password });

            IRestResponse responseRequest = restClient.Post(requestLogin);

            if (string.IsNullOrEmpty(responseRequest.Content))
                throw new Exception("error login API");

            var authenticate = JsonConvert.DeserializeObject<Authenticate>(responseRequest.Content);

            if (string.IsNullOrEmpty(authenticate.token))
                throw new Exception("Token does not created");

            return authenticate;
        }
    }
}
