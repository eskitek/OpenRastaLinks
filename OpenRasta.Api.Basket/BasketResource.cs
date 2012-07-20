using System.Xml.Serialization;

namespace OpenRasta.Api.Basket
{
	[XmlRoot(ElementName = "basket")]
	public class BasketResource
	{
		public int Id { get; set; }

		public LinkResource SelfLink { get; set; }
	}
}