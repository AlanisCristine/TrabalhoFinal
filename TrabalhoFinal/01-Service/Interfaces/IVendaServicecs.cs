using Core._03_Entidades;
using FrontEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._01_Service.Interfaces
{
    public interface IVendaService
    {
        void Adicionar(Venda venda);
        void Remover(int id);
        List<Venda> Listar();
        ReadVendaReciboDTO BuscarTimePorId(int id);
        void Editar(Venda editPessoa);
        public List<ReadVendaReciboDTO> ListarVendaPreenchido(int usuarioId);
    }
}
