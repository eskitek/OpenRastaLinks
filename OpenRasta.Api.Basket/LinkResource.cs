using System.Xml.Serialization;

namespace OpenRasta.Api.Basket
{
	[XmlRoot(ElementName = "link")]
	public class LinkResource
	{
		public string Relation { get; set; }

		public string Uri { get; set; }
	}
}