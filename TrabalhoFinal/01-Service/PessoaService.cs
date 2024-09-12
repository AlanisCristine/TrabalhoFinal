using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidade;

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
        
        public Pessoa Login(string user)
        {
            return repository.BuscarPorUserName(user);
        }

    }
}
