using System;
using System.Text.Json;
using RestSharp;


namespace ApplicationMonolegal.SendEmail
{
    public class SendEmail_BL
    {

        public static void SendEmail(string Fullname, string State, string Email) {
            //mailtrap@monoprueba.com
            var to = new { email = Email };
            var from = new { email = "mailtrap@monoprueba.com", name = "Mailtrap Test" };
            var args = new
            {
                from,
                to = new[] { to },
                subject = Fullname,
                text = State,
                category = "Aviso"
            };

            var client = new RestClient("https://send.api.mailtrap.io/api");
            var request = new RestRequest("/send", RestSharp.Method.Post);

            request.AddHeader("Authorization", "Bearer fc9bdb8e61f45dc75aef5cd2174fae45");
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", JsonSerializer.Serialize(args), ParameterType.RequestBody);

            RestSharp.RestResponse response = client.Execute(request);

        }

    }

    internal class RestResponse
    {
    }
}
