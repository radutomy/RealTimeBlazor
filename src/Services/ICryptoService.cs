using System;
using System.Collections;
using System.Collections.Generic;
using RealTimeCryptoBlazor.Data;

namespace RealTimeCryptoBlazor.Services
{
	public interface ICryptoService : IDisposable
	{
		event Action<ICrypto> OnPriceUpdate;
		IEnumerable<ICrypto> GetList();
	}
}