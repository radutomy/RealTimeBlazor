using System;
using System.Timers;
using RealTimeCryptoBlazor.Data;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace RealTimeCryptoBlazor.Services
{
	// nasty implementation of the service pattern
	public class CryptoService : ICryptoService
	{
		HttpClient _client;
		private readonly IList<ICrypto> _portofolio;
		private readonly Timer _timer;

		public CryptoService()
		{
			// this normall comes from a database
			_portofolio = new List<ICrypto>() {
				new Bitcoin(),
				new Ethereum(),
				new Ripple(),
				new Litecoin(),
				new BitcoinCash()
			};

			_client = new HttpClient();
			_timer = new Timer(500);
			_timer.Elapsed += OnTimedEvent;
			_timer.Start();
		}

		private async void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			foreach (var crypto in _portofolio)
			{
				var json = await _client.GetStringAsync($"https://api.coinbase.com/v2/prices/{crypto.Ticker}-USD/spot");
				dynamic response = JObject.Parse(json);
				decimal amount = response.data.amount;

				// new price!
				if (crypto.Price != amount)
				{
					crypto.Price = amount;
					OnPriceUpdate(crypto);
				}
			}
		}

		public event Action<ICrypto> OnPriceUpdate = delegate { };

		// get metadata. normally db call
		public IEnumerable<ICrypto> GetList() => new List<ICrypto> {
			new Bitcoin(),
			new Ethereum(),
			new Ripple(),
			new Litecoin(),
			new BitcoinCash()
		};

		public void Dispose()
		{
			_client.Dispose();
			_timer.Dispose();
			_timer.Elapsed -= OnTimedEvent;
		}

	}
}






public class Rootobject
{
	public Data data { get; set; }
}

public class Data
{
	public string _base { get; set; }
	public string currency { get; set; }
	public string amount { get; set; }
}
