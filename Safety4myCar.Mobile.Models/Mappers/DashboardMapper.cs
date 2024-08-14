using Safety4myCar.Mobile.Models.Dto.Summary;
using Safety4myCar.Mobile.Models.Summary;

namespace Safety4myCar.Mobile.Models.Mappers
{
	public static class DashboardMapper
	{
		public static IEnumerable<DashboardSummary> Map(IEnumerable<DashboardSummaryDto> dto)
		{
			var result = new List<DashboardSummary>();

			foreach (var dtoItem in dto)
			{
				var item = new DashboardSummary
				{
					AutomezzoId = dtoItem.AutomezzoId,
					Automezzo = dtoItem.Automezzo,
					Consumo = dtoItem.Consumo,
					ImportoSpese = dtoItem.ImportoSpese,
					NumeroRegistrazioni = dtoItem.NumeroRegistrazioni,
					Percorrenza = dtoItem.Percorrenza,
					SpesaPerKm = dtoItem.SpesaPerKm
				};
				result.Add(item);
			}

			return result;
		}
	}
}