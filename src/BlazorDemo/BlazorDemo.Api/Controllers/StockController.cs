using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorDemo.Api.Data;
using BlazorDemo.Api.Data.Models;
using BlazorDemo.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ExchangeContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public StockController(ExchangeContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public async Task ImportData()
        {
            var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://api.marketstack.com/v1/exchanges?access_key=XXX");
            //response.EnsureSuccessStatusCode();
            //var json = await response.Content.ReadAsStringAsync();
            //var data = JsonConvert.DeserializeObject<ExchangeResponse>(json);

            //var markets = data.data.Select(x => new StockMarketEntity
            //{
            //    Name = x.name,
            //    Acronym = x.acronym,
            //    IdentifierCode = x.mic,
            //    Currency = x.currency,
            //    Country = x.country,
            //    City = x.city
            //});

            //await _context.StockMarkets.AddRangeAsync(markets);
            //await _context.SaveChangesAsync();

            //foreach(var stock in markets)
            //{
            //    response = await client.GetAsync($"http://api.marketstack.com/v1/tickers?access_key=XXX&exchange={stock.IdentifierCode}");
            //    response.EnsureSuccessStatusCode();
            //    json = await response.Content.ReadAsStringAsync();
            //    var tickerData = JsonConvert.DeserializeObject<TickerResponse>(json);

            //    var tickers = tickerData.data.Select(x => new TickerEntity
            //    {
            //        Name = x.name,
            //        StockIdentifierCode = x.stock_exchange.mic,
            //        Symbol = x.symbol
            //    });

            //    await _context.AddRangeAsync(tickers);
            //    await _context.SaveChangesAsync();
            //}

            foreach(var ticker in _context.Tickers.Where(x => x.StockIdentifierCode == "XNAS" || x.StockIdentifierCode == "XNYS" || x.StockIdentifierCode == "XWAR"))
            {
                var response = await client.GetAsync($"http://api.marketstack.com/v1/eod?access_key=XXX&limit=7&offset=7&symbols={ticker.Symbol}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var endOfDays = JsonConvert.DeserializeObject<EodResponse>(json);

                await _context.EndOfDays.AddRangeAsync(endOfDays.data);
                
            }

            await _context.SaveChangesAsync();
        }
    }

    internal class ExchangeResponse
    {
        public IEnumerable<ExchangeResponseItem> data { get; set; }
    }

    internal class ExchangeResponseItem
    {
        public string name { get; set; }
        public string acronym { get; set; }
        public string mic { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public Currency currency { get; set; }
    }

    internal class TickerResponse
    {
        public IEnumerable<TickerResponseItem> data { get; set; }
    }

    internal class TickerResponseItem
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public StockExchangeData stock_exchange { get; set; }
    }

    internal class StockExchangeData
    {
        public string mic { get; set; }
    }

    internal class EodResponse
    {
        public IEnumerable<EndOfDayEntity> data { get; set; }
    }
}
