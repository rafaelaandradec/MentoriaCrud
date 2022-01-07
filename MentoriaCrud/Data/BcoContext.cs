using MentoriaCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentoriaCrud.Data
{
    public class BcoContext : DbContext
    {
        public BcoContext(DbContextOptions<BcoContext> options) : base(options)
        {           
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
