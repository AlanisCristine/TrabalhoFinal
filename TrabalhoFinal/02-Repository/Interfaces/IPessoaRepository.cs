using TrabalhoFinal._03_Entidade;

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface IPessoaRepository
    {
        void Adicionar(Pessoa usuario);
        void Remover(int id);
        void Editar(Pessoa usuario);
        List<Pessoa> Listar();
        Pessoa BuscarPorId(int id);
    }
}
