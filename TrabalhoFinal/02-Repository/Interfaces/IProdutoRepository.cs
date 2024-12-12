using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface IProdutoRepository
    {
        void AdicionarProduto(Produto pro, bool e_funcionário);
        void RemoverProduto(int id);
        void EditarProduto(Produto pro);
        List<Produto> ListarProduto();
        Produto BuscarPorId(int id);
        List<Produto> ProdutosUsuario(int id);
    }
}
