using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PiDevCRM.Domain.Entities;

namespace PiDevCRM.Data
{
    public class PiDevCRMContexte : DbContext
    {
        public PiDevCRMContexte() : base("name=MaChaine")
        {

        }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Agent> Agent { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Claims> Claims { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Pack> Pack { get; set; }
        public DbSet<Postes> Postes { get; set; }
        public DbSet<Prospection> Prospection { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}

