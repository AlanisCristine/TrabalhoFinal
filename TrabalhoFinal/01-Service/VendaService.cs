using Core._02_Repository;
using Core._03_Entidades;
using FrontEnd;
using TrabalhoFinal._01_Service.Interfaces;
using TrabalhoFinal._02_Repository.Interfaces;

namespace Core._01_Services
{
    public class VendaService : IVendaService
    {
        public IVendaRepository repository { get; set; }
        public VendaService(string _config)
        {
            repository = new VendaRepository(_config);
        }
        public void Adicionar(Venda venda)
        {
            repository.Adicionar(venda);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Venda> Listar()
        {
            return repository.Listar();
        }
        public ReadVendaReciboDTO BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Venda editPessoa)
        {
            repository.Editar(editPessoa);
        }
    }
}
