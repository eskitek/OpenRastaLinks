using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using NUnit.Framework;
using OpenRasta.Api.Basket.Resources;

namespace OpenRasta.Api.Basket.Unit.Tests
{
	[TestFixture]
	public class BasketResourceXmlSerialisationTests
	{
		private static XDocument Serialise(BasketResource basketResource)
		{
			var xmlSerialiser = new XmlSerializer(typeof(BasketResource));
			using (var sw = new StringWriter())
			{
				xmlSerialiser.Serialize(sw, basketResource);
				var serialisedBasket = sw.ToString();
				return XDocument.Parse(serialisedBasket);
			}
		}

		[Test]
		public void Root_element_is_named_basket()
		{
			var basketXml = Serialise(new BasketResource());
			Assert.That(basketXml.Root.Name.LocalName, Is.EqualTo("basket"));
		}

		[Test]
		public void Basket_element_has_an_attribute_named_id()
		{
			var basketXml = Serialise(new BasketResource());
			Assert.That(basketXml.Root.Attribute("id"), Is.Not.Null);
		}

		[Test]
		public void Id_is_populated_with_correct_value()
		{
			const int expected = 433;
			var basketXml = Serialise(new BasketResource { Id = expected });
			Assert.That(basketXml.Root.Attribute("id").Value, Is.EqualTo(expected.ToString()));
		}

		[Test]
		public void Basket_element_has_a_self_link_element()
		{
			var selfLink = new LinkResource { Relation = "self", Uri = "doody"};
			var basket = new BasketResource { SelfLink = selfLink };

			var basketXml = Serialise(basket);
			
			var selfLinkElement = basketXml.Root.Elements("link").Where(l => l.Attribute("rel").Value == "self").Single();
			Assert.That(selfLinkElement, Is.Not.Null);

			var selfLinkUriAttribute = selfLinkElement.Attribute("uri").Value;
			Assert.That(selfLinkUriAttribute, Is.EqualTo(selfLink.Uri));
		}
	}
}