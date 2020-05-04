using System;
using realtimeblazor.Data;

namespace realtimeblazor.Services
{
	public interface ICryptoService : IDisposable
	{
		event Action<ICrypto> OnPriceUpdate;
	}
}