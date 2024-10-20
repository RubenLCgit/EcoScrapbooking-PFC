using Microsoft.EntityFrameworkCore;
using EcoScrapbookingAPI.Domain;

namespace EcoScrapbookingAPI.Data;

public class EcoScrapbookingDBContext : DbContext
{
  public EcoScrapbookingDBContext(DbContextOptions<EcoScrapbookingDBContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    
  }
}