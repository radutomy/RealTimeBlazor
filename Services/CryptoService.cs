using System.Threading.Tasks;
using System;
using System.Timers;
using realtimeblazor.Data;

namespace realtimeblazor.Services
{
	// shit implementation of a service pattern :D
	public class CryptoService : ICryptoService
	{
		private readonly Coinbase.CoinbaseClient _client;
		private readonly Timer _timer;

		public CryptoService()
		{
			_client = new Coinbase.CoinbaseClient();
			_timer = new Timer(500);
			_timer.Elapsed += OnTimedEvent;
			_timer.Start();
		}

		public event Action<ICrypto> OnPriceUpdate = delegate { };

		event Action<ICrypto> ICryptoService.OnPriceUpdate
		{
			add
			{
				throw new NotImplementedException();
			}

			remove
			{
				throw new NotImplementedException();
			}
		}

		public void Dispose()
		{
			_timer.Elapsed -= OnTimedEvent;
		}

		void IDisposable.Dispose()
		{
			throw new NotImplementedException();
		}

		private async void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			var result = await _client.Data.GetSpotPriceAsync("BTC-USD");
			var btc = new Bitcoin { Price = result.Data.Amount };
			OnPriceUpdate(btc);

			await Task.Delay(15);

			result = await _client.Data.GetSpotPriceAsync("ETH-USD");
			var eth = new Ethereum { Price = result.Data.Amount };
			OnPriceUpdate(eth);

			await Task.Delay(15);

			result = await _client.Data.GetSpotPriceAsync("XRP-USD");
			var xrp = new Ripple { Price = result.Data.Amount };
			OnPriceUpdate(xrp);

			await Task.Delay(15);

			result = await _client.Data.GetSpotPriceAsync("LTC-USD");
			var ltc = new Litecoin { Price = result.Data.Amount };
			OnPriceUpdate(ltc);

			await Task.Delay(15);

			result = await _client.Data.GetSpotPriceAsync("BCH-USD");
			var bch = new BitcoinCash { Price = result.Data.Amount };
			OnPriceUpdate(bch);
		}
	}
}
