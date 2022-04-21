using Microsoft.EntityFrameworkCore;

namespace MigrateReviewsCore.DataBase
{
    internal class StreamingServiceContext:DbContext
    {
        private readonly string ConnectionString;
        public StreamingServiceContext(string connectionString)
        { 
            ConnectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public DbSet<FeedbackCloudTips> feedbackCloudTips { get; set; }
    }
}
