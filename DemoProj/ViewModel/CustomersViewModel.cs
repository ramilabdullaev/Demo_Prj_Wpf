using DemoProj.Data;
using DemoProj.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProj.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private Customer? selectedCustomer;

        public event PropertyChangedEventHandler? PropertyChanged;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<Customer> Customers { get; set; } = new();

        public Customer? SelectedCustomer 
        { 
            get => selectedCustomer;
            set 
            { 
                selectedCustomer = value;
                RaisePropertyChanged();
            }
        }

        public async Task LoadAsync()
        {
            if (Customers.Any()) return;
                        
            var customer = await _customerDataProvider.GetCustomersAsync();

            if (customer is not null)
            {
                foreach (var customerItem in customer)
                {
                    Customers.Add(customerItem);

                }
            }
        }

        public async Task Add()
        {
            var customer = new Customer { FirstName = "New" };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        public async Task Delete()
        {
            if (SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }
    }
}