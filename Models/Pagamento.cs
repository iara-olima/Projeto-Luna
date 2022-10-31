﻿using System;
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
        public float Valor { get; set; }
        public string FormaPag { get; set; }
        public string Status { get; set; }
        public DateTime? Vencimento { get; set; }
        public DateTime? Hora { get; set; }
        public int IdCaixa { get; set; }
        public int IdDespesa { get; set; }
    }
}
