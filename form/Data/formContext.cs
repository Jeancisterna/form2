using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using form.Controllers;

namespace form.Data
{
    public class formContext : DbContext
    {
        public formContext (DbContextOptions<formContext> options)
            : base(options)
        {
        }

        public DbSet<form.Controllers.datos> datos { get; set; } = default!;
    }
}
