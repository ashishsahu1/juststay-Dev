using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class CustomerRepository
    {
        juststayDbEntities entities;

        public CustomerRepository()
        {
            entities = new juststayDbEntities();
        }

        public Customer GetCustomerById(int id)
        {
            return entities.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public CustomerDetail GetCustomerDetail(int custId)
        {
            return entities.GetCustomerDetail(custId).FirstOrDefault();
        }

        public List<GetAllCustomersDetails> GetAllCustomersDetails(string search)
        {
            return entities.GetAllCustomersDetails(search).ToList();
        }       

        public int GetCustomerIdByUserId(int userId)
        {
            var customer = entities.Customers.FirstOrDefault(i => i.UserId == userId);
            return (customer != null ? customer.CustomerId : 0);
        }
       
        public int InsertCustomer(Customer customer)
        {
            customer.InsertedOn = DateTime.Now;
            entities.Customers.Add(customer);
            entities.SaveChanges();
            return customer.CustomerId;
        }

        public void UpdateCustomer()
        {
            entities.SaveChanges();
        }

        #region " Customer Request "

        public void InsertCustomerRequest(CustomerRequest req)
        {
            req.InsertedOn = DateTime.Now;
            entities.CustomerRequests.Add(req);
            entities.SaveChanges();
        }

        public List<CustomerRequestDetail> GetAllCustomerRequets()
        {
            return entities.GetAllCustomerRequests().ToList();
        }
        public int DeleteCustomer(int id)
        {
            return Convert.ToInt32(entities.SP_Delete(id, "Cust"));
        }
        #endregion
    }
}
