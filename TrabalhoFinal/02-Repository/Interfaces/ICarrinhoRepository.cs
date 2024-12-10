using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface ICarrinhoRepository
    {
        void Adicionar(Carrinho carrinho);
        void Editar(Carrinho carrinho);
        void Remover(int id);
        public void DeletarProdutosDoCarrinho(int usuarioId);
        List<Carrinho> Listar();
        Carrinho BuscarPorId(int id);
        List<CarrinhoDTO> ListarCarrinhoPreenchido(int usuarioId);
       
    }
}
