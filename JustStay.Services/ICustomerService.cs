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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        CustomerDetail GetCustomerDetail(int custId);

        [OperationContract]
        List<GetAllCustomersDetails> GetAllCustomersDetails(string serach);

        [OperationContract]
        int GetCustomerIdByUserId(int userId);

        [OperationContract]
        int InsertCustomer(CustomerDto customer);

        [OperationContract]
        void UpdateCustomerProfile(CustomerDetail cust);

        [OperationContract]
        void InsertCustomerRequest(CustomerRequestDTO reqDto);

        [OperationContract]
        List<CustomerRequestDetail> GetAllCustomerRequets();

        [OperationContract]
        int DeleteCustomer(int id);

       
    }
}
