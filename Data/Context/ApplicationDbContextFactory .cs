using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OrdersAPI.Insfractucture.Context;

using System.IO;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = "Server = localhost; Database = GrupoL; TrustServerCertificate = true; Trusted_Connection = true; MultipleActiveResultSets = true";

        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
