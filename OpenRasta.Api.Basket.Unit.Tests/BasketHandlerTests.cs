using NUnit.Framework;
using OpenRasta.Web;
using Rhino.Mocks;

namespace OpenRasta.Api.Basket.Unit.Tests
{
	[TestFixture]
	public class BasketHandlerTests
	{
		private IUriCreator _uriCreator;
		private BasketHandler _basketHandler;

		[SetUp]
		public void SetUp()
		{
			_uriCreator = MockRepository.GenerateStub<IUriCreator>();
			_basketHandler = new BasketHandler(_uriCreator);
		}

		[Test]
		public void Create_returns_Created_operation_result()
		{
			var result = _basketHandler.Create();

			Assert.That(result, Is.TypeOf<OperationResult.Created>());
		}

		[Test]
		public void Create_sets_the_redirect_location_on_the_returned_operation_result()
		{
			var result = _basketHandler.Create();

			Assert.IsNotNull(result.RedirectLocation);
		}

		[Test]
		public void Create_sets_the_response_resource_on_the_returned_operation_result()
		{
			var result = _basketHandler.Create();

			Assert.IsNotNull(result.ResponseResource);
			Assert.IsInstanceOf<BasketResource>(result.ResponseResource);
		}

		[Test]
		public void Create_calls_UriCreator_to_get_the_resource_location_for_the_new_basket()
		{
			var uriCreator = MockRepository.GenerateStub<IUriCreator>();
			var basketHandler = new BasketHandler(uriCreator);

			var result = basketHandler.Create();

			uriCreator.AssertWasCalled(uc => uc.CreateGetBasketUri(result.ResponseResource as BasketResource));
		}
	}
}
