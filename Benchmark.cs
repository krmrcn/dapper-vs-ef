using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace dapper_vs_ef
{
    public class AntiVirusFriendlyConfig : ManualConfig
    {
        public AntiVirusFriendlyConfig()
        {
            AddJob(Job.MediumRun.WithToolchain(InProcessNoEmitToolchain.Instance));
        }
    }

    [Config(typeof(AntiVirusFriendlyConfig))]
    [MemoryDiagnoser(false)]
    public class Benchmark
    {
        private PooledDbContextFactory<NorthwindDbContext> pooledFactory;
        private const string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        [GlobalSetup]
        public void Setup()
        {
            var efCoreOptions = new DbContextOptionsBuilder<NorthwindDbContext>().UseSqlServer(connString).Options;
            pooledFactory = new PooledDbContextFactory<NorthwindDbContext>(efCoreOptions);
        }

        [Benchmark]
        public List<Customer> EFTrackingGet_All_Customers()
        {
            using var dbContext = pooledFactory.CreateDbContext();

            return dbContext.Customers.ToList();
        }

        [Benchmark]
        public List<Customer> EFNoTrackingGet_All_Customers()
        {
            using var dbContext = pooledFactory.CreateDbContext();

            return dbContext.Customers.AsNoTracking().ToList();
        }

        [Benchmark]
        public List<Customer> EFQueryTrackingGet_All_Customers()
        {
            using var dbContext = pooledFactory.CreateDbContext();

            return dbContext.Database.SqlQuery<Customer>(@$"
                Select 
                    CustomerId,
                    CompanyName,
                    ContactName,
                    ContactTitle,
                    Address,
                    City,
                    Region,
                    PostalCode,
                    Country,
                    Phone,
                    Fax
                from [dbo].[Customers]")
                .ToList();
        }

        [Benchmark]
        public List<Customer> EFQueryNoTrackingGet_All_Customers()
        {
            using var dbContext = pooledFactory.CreateDbContext();

            return dbContext.Database.SqlQuery<Customer>
                (@$"Select 
                    CustomerId,
                    CompanyName,
                    ContactName,
                    ContactTitle,
                    Address,
                    City,
                    Region,
                    PostalCode,
                    Country,
                    Phone,
                    Fax
                from [dbo].[Customers]")
                .AsNoTracking()
                .ToList();
        }

        [Benchmark]
        public List<Customer> DapperGet_All_Customers()
        {
            using var sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            return sqlConnection.Query<Customer>
                (@$"Select 
                    CustomerId,
                    CompanyName,
                    ContactName,
                    ContactTitle,
                    Address,
                    City,
                    Region,
                    PostalCode,
                    Country,
                    Phone,
                    Fax
                from [dbo].[Customers]")
                .ToList();
        }


        [Benchmark]
        public List<Customer> EFLambdaTrackingGet_Filtered_Customers()
        {
            using var dbContext = pooledFactory.CreateDbContext();

            return dbContext.Customers.Where(d => d.ContactTitle == "Owner").ToList();
        }

        [Benchmark]
        public List<Customer> EFLambdaNoTrackingGet_Filtered_Customers()
        {
            using var dbContext = pooledFactory.CreateDbContext();

            return dbContext.Customers.Where(d => d.ContactTitle == "Owner").AsNoTracking().ToList();
        }

        [Benchmark]
        public List<Customer> EFQueryTrackingGet_Filtered_Customers()
        {
            using var dbContext = pooledFactory.CreateDbContext();

            return dbContext.Database.SqlQuery<Customer>(@$"
                Select 
                    CustomerId,
                    CompanyName,
                    ContactName,
                    ContactTitle,
                    Address,
                    City,
                    Region,
                    PostalCode,
                    Country,
                    Phone,
                    Fax
                from [dbo].[Customers]
                where ContactTitle='Owner'")
                .ToList();
        }

        [Benchmark]
        public List<Customer> EFQueryNoTrackingGet_Filtered_Customers()
        {
            using var dbContext = pooledFactory.CreateDbContext();

            return dbContext.Database.SqlQuery<Customer>
                (@$"Select 
                    CustomerId,
                    CompanyName,
                    ContactName,
                    ContactTitle,
                    Address,
                    City,
                    Region,
                    PostalCode,
                    Country,
                    Phone,
                    Fax
                from [dbo].[Customers]
                where ContactTitle='Owner'")
                .AsNoTracking()
                .ToList();
        }

        [Benchmark]
        public List<Customer> DapperGet_Filtered_Customers()
        {
            using var sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            return sqlConnection.Query<Customer>
                (@$"Select 
                    CustomerId,
                    CompanyName,
                    ContactName,
                    ContactTitle,
                    Address,
                    City,
                    Region,
                    PostalCode,
                    Country,
                    Phone,
                    Fax
                from [dbo].[Customers]
                where ContactTitle='Owner'")
                .ToList();
        }
    }
}
