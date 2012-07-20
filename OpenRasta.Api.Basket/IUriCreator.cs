using System;

namespace OpenRasta.Api.Basket
{
	public interface IUriCreator
	{
		Uri CreateGetBasketUri(BasketResource basketResource);
	}
}