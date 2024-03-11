using AutoMapper;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TaxService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TaxService.svc or TaxService.svc.cs at the Solution Explorer and start debugging.
    public class TaxService : ITaxService
    {
        TaxRepository taxRepository;

        public  TaxService()
        {
            ATRCMapper.Initialize();
            taxRepository = new TaxRepository();
        }

        public List<TaxDto> GetAllTaxes()
        {
            var list = taxRepository.GetAllTaxes();

            return Mapper.Map<List<Tax>, List<TaxDto>>(list);
        }

        public TaxDto GetTaxById(int taxId)
        {
            Tax tax = taxRepository.GetTaxById(taxId);
            return Mapper.Map<Tax, TaxDto>(tax);
        }

        public void InsertTax(TaxDto tax)
        {
           taxRepository.InsertTax(Mapper.Map<TaxDto, Tax>(tax));
        }

        public void UpdateTax(TaxDto taxDto)
        {
            Tax tax = taxRepository.GetTaxById(taxDto.TaxId);
            Mapper.Map<TaxDto, Tax>(taxDto, tax);
            taxRepository.UpdateTax();
        }

        public void DeleteTax(int id)
        {
            taxRepository.DeleteTax(id);
        }

    }
}
