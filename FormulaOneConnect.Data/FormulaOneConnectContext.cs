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
        optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=formulaoneconnect;User=root;Password=Opshacomp123@;old guids=true;");
    }

}
