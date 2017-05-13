using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommunity_Assist" in both code and config file together.
[ServiceContract]
public interface ICommunity_AssistService
{
    [OperationContract]
    int Login(string email, string password);

    [OperationContract]
    bool RegisterPerson(string lastname, string firstname, string email, string password,
     string ApartmentNumber, string Street, string City, string State, string ZipCode,
     string HomePhone, string WorkPhone);

    [OperationContract]
     int RequestGrant(int GrantTypeKey, string GrantReuestExplanation, decimal GrantRequestAmount, int PersonKey);

    [OperationContract]
    List<GrantRequest> ViewGrants(int PersonKey);
}
