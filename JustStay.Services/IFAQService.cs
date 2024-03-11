using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFAQService" in both code and config file together.
    [ServiceContract]
    public interface IFAQService
    {
        [OperationContract]
        List<FAQDto> GetFAQByAudience(int audId);

        [OperationContract]
        FAQDto GetFAQById(int id);

        [OperationContract]
        void InsertFAQ(FAQDto faqDto);

        [OperationContract]
        void UpdateFAQ(FAQDto faqDto);

        [OperationContract]
        void DeleteFAQ(int id);
    }

