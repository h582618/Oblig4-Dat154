using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_app_customer.Models;

namespace Web_app_customer
{
    public class Oblig4Context : DbContext
    {
        public Oblig4Context(DbContextOptions<Oblig4Context> options) : base(options)
        {

        }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Models.Task> tasks { get; set; }
        public DbSet<User> users { get; set; }

    }
}