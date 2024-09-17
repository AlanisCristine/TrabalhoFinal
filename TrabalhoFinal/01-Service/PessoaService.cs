using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._01_Service
{
    public class PessoaService
    {
        public PessoaRepository repository { get; set; }

        public PessoaService(string ConnectionString)
        {
            repository = new PessoaRepository(ConnectionString);
        }

        public void AdicionarPessoa(Pessoa pessoa)
        {
            repository.AdicionarPessoa(pessoa);
        }

        public void RemoverPessoa(int id)
        {
            repository.RemoverPessoa(id);
        }

        public List<Pessoa> ListarPessoa()
        {

            return repository.ListarPessoa();
        }
        public Pessoa buscarporid(int id)
        {
            return repository.BuscarPorId(id);
        }

        public void EditarPessoa(Pessoa editPessoa)
        {
            repository.Editar(editPessoa);
        }

        public LoginPessoaDTO Login(string user, string passw)
        {
            LoginPessoaDTO pessoaReturn = new LoginPessoaDTO();
            bool verificacao = false; //se logou ou não

            Pessoa p = repository.BuscarPorUserName(user);//retorna a pessoa se tiver criada no banco

            if (p == null)
            {
                p = new Pessoa();
                verificacao = false;
                pessoaReturn.Login = verificacao;
            }//verifica o nome
            if (passw == p.Senha)
            {
                    verificacao = true;
            }//verifica a senha

            if (!verificacao)
            {
                return pessoaReturn;
            }//se a verificação não estiver correta, não retorna nada e caba o método.

            pessoaReturn.Login = verificacao;
            pessoaReturn.Nome = p.Nome;
            pessoaReturn.UserName = p.UserName;
            pessoaReturn.Senha = p.Senha;
            pessoaReturn.Endereco = p.Endereco;

            return pessoaReturn;
        }

    }
}
