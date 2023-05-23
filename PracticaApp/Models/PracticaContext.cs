using System;
using System.Collections.Generic;
using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaApp.Models;

public partial class PracticaContext : DbContext
{
    public PracticaContext(DbContextOptions<PracticaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

}
