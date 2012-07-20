using System;
using System.IO;
using System.Net;
using System.Xml.Linq;
using NUnit.Framework;

namespace OpenRasta.Api.Basket.Tests
{
	[TestFixture]
	public class CreateBasketTests
	{
		private const string CreateBasketUri = "http://localhost/OpenRasta.Api.Basket/Basket";

		private static HttpWebResponse GetCreateBasketResponse(WebRequest httpRequest)
		{
			return (HttpWebResponse)httpRequest.GetResponse();
		}

		private static WebRequest CreateCreateBasketRequest()
		{
			var httpRequest = WebRequest.Create(CreateBasketUri);
			httpRequest.Method = "POST";
			httpRequest.ContentLength = 0;
			return httpRequest;
		}

		private static string GetResponseBody(HttpWebResponse response)
		{
			string responseBody;
			using (var responseStream = response.GetResponseStream())
			{
				using (var reader = new StreamReader(responseStream))
				{
					responseBody = reader.ReadToEnd();
				}
			}
			return responseBody;
		}

		[Test]
		public void When_I_call_the_create_basket_endpoint_I_get_a_201_Created_response()
		{
			var request = CreateCreateBasketRequest();

			var response = GetCreateBasketResponse(request);

			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
		}

		[Test]
		public void When_I_call_the_create_basket_endpoint_the_response_contains_a_location_header()
		{
			var request = CreateCreateBasketRequest();

			var response = GetCreateBasketResponse(request);

			Assert.That(response.Headers["Location"], Is.Not.Null);
		}

		[Test]
		public void When_I_call_the_create_basket_endpoint_the_response_contains_a_response_body()
		{
			var request = CreateCreateBasketRequest();

			var response = GetCreateBasketResponse(request);

			var responseBody = GetResponseBody(response);
			Assert.IsNotNullOrEmpty(responseBody, "Response Body");
		}

		[Test]
		public void When_I_call_the_create_basket_endpoint_the_response_contains_a_location_header_pointing_to_the_new_basket_resource()
		{
			var request = CreateCreateBasketRequest();

			var response = GetCreateBasketResponse(request);

			var locationHeader = response.Headers["Location"];

			var responseBody = GetResponseBody(response);
			var xDocument = XDocument.Parse(responseBody);
			var newBasketId = Int32.Parse(xDocument.Root.Element("Id").Value);

			const string getBasketUriTemplate = "http://localhost/OpenRasta.Api.Basket/Basket/{0}";
			var getBasketUrl = string.Format(getBasketUriTemplate, newBasketId);
			Assert.That(locationHeader, Is.EqualTo(getBasketUrl));
		}
	}
}