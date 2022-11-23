using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLuna.Models
{
    public class VendaItem
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public Venda Venda{ get; set; }
        public Produto Produto { get; set; }
    }
}
