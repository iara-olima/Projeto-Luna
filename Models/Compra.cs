﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLuna.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Hora { get; set; }

        public int Parcela { get; set; }
        public string Descricao { get; set; }

    }
}
