using OpenRasta.Web;

namespace OpenRasta.Api.Basket
{
	public class BasketHandler
	{
		[HttpOperation(HttpMethod.POST)]
		public OperationResult Create()
		{
			return new OperationResult.Created();
		}
	}
}