using System;
using System.Collections;
using System.Collections.Generic;
using realtimeblazor.Data;

namespace realtimeblazor.Services
{
	public interface ICryptoService : IDisposable
	{
		event Action<ICrypto> OnPriceUpdate;
		IEnumerable<ICrypto> GetList();
	}
}