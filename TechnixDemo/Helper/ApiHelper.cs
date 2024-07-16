using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TechnixModel;

namespace TechnixDemo.Helper
{
    public class ApiHelper
    {

        public async Task<List<string>> GetClientDt()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5164/Entity");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var ress = new List<string>();
                // Perform the GET request
                var responseMessage = await client.GetAsync(string.Empty); // No need to use the full URI since BaseAddress is set

                if (responseMessage.IsSuccessStatusCode)
                {
                    // Deserialize the response content
                    ress = await responseMessage.Content.ReadAsAsync<List<string>>();
                    // You can use the 'ress' list here as needed
                }
                else
                {
                    // Handle the error response
                    // You might want to log the error or throw an exception
                    Console.WriteLine("Error: " + responseMessage.StatusCode);
                }

                return ress;
            }
        }
        public async Task<bool> PostClientDt(GenerateModel dataToSend)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5164/Generate");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                // Serialize the data to send to JSON
                var jsonContent = JsonConvert.SerializeObject(dataToSend);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");


                try
                {
                    // Perform the POST request
                    var responseMessage = await client.PostAsync(string.Empty, content);

                    // Check if the response is successful
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        // Optionally log the response status code or reason phrase
                        Console.WriteLine($"Error: {responseMessage.StatusCode} - {responseMessage.ReasonPhrase}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during the HTTP request
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                    return false;
                }
            }
        }
        }
}
