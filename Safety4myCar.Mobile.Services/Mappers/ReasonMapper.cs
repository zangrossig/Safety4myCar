using Safety4myCar.Mobile.Models;
using Safety4myCar.Mobile.Repositories.Models;

namespace Safety4myCar.Mobile.Services.Mappers
{
	public static class ReasonMapper
	{
		public static IEnumerable<Reason> Map(IEnumerable<ReasonDto> reasons)
		{
			return reasons.Select(x => new Reason
			{
				Id = x.Id,
				Code = x.Codice!,
				Description = x.Descrizione!,
				RegistrationType = GetRegistrationType(x.Tipo),
				Selectable = x.Selezionabile
			});
		}

		private static RegistrationType GetRegistrationType(int tipo)
		{
			var result = RegistrationType.Fuel;
			switch (tipo)
			{
				case 10:
					result = RegistrationType.Administrative;
					break;

				case 20:
					result = RegistrationType.Fuel;
					break;

				case 30:
				case 40:
					result = RegistrationType.Maintenance;
					break;

				default:
					break;
			}

			return result;
		}
	}
}