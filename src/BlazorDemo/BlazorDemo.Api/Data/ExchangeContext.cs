using BlazorDemo.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Api.Data
{
    public class ExchangeContext : DbContext
    {
        public ExchangeContext(DbContextOptions<ExchangeContext> options): base(options)
        { }

        public DbSet<StockMarketEntity> StockMarkets { get; set; }
        public DbSet<EndOfDayEntity> EndOfDays { get; set; }
        public DbSet<TickerEntity> Tickers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StockMarketEntity>()
                .OwnsOne(x => x.Currency);
        }
    }
}
