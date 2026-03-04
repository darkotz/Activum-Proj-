
using PRG1_MAUI_ERP_Activum.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace PRG1_MAUI_ERP_Activum.Services
{
    public class RegisterService
    {
        private static RegisterService? _instance;
        public static RegisterService Instance => _instance ??= new RegisterService();

        public ObservableCollection<Customer> Customers { get; }
        public ObservableCollection<Insurance> Insurances { get; }

        private RegisterService()
        {
            Customers = new ObservableCollection<Customer>();
            Insurances = new ObservableCollection<Insurance>();
        }

        public Customer? GetCustomer(Guid id) => Customers.FirstOrDefault(c => c.Id == id);
        public Insurance? GetInsurance(Guid id) => Insurances.FirstOrDefault(i => i.Id == id);

        public IEnumerable<Insurance> GetInsurancesForCustomer(Customer customer) =>
            Insurances.Where(i => customer.InsuranceId.Contains(i.Id));

        public void LinkInsurance(Customer customer, Insurance insurance)
        {
            if (!customer.InsuranceId.Contains(insurance.Id))
                customer.InsuranceId.Add(insurance.Id);
        }

        public void UnlinkInsurance(Customer customer, Insurance insurance)
        {
            customer.InsuranceId.Remove(insurance.Id);
        }

        public void AddCustomer(Customer customer) {

            if (!Customers.Any(c => c.Email == customer.Email))
                Customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer) => Customers.Remove(customer);
    }
}