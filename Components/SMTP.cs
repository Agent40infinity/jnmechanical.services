using System.Net.Http.Headers;

namespace jnmechanical.services.Components
{
    public class SMTP
    {
        public static async Task PostInquiry(HttpClient client)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.smtp2go.com/v3/email/send"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "X-Smtp2go-Api-Key", "" },
                },
                Content = new StringContent("{\"to\":[\"Jamie Nathan <admin@jnmechanical.services>\"],\"cc\":[\"Aiden Nathan <me@aiden.fyi>\"],\"sender\":\"Jamie Nathan <admin@jnmechanical.services>\",\"subject\":\"JN Mechanical Inquiry - Subject Name\",\"text_body\":\"dfsdsfsdf\"}")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}