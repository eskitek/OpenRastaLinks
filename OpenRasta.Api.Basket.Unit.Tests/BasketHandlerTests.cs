using System;
using System.Collections.Specialized;
using NUnit.Framework;
using OpenRasta.Web;
using Rhino.Mocks;

namespace OpenRasta.Api.Basket.Unit.Tests
{
	[TestFixture]
	public class BasketHandlerTests
	{
		private IUriResolver _uriResolver;
		private BasketHandler _basketHandler;

		[SetUp]
		public void SetUp()
		{
			_uriResolver = MockRepository.GenerateStub<IUriResolver>();
			var communicationContext = MockRepository.GenerateStub<ICommunicationContext>();
			_basketHandler = new BasketHandler(_uriResolver, communicationContext);
		}

		private void StubCreateGetBasketUriToReturn(Uri uri)
		{
			_uriResolver.Stub(ur => ur.CreateUriFor(Arg<Uri>.Is.Anything, Arg<object>.Is.Anything, Arg<string>.Is.Anything, Arg<NameValueCollection>.Is.Anything)).Return(uri);
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
		public void Create_calls_UriResolver_to_get_the_resource_location_for_the_new_basket()
		{
			_basketHandler.Create();

			_uriResolver.AssertWasCalled(ur => ur.CreateUriFor(Arg<Uri>.Is.Anything, Arg<object>.Is.Anything, Arg<string>.Is.Anything, Arg<NameValueCollection>.Is.Anything));
		}
	}
}
