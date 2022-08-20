using ClienteApi.Models;
namespace ClienteAPI.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string Expiration { get; set; }

        public AspNetUserViewModel user { get; set; }

    }
}
