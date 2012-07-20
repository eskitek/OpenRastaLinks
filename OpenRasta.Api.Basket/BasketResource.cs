using System.Runtime.Serialization;

namespace OpenRasta.Api.Basket
{
	[DataContract(Name = "Basket", Namespace = "")]
	public class BasketResource
	{
		[DataMember(Name = "Id")]
		public int Id { get; set; }

		[DataMember(Name = "link")]
		public LinkResource SelfLink { get; set; }
	}
}