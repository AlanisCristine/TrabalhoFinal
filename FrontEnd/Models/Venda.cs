using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    public enum MetodoDePagamentoEnum
    {
        Pix = 1,
        Cartao = 2,
        Boleto = 3
    }

    public class Venda
    {
        public int Id { get; set; }
        public int EnderecoId { get; set; }
        public int PessoaId { get; set; }
        public int ProdutoId { get; set; }
        public MetodoDePagamentoEnum MetodoDePagamento { get; set; }
        public decimal ValorFinal { get; set; }
        public DateTime DataCompra { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Endereço: {EnderecoId} - Método de pagamento: {MetodoDePagamento} - Valor final: {ValorFinal}";
        }
    }
}

