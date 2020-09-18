using BlazorDemo.Api.Data;
using BlazorDemo.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ExchangeContext _context;

        public StockController(ExchangeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exchange>> GetAll()
        {
            var exchanges = await _context.StockMarkets.Select(x => new Exchange
            {
                Name = x.Name,
                Acronym = x.Acronym,
                Identifier = x.IdentifierCode,
                Country = x.Country,
                City = x.City,
                Currency = x.Currency.Code
            }).ToListAsync();

            return exchanges;
        }

        [HttpGet("tickers/{id}")]
        public async Task<IEnumerable<Ticker>> GetTickersForStock(string id)
        {
            var tickers = await _context.Tickers.Where(x => x.StockIdentifierCode == id).Select(x => new Ticker()
            {
                Name = x.Name,
                Symbol = x.Symbol
            }).ToListAsync();

            return tickers;
        }

        [HttpGet("tickers/daydata/{symbol}")]
        public async Task<IEnumerable<DayData>> GetDayData(string symbol)
        {
            var data = await _context.EndOfDays.Where(x => x.Symbol == symbol).OrderBy(x => x.Date).Select(x => new DayData
            {
                X = x.Date,
                Y = x.Close
            }).ToListAsync();

            return data;
        }
    }
}
