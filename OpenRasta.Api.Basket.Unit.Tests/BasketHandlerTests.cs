using NUnit.Framework;
using OpenRasta.Web;

namespace OpenRasta.Api.Basket.Unit.Tests
{
	[TestFixture]
	public class BasketHandlerTests
	{
		[Test]
		public void Create_returns_Created_operation_result()
		{
			var basketHandler = new BasketHandler();

			var result = basketHandler.Create();

			Assert.That(result, Is.TypeOf<OperationResult.Created>());
		}

		[Test]
		public void Create_sets_the_redirect_location_on_the_returned_operation_result()
		{
			var basketHandler = new BasketHandler();

			var result = (OperationResult.Created)basketHandler.Create();

			Assert.IsNotNull(result.CreatedResourceUrl);
		}
	}
}
