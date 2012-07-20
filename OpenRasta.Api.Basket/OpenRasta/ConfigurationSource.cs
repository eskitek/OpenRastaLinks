using OpenRasta.Configuration;

namespace OpenRasta.Api.Basket.OpenRasta
{
	public class ConfigurationSource : IConfigurationSource
	{
		public void Configure()
		{
			using (OpenRastaConfiguration.Manual)
			{
				ResourceSpace.Has.ResourcesOfType<BasketResource>()
					.AtUri("/Basket")
					.And.AtUri("/Basket/{id}")
					.HandledBy<BasketHandler>()
					.AsXmlSerializer();
			}
		}
	}
}