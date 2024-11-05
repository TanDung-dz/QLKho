using QLKho.Models;

namespace QLKho.ViewModels
{
	public class UserViewModel
	{
		public List<Menu> Menus { get; set; }
		public Customer Register { get; set; }
		public Employee e_Register { get; set; }
		public UserViewModel()
		{
			Register = new Customer();
			e_Register = new Employee();
		}

	}
}
