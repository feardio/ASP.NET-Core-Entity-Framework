using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course2.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Categoria Categoria { get; set; } //Cria um relacionamento entre produto e categoria

        public override string ToString()
        {
            return "Id: " + this.Id + " Nome:" + this.Nome + " Categoria: [" + this.Categoria.ToString() + "]";
        }
    }
}

