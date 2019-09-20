using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using RestSharp;

namespace AgentBookVue.Models
{
    public class Bookings
    {
        public int id { get; set; }
        string urlAPI = "https://www.majesticfastferry.com.sg:44326/MFFInternalWebservice/";

      

        public object getJourney()
        {


            //string url = "https://jsonplaceholder.typicode.com/posts/1/comments";
            //using (var client = new WebClient())
            //{
            //    var content = client.DownloadString(url);
            //    var serializer = new JavaScriptSerializer();
            //    var jsonContent = serializer.Deserialize<object>(content);
            //    return jsonContent;


            //}


            string url = urlAPI;
            var client = new RestClient(url);
            var request = new RestRequest("MFFINJourney", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("Username", "kioskhbfmff1");
            request.AddParameter("SecurityKey", "mffhbfkiosk");


            var content = client.Execute(request).Content;
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<object>(content);
            return jsonContent;




        }
        public object GetSchedule(string TotalPax, string JourneyType, string IsReturnOpenTicket, string DepartPort, string ArrivalPort, string TravelDate, string ReturnDepartPort, string ReturnArrivalPort, string ReturnTravelDate)
        {
            string url = urlAPI;
            var client = new RestClient(url);
            var request = new RestRequest("MFFINSchedule", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("Username", "kioskhbfmff1");
            request.AddParameter("SecurityKey", "mffhbfkiosk");
            request.AddParameter("TotalPax", TotalPax);
            request.AddParameter("JourneyType", JourneyType);
            request.AddParameter("IsReturnOpenTicket", IsReturnOpenTicket);
            request.AddParameter("DepartPort", DepartPort);
            request.AddParameter("ArrivalPort", ArrivalPort);
            request.AddParameter("TravelDate", TravelDate);
            request.AddParameter("ReturnDepartPort", ReturnDepartPort);
            request.AddParameter("ReturnArrivalPort", ReturnArrivalPort);
            request.AddParameter("ReturnTravelDate", ReturnTravelDate);


            var content = client.Execute(request).Content;
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<object>(content);
            return jsonContent;
        }
        public object getCountryList()
        {
            string url = urlAPI;
            var client = new RestClient(url);
            var request = new RestRequest("MFFINCountryList", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("Username", "kioskhbfmff1");
            request.AddParameter("SecurityKey", "mffhbfkiosk");

            var content = client.Execute(request).Content;
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<object>(content);
            return jsonContent;
        }
    }
}