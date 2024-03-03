using FormulaOneConnect.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneConnect.Data;

public class FormulaOneConnectContext : DbContext
{
    private readonly IConfiguration _configuration;

    public FormulaOneConnectContext()
    {
        
    }

    public FormulaOneConnectContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=us-cluster-east-01.k8s.cleardb.net;Port=3306;Database=formulaoneconnect;User=bead8af71a59a1;Password=5064e8ca;");
    }

}
