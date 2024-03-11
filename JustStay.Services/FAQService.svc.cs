using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FAQService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FAQService.svc or FAQService.svc.cs at the Solution Explorer and start debugging.
    public class FAQService : IFAQService
    {
        FAQRepository faqRepository;

        public FAQService()
        {
            faqRepository = new FAQRepository();
        }

        public List<FAQDto> GetFAQByAudience(int audId)
        {
            var faqlist = faqRepository.GetFAQByAudience(audId);
            if (faqlist == null) return null;

            List<FAQDto> faqDtoList =
            faqlist.ConvertAll(x => new FAQDto
            {
                FAQId= x.FAQId,
                FAQAudienceId = x.FAQAudienceId,
                Question = x.Question,
                Answer = x.Answer,
                Sequence = x.Sequence,
                InsertedOn = x.InsertedOn
            });

            return faqDtoList;
        }

        public FAQDto GetFAQById(int id)
        {
            FAQ faq = faqRepository.GetFAQById(id);
            FAQDto dto = new FAQDto();
            FillFAQDto(faq, dto);
            return dto;
        }

        public void InsertFAQ(FAQDto faqDto)
        {
            FAQ faq = new FAQ();
            FillFAQ(faq, faqDto);
            faqRepository.InsertFAQ(faq);
        }

        public void UpdateFAQ(FAQDto faqDto)
        {
            FAQ faq = faqRepository.GetFAQById(faqDto.FAQId);
            FillFAQ(faq, faqDto);
            faqRepository.UpdateFAQ(faq);
        }

        public void DeleteFAQ(int id)
        {
            faqRepository.DeleteFAQ(id);
        }

        private void FillFAQ(FAQ faq, FAQDto faqDto)
        {
            faq.FAQAudienceId = faqDto.FAQAudienceId;
            faq.Question = faqDto.Question;
            faq.Answer = faqDto.Answer;
            faq.Sequence = faqDto.Sequence;
        }

        private void FillFAQDto(FAQ faq, FAQDto faqDto)
        {
            faqDto.FAQId = faq.FAQId;
            faqDto.FAQAudienceId = faq.FAQAudienceId;
            faqDto.Question = faq.Question;
            faqDto.Answer = faq.Answer;
            faqDto.Sequence = faq.Sequence;
            faqDto.InsertedOn = faq.InsertedOn;
        }
    }

