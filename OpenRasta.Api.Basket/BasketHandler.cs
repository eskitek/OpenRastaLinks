using System;
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
			return new OperationResult.Created
					{
						RedirectLocation = new Uri("http://www.yahoo.com"), 
						ResponseResource = new BasketResource()
					};
		}
	}
}