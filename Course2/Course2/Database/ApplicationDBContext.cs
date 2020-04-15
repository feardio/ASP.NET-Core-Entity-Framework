using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course2.Models;

namespace Course2.Database
{
    public class ApplicationDBContext : DbContext
    {
        

       public DbSet<Funcionario> Funcionarios { get; set; }



        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
   
    }
}
