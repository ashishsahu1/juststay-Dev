using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITaxService" in both code and config file together.
    [ServiceContract]
    public interface ITaxService
    {
        [OperationContract]
        List<TaxDto> GetAllTaxes();

        [OperationContract]
        TaxDto GetTaxById(int taxId);

        [OperationContract]
        void InsertTax(TaxDto tax);

        [OperationContract]
        void UpdateTax(TaxDto taxDto);

        [OperationContract]
        void DeleteTax(int id);
    }
}
