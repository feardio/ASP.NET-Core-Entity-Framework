﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course2.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public override string ToString()
        {
            return "Id: " + this.Id + " Nome:" + this.Nome;
        }
       
    }
}
