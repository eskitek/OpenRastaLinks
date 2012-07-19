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
	}

	public class BasketHandler
	{
		public OperationResult Create()
		{
			throw new System.NotImplementedException();
		}
	}
}
