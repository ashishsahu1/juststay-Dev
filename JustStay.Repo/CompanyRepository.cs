using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class CompanyRepository
    {
        juststayDbEntities entities;
        public CompanyRepository()
        {
            entities = new juststayDbEntities();
        }
        public Company GetCompany()
        {
            return entities.Companies.FirstOrDefault();
        }
        public int UpdateCompany(Company Comp)
        {
            Company c = entities.Companies.FirstOrDefault(info => info.CompanyId == Comp.CompanyId);
            if (c == null) return 0;

            c.Address = Comp.Address;
            c.CIN = Comp.CIN;
            c.City = Comp.City;
            c.CompanyName = Comp.CompanyName;
            c.Contact = Comp.Contact;
            c.Email = Comp.Email;
            c.GSTIN = Comp.GSTIN;
            c.UpdatedOn = DateTime.Now;
            c.Website = Comp.Website;
            c.LandLine = Comp.LandLine;
            c.Mobile = Comp.Mobile;
            c.PAN = Comp.PAN;
            c.PinCode = Comp.PinCode;
            c.State = Comp.State;
            c.Subheading = Comp.Subheading;
           
            entities.SaveChanges();
            return c.CompanyId;
        }
    }
}
