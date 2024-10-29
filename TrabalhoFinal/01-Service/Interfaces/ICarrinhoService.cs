using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._01_Service.Interfaces
{
    public interface ICarrinhoService
    {
        void Adicionar(Carrinho carrinho);
        void Remover(int id);
        List<CarrinhoDTO> ListarCarrinhoPreenchido(int usuarioId);
        List<Carrinho> Listar();
        Carrinho BuscarTimePorId(int id);
        void Editar(Carrinho editPessoa);
    }
}
