using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILocationService" in both code and config file together.
[ServiceContract]
public interface ILocationService
{
    [OperationContract]
    int InsertLocation(LocationDto location);

    [OperationContract]
    LocationDto GetLocationbyId(int lid);

    [OperationContract]
    int UpdateLocation(LocationDto location);

    [OperationContract]
    List<LocationDto> LocationList(int cityid);

    [OperationContract]
    int DeleteLocation(int id);

}

