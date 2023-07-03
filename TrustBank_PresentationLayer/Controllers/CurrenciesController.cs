using Microsoft.AspNetCore.Mvc;

namespace TrustBank_PresentationLayer.Controllers
{
    public class CurrenciesController : Controller
    {
        public async Task<IActionResult> DisplayCurrencies()
        {
            #region
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "a83746901emshc93877d882a5573p1a5f3cjsn9f1aa850f786" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.USDTOTRY = Decimal.Parse(body.Replace(".", ",")).ToString("0.0000");

            }
            #endregion

            #region
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "a83746901emshc93877d882a5573p1a5f3cjsn9f1aa850f786" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ViewBag.EURTOTRY = Decimal.Parse(body2.Replace(".", ",")).ToString("0.0000");
            }
            #endregion


            #region
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "a83746901emshc93877d882a5573p1a5f3cjsn9f1aa850f786" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ViewBag.GBPTOTRY = Decimal.Parse(body3.Replace(".", ",")).ToString("0.0000");
            }
            #endregion

            #region
            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=USD&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "a83746901emshc93877d882a5573p1a5f3cjsn9f1aa850f786" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response4 = await client.SendAsync(request4))
            {
                response4.EnsureSuccessStatusCode();
                var body4 = await response4.Content.ReadAsStringAsync();
                ViewBag.EURTOTUSD = Decimal.Parse(body4.Replace(".", ",")).ToString("0.0000");
            }
            #endregion
            return View();
        }
    }
}
