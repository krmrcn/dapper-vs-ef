using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace dapper_vs_ef
{
    public class NorthwindDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {

        }
    }



    [Table("Customers", Schema = "dbo")]
    public class Customer
    {
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }

        public string? ContactName { get; set; }

        public string? ContactTitle { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }
    }
}
