using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Service
{
    public class EnderecoService
    {
        public EnderecoRepository repository { get; set; }
        public EnderecoService(string _config)
        {
            repository = new EnderecoRepository(_config);
        }
        public void Adicionar(Endereco endereco)
        {
            repository.Adicionar(endereco);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Endereco> Listar()
        {
            return repository.Listar();
        }
        public List<Endereco> ListarEnderecoPorId(int usuarioId)
        {
            return repository.ListarEnderecoPorId(usuarioId);
        }

        public Endereco BuscarEnderecoPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Endereco editEndereco)
        {
            repository.Editar(editEndereco);
        }
    }
}

