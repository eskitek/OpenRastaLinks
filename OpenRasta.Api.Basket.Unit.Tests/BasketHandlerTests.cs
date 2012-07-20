using System;
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

		private void StubCreateGetBasketUriToReturn(Uri uri)
		{
			_uriCreator.Stub(uc => uc.CreateGetBasketUri(Arg<BasketResource>.Is.Anything)).Return(uri);
		}

		private void StubCreateGetBasketUriToReturn(string url)
		{
			StubCreateGetBasketUriToReturn(new Uri(url));
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
			StubCreateGetBasketUriToReturn("http://www.someurl.com");

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
			var result = _basketHandler.Create();

			_uriCreator.AssertWasCalled(uc => uc.CreateGetBasketUri(result.ResponseResource as BasketResource));
		}

		[Test]
		public void Create_sets_the_redirect_location_on_the_returned_operation_result_to_the_uri_returned_from_CreateGetBasketUri()
		{
			var someUri = new Uri("http://www.someurl.com");
			StubCreateGetBasketUriToReturn(someUri);

			var result = _basketHandler.Create();

			Assert.AreEqual(result.RedirectLocation, someUri);
		}
	}
}
