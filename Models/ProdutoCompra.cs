using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLuna.Models
{
    internal class ProdutoCompra
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public int IdCompra { get; set; }
        public int IdProduto { get; set; }

    }
}
