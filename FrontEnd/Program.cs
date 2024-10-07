using FrontEnd;
using System.Text.Json;

HttpClient cliente = new HttpClient()
{
    BaseAddress = new Uri("https://localhost:7237/")
};
Sistema sis = new Sistema(cliente);
sis.InicializarSistema();

