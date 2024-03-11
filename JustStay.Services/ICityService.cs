using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICityService" in both code and config file together.
    [ServiceContract]
    public interface ICityService
    {
        [OperationContract]
        int InsertCity(CityDto city);

        [OperationContract]
        CityDto GetCitybyId(int cid);

        [OperationContract]
        int UpdateCity(CityDto Cty);

        [OperationContract]
        List<CityDto> CityList(string mode);

        [OperationContract]
        int DeleteCity(int id);

    }

