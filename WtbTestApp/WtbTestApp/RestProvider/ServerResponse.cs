using System.Net.Http;
using System.Text;
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

            var byteArray = await message.Content.ReadAsByteArrayAsync();
            var content = Encoding.GetEncoding("windows-1251").GetString(byteArray, 0, byteArray.Length);

            return new ServerResponse
            {
                Status = (int)message.StatusCode,
                IsSuccess = message.IsSuccessStatusCode,
                Content = content
            };
        }
    }
}