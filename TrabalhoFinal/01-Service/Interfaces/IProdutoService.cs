using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;

namespace TrabalhoFinal._01_Service.Interfaces
{
    public interface IProdutoService
    {
        void AdicionarProduto(Produto produto, bool e_funcionário);
        void RemoverProduto(int id);
        List<Produto> ListarProduto();
        Produto BuscarProdutoPorId(int id);
        void EditarProduto(Produto editProduto);
        public List<Produto> ProdutosUsuario(int id);
    }
}
