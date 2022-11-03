using Microsoft.AspNetCore.Http;
using Moq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Universidade.Data;
using Universidade.Models;

namespace ControllersTest
{
    public class Tests
    {
        private HttpClient _client;
        private Instituicao _instituicao;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();

            _instituicao = new Instituicao()
            {
                ID = 1,
                Nome = "Universidade Católica de Santos",
                Estado = "sp",
                Cidade = "Santos"
            };
        }

        [Test]
        public async Task TestarAdicionarInstituicao()
        { 
            _instituicao.Estado = _instituicao.Estado.ToUpper();

            String jsonInstituicao = JsonSerializer.Serialize(_instituicao);
            StringContent content = new StringContent(jsonInstituicao);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var resultado = await _client.PostAsync("https://localhost:7049/instituicao", content);
            
            Assert.That(resultado.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}