using Core._03_Entidades;

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface IEnderecoRepository
    {
        void Adicionar(Endereco endereco);
        void Remover(int id);
        List<Endereco> ListarEnderecoPorId(int usuarioId);
        void Editar(Endereco endereco);
        List<Endereco> Listar();
        Endereco BuscarPorId(int id);
    }
}
