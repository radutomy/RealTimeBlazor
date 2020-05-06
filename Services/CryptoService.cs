using System.Threading.Tasks;
using System;
using System.Timers;
using realtimeblazor.Data;
using System.Collections.Generic;

namespace realtimeblazor.Services
{
	// shit implementation of a service pattern :D
	public class CryptoService : ICryptoService
	{
		private readonly Coinbase.CoinbaseClient _client;
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

			_client = new Coinbase.CoinbaseClient();
			_timer = new Timer(500);
			_timer.Elapsed += OnTimedEvent;
			_timer.Start();
		}

		private async void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			foreach (var crypto in _portofolio)
			{
				var response = await _client.Data.GetSpotPriceAsync($"{crypto.Ticker}-USD");

				// new price!
				if (crypto.Price != response.Data.Amount)
				{
					crypto.Price = response.Data.Amount;
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
			_timer.Elapsed -= OnTimedEvent;
		}

	}
}
