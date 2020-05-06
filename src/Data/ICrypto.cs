namespace RealTimeCryptoBlazor.Data
{
	public interface ICrypto
	{
		public string Name { get; }
		public Ticker Ticker { get; }
		public decimal Price { get; set; }
	}
}