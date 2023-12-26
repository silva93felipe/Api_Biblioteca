using System.Net;
using System.Text;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace aluga_livro_api.Test;

public class UnitTest1
{
    [Fact]
    public async void Deve_Ao_Criar_Um_Livro_Retornar_StatusCode_Ok()
    {
        using var http = new HttpClient();
        Livro livro = new("Meu Livro", "Eu", "2000", "Seu tempo aqui...");
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(livro);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await http.PostAsync("http://localhost:5182/api/Livro", data);
        
        Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
    }
}