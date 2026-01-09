using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

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
                    { "accept", "application/json" },
                    /*{ "full_name_value", form.firstName + " " + form.lastName },
                    { "email_address_value", form.email },
                    { "phone_number_value", form.phone },
                    { "rego_value", form.rego },
                    { "state_value", form.state },
                    { "subject_value", form.subject },
                    { "inquiry_value", form.inquiry }*/
                },
                Content = JsonContent.Create(new
                {
                    full_name_value = form.firstName + " " + form.lastName,
                    email_address_value = form.email,
                    phone_number_value = form.phone,
                    rego_value = form.rego,
                    state_value = form.state,
                    subject_value = form.subject,
                    inquiry_value = form.inquiry
                })
            };x

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }   
}