namespace QLKho.ViewModels
{
	public class CategoryViewModel
	{
		public int CategoryId { get; set; }

		public string? Name { get; set; }

		public string? Description { get; set; }

		public string? Image { get; set; }

		public DateTime? AddDate { get; set; }

		public DateTime? UpdateDate { get; set; }

		public int? Order { get; set; }

		public string? Link { get; set; }

		public bool? Hide { get; set; }
	}
}
