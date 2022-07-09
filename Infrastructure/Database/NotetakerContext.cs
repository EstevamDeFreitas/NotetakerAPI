using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class NotetakerContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Note> Notes { get; set; }
        public NotetakerContext(DbContextOptions<NotetakerContext> options) : base(options)
        {

        }
    }
}
