using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLuna.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public Double? Valor { get; set; }
        public DateTime? Data { get; set; }

        public string FormaPagamento { get; set; }
        public int Parcela { get; set; }
        public string Descricao { get; set; }
        public Double? ValorParc { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Funcionario Funcionario { get; set; }
        

        public List<CompraItem> Itens { get; set; } = new List<CompraItem>();
    }
}
