using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MvcMovie.Data
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<MvcMovieContext>
    {
        public MvcMovieContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<MvcMovieContext>();

            // this connection string is for local SQL database 
            // This database instance is generally installed with default Visual Studio components
            // If you use SQL Server Express, change connection string appropriately
            // NOTE: Do not hardcode connection strings in code.  
            // This is hard coded here to limit scope of demo.
            //var connectionString = "Server=tcp:servidormicroservicios.database.windows.net,1433;Initial Catalog=WebApplicationMonica;Persist Security Info=False;User ID=jacinto;Password=P0t@toP0t@to;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var connectionString = "Data Source=MONICAIT;Initial Catalog=MvcMovie.Data; Integrated Security=True;";

            // Conexión con DB
            dbContextBuilder.UseSqlServer(connectionString, sqloptions => {
                sqloptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: new List<int>() { });
            });       
            return new MvcMovieContext(dbContextBuilder.Options);
        }
    }
}