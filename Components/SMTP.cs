using System.Net.Http.Headers;

namespace jnmechanical.services.Components
{
    public class SMTP
    {
        public static async Task PostInquiry(HttpClient client, InquiryForm form)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://inquiry.jnmechanical.services/"),
                Headers =
                {
                    { "full_name_value", form.firstName + " " + form.lastName },
                    { "email_address_value", form.email },
                    { "phone_number_value", form.phone },
                    { "rego_value", form.rego },
                    { "state_value", form.state },
                    { "subject_value", form.subject },
                    { "inquiry_value", form.inquiry }
                },
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