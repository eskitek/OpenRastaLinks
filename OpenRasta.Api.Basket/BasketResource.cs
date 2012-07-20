﻿using System.Xml.Serialization;

namespace OpenRasta.Api.Basket
{
	[XmlRoot(ElementName = "basket")]
	public class BasketResource
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		public LinkResource SelfLink { get; set; }
	}
}