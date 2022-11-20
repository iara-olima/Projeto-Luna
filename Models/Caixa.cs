using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLuna.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public Double? SaldoInicial { get; set; }
        public Double? SaldoFinal { get; set; }
        public Double? Recebimentos { get; set; }
        public Double? Pagamentos { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}
