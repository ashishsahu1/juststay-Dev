using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class ErrorLogRepository
    {
        juststayDbEntities entities;
        public ErrorLogRepository()
        {
            entities = new juststayDbEntities();
        }
        public void InsertErrorLog(ErrorLog error)
        {
            entities.ErrorLogs.Add(error);
            entities.SaveChanges();
        }
    }
}
