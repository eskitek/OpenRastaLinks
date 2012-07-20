using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using NUnit.Framework;

namespace OpenRasta.Api.Basket.Unit.Tests
{
	[TestFixture]
	public class LinkResourceXmlSerialisationTests
	{
		private static XDocument SerialiseLink(LinkResource linkResource)
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
			var linkXml = SerialiseLink(new LinkResource());
			Assert.That(linkXml.Root.Name.LocalName, Is.EqualTo("link"));
		}
	}
}