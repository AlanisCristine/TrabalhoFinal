using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;

namespace FrontEnd
{
    public class Sistema
    {

        private readonly PessoaUC _pessoaUC;
        private readonly ProdutoUC _produtoUC;
        //private readonly CarrinhoUC _carrinhoUC;
        private readonly EnderecoUC _enderecoUC;
        public Produto IdProd { get; set; }
        private static Pessoa UsuarioLogado { get; set; }

        public Sistema(HttpClient client)
        {
            _pessoaUC = new PessoaUC(client);
            _produtoUC = new ProdutoUC(client);
            //_carrinhoUC = new CarrinhoUC(client);
            _enderecoUC = new EnderecoUC(client);
        }

        public void InicializarSistema()
        {

        }

    }
}
