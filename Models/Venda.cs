using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLuna.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Double? Valor { get; set; }
        public DateTime? Hora { get; set; }

        public DateTime? Data { get; set; }

    }
}
