using System;
using System.Collections.Specialized;
using OpenRasta.Api.Basket.Resources;
using OpenRasta.Web;

namespace OpenRasta.Api.Basket.Handlers
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
			var getBasketUri = CreateGetBasketUri(basketResource);
			var selfLink = CreateSelfLink(getBasketUri);
			basketResource.SelfLink = selfLink;
			return new OperationResult.Created
					{
						RedirectLocation = getBasketUri,
						ResponseResource = basketResource
					};
		}

		private static LinkResource CreateSelfLink(Uri getBasketLink)
		{
			return new LinkResource{Relation = "self", Uri = getBasketLink.AbsoluteUri};
		}

		private Uri CreateGetBasketUri(BasketResource basketResource)
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