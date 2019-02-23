using System.Net.Http;
using System.Threading.Tasks;

namespace WtbTestApp.RestProvider
{
    public class ServerResponse
    {
        public int Status { get; private set; }
        public string Content { get; private set; }
        public bool IsSuccess { get; private set; }

        private ServerResponse()
        {
            
        }

        public static async Task<ServerResponse> FromHttpResponseAsync(HttpResponseMessage message)
        {
            if (message.IsSuccessStatusCode == false)
            {
                return new ServerResponse
                {
                    Status = (int) message.StatusCode,
                    IsSuccess = message.IsSuccessStatusCode
                };
            }

            var content = await message.Content.ReadAsStringAsync();

            return new ServerResponse
            {
                Status = (int)message.StatusCode,
                IsSuccess = message.IsSuccessStatusCode,
                Content = content
            };
        }
    }
}