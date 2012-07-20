using OpenRasta.Web;

namespace OpenRasta.Api.Basket
{
	public class BasketHandler
	{
		private readonly IUriCreator _uriCreator;

		public BasketHandler(IUriCreator uriCreator)
		{
			_uriCreator = uriCreator;
		}

		[HttpOperation(HttpMethod.POST)]
		public OperationResult Create()
		{
			var basketResource = new BasketResource();
			return new OperationResult.Created
					{
						RedirectLocation = _uriCreator.CreateGetBasketUri(basketResource), 
						ResponseResource = basketResource
					};
		}
	}
}