using FormulaOneConnect.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneConnect.Data;

public class FormulaOneConnectContext : DbContext
{
    private readonly IConfiguration _configuration;

    public FormulaOneConnectContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_configuration.GetConnectionString("FormulaOneConnectConnectionString"));
    }

}
