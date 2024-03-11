using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        CustomerRepository custRepository;

        public CustomerService()
        {
            custRepository = new CustomerRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public CustomerDetail GetCustomerDetail(int custId)
        {
            return custRepository.GetCustomerDetail(custId);
        }

        public List<GetAllCustomersDetails> GetAllCustomersDetails(string serach)
        {
            return custRepository.GetAllCustomersDetails(serach);
        }

        public int GetCustomerIdByUserId(int userId)
        {
            return custRepository.GetCustomerIdByUserId(userId);
        }

        public int InsertCustomer(CustomerDto customer)
        {
            Customer cust = new Customer()
            {
                UserId = customer.UserId,
                IsGuest = customer.IsGuest
            };

            return custRepository.InsertCustomer(cust);
        }

        public void UpdateCustomerProfile(CustomerDetail cust)
        {
            Customer customer = custRepository.GetCustomerById(cust.CustomerId);
            customer.DOB = cust.DOB;
            customer.Gender = cust.Gender;
            custRepository.UpdateCustomer();

            UserRepository userRepo = new UserRepository();
            User u = userRepo.GetUserbyId(cust.UserId.Value);
            u.Name = cust.Name;
            u.Email = cust.Email;
            u.Mobile = cust.Mobile;
            u.Address = cust.Address;
            userRepo.UpdateUser();

        }

        public void InsertCustomerRequest(CustomerRequestDTO reqDto)
        {
            CustomerRequest req = new CustomerRequest()
            {
               CustomerId=reqDto.CustomerId,
               Details=reqDto.Details
            };
            custRepository.InsertCustomerRequest(req);
        }

        public List<CustomerRequestDetail> GetAllCustomerRequets()
        {
            return custRepository.GetAllCustomerRequets();
        }
        public int DeleteCustomer(int id)
        {
            return custRepository.DeleteCustomer(id);
        }
    }
}
