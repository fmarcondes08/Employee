using Microsoft.EntityFrameworkCore;
using TallerCodeChallengeApi.Models;

namespace TallerCodeChallengeApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Employee> Employees { get; set; }
}