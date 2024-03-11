using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using JustStay.Repo;
using JustStay.Services.DTO;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompanyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompanyService.svc or CompanyService.svc.cs at the Solution Explorer and start debugging.
    public class CompanyService : ICompanyService
    {
        CompanyRepository compRepo;
        public CompanyService()
        {
            compRepo = new CompanyRepository();
        }
        public CompanyDto GetCompany()
        {
            Company comp = compRepo.GetCompany();
            CompanyDto compdto = new CompanyDto();
            compdto.Address = comp.Address;
            compdto.CIN = comp.CIN;
            compdto.City = comp.City;
            compdto.CompanyId = comp.CompanyId;
            compdto.CompanyName = comp.CompanyName;
            compdto.Contact = comp.Contact;
            compdto.Email = comp.Email;
            compdto.GSTIN = comp.GSTIN;
            compdto.InsertedOn = comp.InsertedOn;
            compdto.LandLine = comp.LandLine;
            compdto.Mobile = comp.Mobile;
            compdto.PAN = comp.PAN;
            compdto.PinCode = comp.PinCode;
            compdto.State = comp.State;
            compdto.Subheading = comp.Subheading;
            compdto.UpdatedOn = comp.UpdatedOn;
            compdto.Website = comp.Website;

            return compdto;
        }
        public int UpdateCompany(CompanyDto Compdto)
        {
            Company cmpy = new Company();
            cmpy.Address = Compdto.Address;
            cmpy.CIN = Compdto.CIN;
            cmpy.City = Compdto.City;
            cmpy.CompanyId = Compdto.CompanyId;
            cmpy.CompanyName = Compdto.CompanyName;
            cmpy.Contact = Compdto.Contact;
            cmpy.Email = Compdto.Email;
            cmpy.GSTIN = Compdto.GSTIN;
            cmpy.LandLine = Compdto.LandLine;
            cmpy.Mobile = Compdto.Mobile;
            cmpy.PAN = Compdto.PAN;
            cmpy.PinCode = Compdto.PinCode;
            cmpy.State = Compdto.State;
            cmpy.Subheading = Compdto.Subheading;
            cmpy.UpdatedOn = Compdto.UpdatedOn;
            cmpy.Website = Compdto.Website;
           return compRepo.UpdateCompany(cmpy);
        }
    }
}
