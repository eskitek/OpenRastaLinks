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
			var getBasketUri = CreateGetBasketUri(basketResource);
			var selfLink = CreateSelfLink(getBasketUri);
			basketResource.SelfLink = selfLink;
			return new OperationResult.Created
					{
						RedirectLocation = getBasketUri,
						ResponseResource = basketResource
					};
		}

		private static string CreateSelfLink(Uri getBasketLink)
		{
			const string linkTemplate = "<link uri=\"{0}\" rel=\"{1}\">";
			return string.Format(linkTemplate, getBasketLink, "self");
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