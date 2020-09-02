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
    }
}
