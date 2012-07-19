using System.Net;
using NUnit.Framework;

namespace OpenRasta.Api.Basket.Tests
{
	[TestFixture]
	public class CreateBasketTests
	{
		[Test]
		public void When_I_call_the_create_basket_endpoint_I_get_a_201_Created_response()
		{
			var httpRequest = WebRequest.Create("http://localhost/OpenRasta.Api.Basket/Basket");
			httpRequest.Method = "POST";
			httpRequest.ContentLength = 0;

			var response = (HttpWebResponse)httpRequest.GetResponse();

			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
		}

		[Test]
		public void When_I_call_the_create_basket_endpoint_the_response_contains_a_location_header()
		{
			var httpRequest = WebRequest.Create("http://localhost/OpenRasta.Api.Basket/Basket");
			httpRequest.Method = "POST";
			httpRequest.ContentLength = 0;

			var response = (HttpWebResponse)httpRequest.GetResponse();

			Assert.That(response.Headers["Location"], Is.Not.Null);
		}
	}
}