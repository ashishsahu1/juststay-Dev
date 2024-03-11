using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class RatingRepository
    {
        juststayDbEntities entities;

        public RatingRepository()
        {
            entities = new juststayDbEntities();
        }
        public void InsertRating(Rating rate)
        {
            rate.InsertedOn = DateTime.Now;
            entities.Ratings.Add(rate);
            entities.SaveChanges();
        }
        public List<Rating> GetAllRating(int atrcid)
        {
            return (from rat in entities.Ratings where rat.ATRCId == atrcid select rat).OrderByDescending(a => a.RatingId).Take(10).ToList();
        }
    }
}
