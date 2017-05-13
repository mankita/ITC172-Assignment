using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Community_Assist" in code, svc and config file together.

public class Community_Assist : ICommunity_AssistService
{
    Community_AssistEntities db = new Community_AssistEntities();

    //login and PersonKey

    public int Login(string email, string password)
    {
        //just like the login we did in the last assignment
        int key = 0;
        int result = db.usp_Login(email, password);
        if (result != -1)
        {
            var userKey = (from p in db.People
                           where p.PersonEmail.Equals(email)
                           select p.PersonKey).FirstOrDefault();
            key = (int)userKey;

            
        }

        return key;
    }

    // register new user

    public bool RegisterPerson(string lastname, string firstname, string email, string password,
     string ApartmentNumber, string Street, string City, string State, string ZipCode,
     string HomePhone, string WorkPhone)
    {
        bool result = true;
        int pers = db.usp_Register(lastname, firstname, email, password, ApartmentNumber, Street, City, State, ZipCode, HomePhone, WorkPhone);
        return result;

    }

    public int RequestGrant(int GrantTypeKey, string GrantRequestExplanation, decimal GrantRequestAmount, int PersonKey)
    {
        GrantRequest grantRequest = new GrantRequest();
        grantRequest.GrantRequestDate = DateTime.Now;
        grantRequest.GrantRequestAmount = GrantRequestAmount;
        grantRequest.GrantTypeKey = GrantTypeKey;
        grantRequest.PersonKey = PersonKey;
        grantRequest.GrantRequestExplanation = GrantRequestExplanation;

        var result = db.GrantRequests.Add(grantRequest);
        db.SaveChanges();

        GrantReview addentry = new GrantReview();
        addentry.GrantReviewDate = DateTime.Now;
        addentry.GrantRequestStatus = "Pending";
        addentry.GrantAllocationAmount = GrantRequestAmount;
        addentry.GrantRequestKey = result.GrantRequestKey;

        db.GrantReviews.Add(addentry);
        db.SaveChanges();
           
        return result.GrantRequestKey;
     }

    public List<GrantRequest> ViewGrants (int PersonKey)
    {

        List<GrantRequest> queryResult = (from g in db.GrantRequests
                      where g.PersonKey == PersonKey
                      select g).ToList<GrantRequest>();

        List<GrantRequest> resultList = new List<GrantRequest>();

        foreach(GrantRequest request in queryResult)
        {
            GrantRequest g = new GrantRequest();
            g.GrantRequestAmount = request.GrantRequestAmount;
            g.GrantRequestDate = request.GrantRequestDate;
            g.GrantRequestExplanation = request.GrantRequestExplanation;
            g.GrantRequestKey = request.GrantRequestKey;
            g.PersonKey = request.PersonKey;
            g.GrantTypeKey = request.GrantTypeKey;

            resultList.Add(g);
        }

        return resultList;

    }

    

}

