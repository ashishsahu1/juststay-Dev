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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ErrorLogService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ErrorLogService.svc or ErrorLogService.svc.cs at the Solution Explorer and start debugging.
    public class ErrorLogService : IErrorLogService
    {
        ErrorLogRepository errorlogRepository;
        public ErrorLogService()
        {
            errorlogRepository = new ErrorLogRepository();
        }
        public void InsertErrorLog(ErrorLogDto erroelogDto)
        {
            ErrorLog log = new ErrorLog()
            {
                date = erroelogDto.date,
                error = erroelogDto.error,
                ErrorFrom = erroelogDto.ErrorFrom,
                eventname = erroelogDto.eventname,
                pagename = erroelogDto.pagename
            };
            errorlogRepository.InsertErrorLog(log);
        }
    }
}
