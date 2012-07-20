using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using NUnit.Framework;

namespace OpenRasta.Api.Basket.Unit.Tests
{
	[TestFixture]
	public class LinkResourceXmlSerialisationTests
	{
		private static XDocument Serialise(LinkResource linkResource)
		{
			var xmlSerialiser = new XmlSerializer(typeof(LinkResource));
			using (var sw = new StringWriter())
			{
				xmlSerialiser.Serialize(sw, linkResource);
				return XDocument.Parse(sw.ToString());
			}
		}

		[Test]
		public void Root_element_is_named_link()
		{
			var linkXml = Serialise(new LinkResource());
			Assert.That(linkXml.Root.Name.LocalName, Is.EqualTo("link"));
		}

		[Test]
		public void Link_element_has_an_attribute_named_rel()
		{
			var linkXml = Serialise(new LinkResource { Relation = "something" });
			Assert.That(linkXml.Root.Attribute("rel"), Is.Not.Null);
		}

		[Test]
		public void Rel_is_populated_with_correct_value()
		{
			const string relation = "something";
			var linkXml = Serialise(new LinkResource { Relation = relation });
			Assert.That(linkXml.Root.Attribute("rel").Value, Is.EqualTo(relation));
		}
	}
}