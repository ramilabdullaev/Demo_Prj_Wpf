using DemoProj.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoProj.Data
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }

    public class CustomerDataProvider : ICustomerDataProvider
    {
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            await Task.Delay(100);

            return new List<Customer>
            {
                new Customer {Id=1, FirstName = "John", LastName = "Wick"},
                new Customer {Id=2, FirstName = "Bruce", LastName = "Wayne"},
                new Customer {Id=3, FirstName = "Tony", LastName = "Stark"}
            };
        }
    }
}
