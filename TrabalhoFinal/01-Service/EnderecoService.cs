using Core._03_Entidades;
using TrabalhoFinal._01_Service.Interfaces;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._02_Repository.Interfaces;

namespace TrabalhoFinal._01_Service
{
    public class EnderecoService : IEnderecoService
    {
        public IEnderecoRepository repository { get; set; }
        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            repository = enderecoRepository;
        }
        public void Adicionar(Endereco endereco)
        {
            repository.Adicionar(endereco);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Endereco> Listar()
        {
            return repository.Listar();
        }
        public List<Endereco> ListarEnderecoPorId(int usuarioId)
        {
            return repository.ListarEnderecoPorId(usuarioId);
        }

        public Endereco BuscarEnderecoPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Endereco editEndereco)
        {
            repository.Editar(editEndereco);
        }
    }
}

