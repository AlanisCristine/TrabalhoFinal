using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._01_Service.Interfaces
{
    public interface IPessoaService
    {
        void Adicionar(Pessoa usuario);
        Pessoa FazerLogin(LoginDTO usuarioLoginDTO);
        void Editar(Pessoa usuario);
        void Remover(int id);
        List<Pessoa> Listar();
        Pessoa BuscarTimePorId(int id);
        

    }
}
