using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using NUnit.Framework;

namespace OpenRasta.Api.Basket.Unit.Tests
{
	[TestFixture]
	public class BasketResourceXmlSerialisationTests
	{
		private static XDocument SerialiseBasket(BasketResource basketResource)
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
			var basketXml = SerialiseBasket(new BasketResource());
			Assert.That(basketXml.Root.Name.LocalName, Is.EqualTo("basket"));
		}

		[Test]
		public void Basket_element_has_an_attribute_named_id()
		{
			var basketXml = SerialiseBasket(new BasketResource());
			Assert.That(basketXml.Root.Attribute("id"), Is.Not.Null);
		}

		[Test]
		public void Id_is_populated_with_correct_value()
		{
			const int expected = 433;
			var basketXml = SerialiseBasket(new BasketResource { Id = expected });
			Assert.That(basketXml.Root.Attribute("id").Value, Is.EqualTo(expected.ToString()));
		}
	}
}