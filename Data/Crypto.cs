using System.Data;
using System;

namespace realtimeblazor.Data
{
	public class Bitcoin : ICrypto
	{
		public string Name => "Bitcoin";
		public Ticker Ticker => Ticker.BTC;
		public decimal Price { get; set; }
	}

	public class Ethereum : ICrypto
	{
		public string Name => "Ethereum";
		public Ticker Ticker => Ticker.ETH;
		public decimal Price { get; set; }
	}

	public class Ripple : ICrypto
	{
		public string Name => "Ripple";
		public Ticker Ticker => Ticker.XRP;
		public decimal Price { get; set; }
	}

	public class BitcoinCash : ICrypto
	{
		public string Name => "Bitcoin Cash";

		public Ticker Ticker => Ticker.BCH;

		public decimal Price { get; set; }
	}

	public class Litecoin : ICrypto
	{
		public string Name => "Litecoin";

		public Ticker Ticker => Ticker.LTC;

		public decimal Price { get; set; }
	}
}
