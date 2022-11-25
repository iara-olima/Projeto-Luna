using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLuna.Models
{
    public class Pagamento
    {

        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public double Valor { get; set; }
        public string FormaPag { get; set; }
        public DateTime? Vencimento { get; set; }
        public DateTime? Hora { get; set; }
        public Caixa Caixa { get; set; }
        public Despesa Despesa { get; set; }

    }
}
