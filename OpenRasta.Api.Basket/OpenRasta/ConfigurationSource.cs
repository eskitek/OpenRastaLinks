using OpenRasta.Configuration;

namespace OpenRasta.Api.Basket.OpenRasta
{
	public class ConfigurationSource : IConfigurationSource
	{
		public void Configure()
		{
			using (OpenRastaConfiguration.Manual)
			{
				ResourceSpace.Has.ResourcesOfType<object>()
					.AtUri("/Basket")
					.HandledBy<BasketHandler>();
			}
		}
	}
}