using Assignment.Entites;
using Assignment.Models;
using Assignment.Repostitories;

namespace Assignment.Services;

internal class CustomerService
{
    private readonly AddressRepository _addressRepository;
    private readonly CustomserRepository _customerRepository;

    public CustomerService(AddressRepository addressRepository, CustomserRepository customerRepository)
    {
        _addressRepository = addressRepository;
        _customerRepository = customerRepository;
    }

    public async Task<bool> CreateCustomerAsync(CustomerRegistration form)
    {
        if (await _customerRepository.ExistsAsync(x => x.Email == form.Email))
        {
            var addressEntity = await _addressRepository.GetAsync(x => x.StreetName == form.StreetName && x.PostalCode == form.PostalCode);

            addressEntity ??= await _addressRepository.CreateAsync(new AddressEntity { StreetName = form.StreetName, PostalCode = form.PostalCode, City = form.City });

            CustomerEntity customerEntity = await _customerRepository.CreateAsync(new CustomerEntity { FirstName = form.FirstName, LastName = form.LastName, Email = form.Email, AddressId = addressEntity.Id});

            if (customerEntity != null)
                return true;
        }

        return false;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers;
    }
}
