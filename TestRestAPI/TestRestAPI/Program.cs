using System;
using System.Configuration;

namespace TestRestAPI
{
    class Program
    {       
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {

                    var login = "";
                    var password = "";
                    var dateAppointment = "";

                    Console.WriteLine("----- Início do sistema -----");

                    Console.WriteLine("Digite seu login da API e tecle ENTER");
                    login = Console.ReadLine();

                    Console.WriteLine("Digite sua senha da API e tecle ENTER");
                    password = Password.ReadPassword();
                    
                    var loginDTO = new Users.DTOS.AuthenticateUserDTO
                    {
                        Login = login,
                        Password = password
                    };

                    var authenticateUsersService = Users.Services.AuthenticateUserService.Execute(loginDTO);

                    Console.WriteLine("----- Token criado com sucesso -----");

                    Console.WriteLine(authenticateUsersService.token);

                    Console.WriteLine("\n Digite a data para criar o agendamento");

                    dateAppointment = Console.ReadLine();                    
                    
                    Console.WriteLine("Digite a hora para criar o agendamento");
                    dateAppointment += " " + Console.ReadLine();

                    DateTime dateConvert = DateTime.Parse(dateAppointment);

                    Console.WriteLine("----- Fazendo uma chamada da API para salvar no banco de dados -----");

                    string providerId = ConfigurationManager.AppSettings["providerId"];

                    var appointmentDTO = new Appointments.DTOS.AppointmentDTO { date = dateConvert, provider_id = providerId, token = authenticateUsersService.token };

                    var appointmentService = Appointments.Services.CreateAppointmentsService.Execute(appointmentDTO);

                    Console.WriteLine("Appointment created: " + appointmentService.id);

                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

    }
}
