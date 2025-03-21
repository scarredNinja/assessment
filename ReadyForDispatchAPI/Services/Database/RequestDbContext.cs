using Microsoft.EntityFrameworkCore;

public class RequestDbContext : DbContext
{
    public RequestDbContext(DbContextOptions<RequestDbContext> options) : base(options) { }

    public DbSet<ProcessedRequest> ProcessedRequests { get; set; }
}