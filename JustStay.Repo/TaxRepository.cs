using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class TaxRepository
    {
        juststayDbEntities entities;

        public TaxRepository()
        {
            entities = new juststayDbEntities();
        }

        public List<Tax> GetAllTaxes()
        {
            return entities.Taxes.ToList();
        }

        public Tax GetTaxById(int id)
        {
            return entities.Taxes.FirstOrDefault(c => c.TaxId == id);
        }

        public void InsertTax(Tax tax)
        {
            entities.Taxes.Add(tax);
            entities.SaveChanges();
        }

        public void UpdateTax()
        {
            entities.SaveChanges();
        }

        public void DeleteTax(int id)
        {
            var tax = entities.Taxes.FirstOrDefault(x => x.TaxId == id);
            entities.Taxes.Remove(tax);
            entities.SaveChanges();
        }

    }
}
