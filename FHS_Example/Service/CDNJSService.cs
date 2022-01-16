using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net;

namespace FHS_Example.Service
{
    public class CDNJSService : ICDNJSService
    {
        private string _baseUrl;
        public CDNJSService(string baseUrl)
        {
            _baseUrl = baseUrl;

        }

        public async Task<List<LibraryDTO>> GetLibraries(int limit)
        {
            string apiUrl = $"{_baseUrl}/libraries?limit={limit}";
            try
            {
                // Create a request for the URL.
                WebRequest request = WebRequest.Create(apiUrl);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.
                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Console.WriteLine(responseFromServer);

                    Result result = JsonConvert.DeserializeObject<Result>(responseFromServer);

                    return result?.results;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
