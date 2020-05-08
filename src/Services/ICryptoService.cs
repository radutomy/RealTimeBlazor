using System;
using System.Collections.Generic;
using RealTimeBlazor.Data;

namespace RealTimeBlazor.Services
{
	public interface ICryptoService : IDisposable
	{
		event Action<ICrypto> OnPriceUpdate;
		IEnumerable<ICrypto> GetList();
	}
}