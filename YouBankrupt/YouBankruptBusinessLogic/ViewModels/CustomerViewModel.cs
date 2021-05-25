using System.ComponentModel;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Имя")]
        public string CustomerFullName { get; set; }

        [DisplayName("Почта")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
