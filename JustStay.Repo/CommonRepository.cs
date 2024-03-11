using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class CommonRepository
    {
        juststayDbEntities entities;

        public CommonRepository()
        {
            entities = new juststayDbEntities();
        }

        public List<State> GetAllStates()
        {
            return entities.States.ToList();
        }

        public List<City> GetAllCities()
        {
            return entities.Cities.ToList();
        }
        public List<City> GetAllCitiesBySearch(string search)
        {
            return entities.Cities.Where(s =>s.Name.Contains(search)).ToList();
        }

        public List<Location> GetAlLocationsByCity(int cityId)
        {
            return entities.Locations.Where(l => l.CityId == cityId).ToList();
        }

        public List<ATRCCategory> GetAllATRCCategory()
        {
            return entities.ATRCCategories.Where(c => c.IsActive == true).ToList();
        }

        public List<ATRCSubCategory> GetAllATRCSubCategory(int categoryid)
        {
            return entities.ATRCSubCategories.Where(id => id.ATRCCategoryId == categoryid & id.IsActive == true).ToList();
        }

        public Setting GetSettings()
        {
            return entities.Settings.FirstOrDefault();
        }

        public SMSTemplate GetSMSTemplateByName(string name)
        {
            return entities.SMSTemplates.FirstOrDefault(s => s.Name == name);
        }

        public List<Localities> GetAutocompleteLocalities(string search)
        {
            return entities.GetAutocompleteLocalities(search).ToList();
        }       

        public List<ATRCType> GetATRCTypes()
        {
            return entities.ATRCTypes.ToList();
        }
        public void Delete(int id,string mode)
        {
            entities.SP_Delete(id, mode);
        }
    }
}
