using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using NUnit.Framework;

namespace OpenRasta.Api.Basket.Unit.Tests
{
	[TestFixture]
	public class BasketResourceXmlSerialisationTests
	{
		[Test]
		public void Root_element_is_named_basket()
		{
			var xmlSerialiser = new XmlSerializer(typeof(BasketResource));
			using (var sw = new StringWriter())
			{
				var basketResource = new BasketResource();
				xmlSerialiser.Serialize(sw, basketResource);
				var serialisedBasket = sw.ToString();
				var basketXml = XDocument.Parse(serialisedBasket);
				Assert.That(basketXml.Root.Name.LocalName, Is.EqualTo("basket"));
			}
		}
	}
}