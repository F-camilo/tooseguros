using Newtonsoft.Json;

namespace TooSeguros.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("senha")]
        public string Senha { get; set; }
    }
}
