using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLuna.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Hora { get; set; }
        public Double? Valor { get; set; }
        public int Parcelas { get; set; }
        public Double? ValorParc { get; set; }
        public string Tipo { get; set; }

    }
}
