﻿using Safety4myCar.Mobile.Models.Configuration;

namespace Safety4myCar.Mobile.Services.Shared
{
	public interface IConfigurationService
	{
		ConfigurationData Data { get; }

		void Clear();

		Task Load();

		Task Save();
	}
}