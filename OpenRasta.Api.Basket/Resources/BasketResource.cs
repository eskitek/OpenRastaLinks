using System.Xml.Serialization;

namespace OpenRasta.Api.Basket.Resources
{
	[XmlRoot(ElementName = "basket")]
	public class BasketResource
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlElement("link")]
		public LinkResource SelfLink { get; set; }
	}
}