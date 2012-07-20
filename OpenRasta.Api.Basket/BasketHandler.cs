using System;
using System.Collections.Specialized;
using OpenRasta.Web;

namespace OpenRasta.Api.Basket
{
	public class BasketHandler
	{
		private readonly IUriResolver _uriResolver;
		private readonly ICommunicationContext _communicationContext;

		public BasketHandler(IUriResolver uriResolver, ICommunicationContext communicationContext)
		{
			_uriResolver = uriResolver;
			_communicationContext = communicationContext;
		}

		[HttpOperation(HttpMethod.POST)]
		public OperationResult Create()
		{
			var basketResource = new BasketResource { Id = 1 };
			return new OperationResult.Created
					{
						RedirectLocation = GetRedirectLocation(basketResource),
						ResponseResource = basketResource
					};
		}

		private Uri GetRedirectLocation(BasketResource basketResource)
		{
			return _uriResolver.CreateUriFor(
				_communicationContext.ApplicationBaseUri,
				basketResource.GetType(),
				null,
				new NameValueCollection { { "id", basketResource.Id.ToString() } }
				);
		}
	}
}