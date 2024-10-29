using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._01_Service.Interfaces;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._01_Service
{
    public class PessoaService : IPessoaService
    {
        public IPessoaRepository repository { get; set; }
        public PessoaService(string _config)
        {
            repository = new PessoaRepository(_config);
        }
        public void Adicionar(Pessoa usuario)
        {
            repository.Adicionar(usuario);
        }

        public Pessoa FazerLogin(LoginDTO usuarioLoginDTO)
        {
            List<Pessoa> listarusuario = Listar();
            foreach (Pessoa usuario in listarusuario)
            {
                if (usuario.UserName == usuarioLoginDTO.UserName && usuario.Senha == usuarioLoginDTO.Senha)
                {
                    return usuario;
                }
            }
            return null;
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Pessoa> Listar()
        {
            return repository.Listar();
        }
        public Pessoa BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Pessoa editPessoa)
        {
            repository.Editar(editPessoa);
        }
    }
}
