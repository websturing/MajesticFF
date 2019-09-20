using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgentBookVue.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AgentBookVue.Controllers
{
    public class BookingsController : Controller
    {
        // GET: Bookings Allbooking
        public ActionResult Allbooking()
        {
            return View();
        }
        //GET: bookingform
        public ActionResult BookingForm()
        {
            return View();
        }
        public JsonResult GetJourney(){
            var journey = new Bookings();
            return Json(journey.getJourney(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSchedule(string TotalPax, string JourneyType, string IsReturnOpenTicket, string DepartPort, string ArrivalPort, string TravelDateBC, string ReturnDepartPort, string ReturnArrivalPort, string ReturnTravelDateBC)
        {
            var TravelDate = Convert.ToDateTime(TravelDateBC).ToString("yyyy-MM-dd");
            var ReturnTravelDate = Convert.ToDateTime(ReturnTravelDateBC).ToString("yyyy-MM-dd");


            var journey = new Bookings();
            return Json(journey.GetSchedule(TotalPax, JourneyType, IsReturnOpenTicket, DepartPort, ArrivalPort, TravelDate, ReturnDepartPort, ReturnArrivalPort, ReturnTravelDate), JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult PendingBookingSubmit(string dataJSon)
        {

     
            var DirectoryDB = System.AppDomain.CurrentDomain.BaseDirectory + "databases";
            var FilesDB = System.AppDomain.CurrentDomain.BaseDirectory + "databases" + @"\databases.JSON";
            string Result;
            //write string to file

            if (System.IO.File.Exists(FilesDB))
            {


                var NewJson = JArray.Parse(dataJSon);

                var DataJson = System.IO.File.ReadAllText(FilesDB);

                dynamic jsonObj = JsonConvert.DeserializeObject(DataJson);

                var andi = jsonObj;
                string andiOuput = JsonConvert.SerializeObject(andi, Formatting.Indented);

                var array = JArray.Parse(andiOuput);

                array.Add(NewJson[0]);

                var jsonToOutput = JsonConvert.SerializeObject(array, Formatting.Indented);
                System.IO.File.WriteAllText(DirectoryDB + @"\databases.JSON", jsonToOutput);


                var newDataDB = System.IO.File.ReadAllText(FilesDB);
                dynamic objDes = JsonConvert.DeserializeObject(newDataDB);
                var ObjNew = objDes;


                var dataCount = JsonConvert.SerializeObject(objDes.Count, Formatting.Indented); ;
                Result = dataCount;

            }
            else
            {
                System.IO.File.WriteAllText(DirectoryDB + @"\databases.JSON", dataJSon);

      
                var newDataDB = System.IO.File.ReadAllText(FilesDB);
                dynamic objDes = JsonConvert.DeserializeObject(newDataDB);
                var ObjNew = objDes;


                var dataCount = JsonConvert.SerializeObject(objDes.Count, Formatting.Indented); ;
                Result = dataCount;

            }



            //var path1 = System.AppDomain.CurrentDomain.BaseDirectory + "databases" + @"\bookingsD_1.JSON";
            //var path2 = System.AppDomain.CurrentDomain.BaseDirectory + "databases" + @"\bookingsD_2.JSON";
            //var contents = System.IO.File.ReadAllText(path1).ToString();
            //var contents1 = System.IO.File.ReadAllText(path2).ToString();



            //var contentsyourObject = JsonConvert.SerializeObject(contents);
            //var contents1yourObject2 = JsonConvert.SerializeObject(contents1);
            //var andi = contents.concat(contents1);

            return Json(Result, JsonRequestBehavior.AllowGet);

        }


        //GET: PendingBooking
        public ActionResult PendingBooking(int id)
        {
            var book = new Bookings() { id = id };
            return View(book);

       
        }
        public JsonResult GetPendingBooking(string Id)
        {

            int NewId = int.Parse(Id) - 1;

            var booking = System.AppDomain.CurrentDomain.BaseDirectory + "databases" + @"\databases.JSON";
            var contents = System.IO.File.ReadAllText(booking);


            dynamic jsonObj = JsonConvert.DeserializeObject(contents);
            var PendingBookingData = jsonObj[NewId];

            string andiOuput = JsonConvert.SerializeObject(PendingBookingData, Formatting.Indented);

            return Json(andiOuput, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCountryList()
        {
            var journey = new Bookings();
            return Json(journey.getCountryList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPassanger()
        {
            var DirectoryDB = System.AppDomain.CurrentDomain.BaseDirectory + "databases";
            var booking = System.AppDomain.CurrentDomain.BaseDirectory + "databases" + @"\passanger.JSON";
            var contents = System.IO.File.ReadAllText(booking);

            var Ar = JArray.Parse(contents);

            var a = JsonConvert.SerializeObject(Ar, Formatting.Indented);

            return Json(a, JsonRequestBehavior.DenyGet);

        }

        public JsonResult AddPax(string id, string dataJson)
        {
            int NewId = int.Parse(id) - 1;
            var NewJson = JArray.Parse(dataJson);

            var DirectoryDB = System.AppDomain.CurrentDomain.BaseDirectory + "databases";
            var booking = System.AppDomain.CurrentDomain.BaseDirectory + "databases" + @"\databases.JSON";
            var contents = System.IO.File.ReadAllText(booking);


            dynamic jsonObj = JsonConvert.DeserializeObject(contents);



            var dataP = jsonObj[NewId]["passanger"];
            string andiOuput = JsonConvert.SerializeObject(dataP, Formatting.Indented);

            var array = JArray.Parse(andiOuput);

            var itemToAdd = new JObject();
            array.Add(NewJson[0]);

            jsonObj[NewId]["passanger"] = array;

            var jsonToOutput = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            System.IO.File.WriteAllText(DirectoryDB + @"\databases.JSON", jsonToOutput);



            return Json("ok", JsonRequestBehavior.AllowGet);

        }
        public JsonResult EditPax(string id, string dataJson, string rows)
        {
            int NewId = int.Parse(id) - 1;
            var NewJson = JArray.Parse(dataJson);
            var rowsB = int.Parse(rows);

            var DirectoryDB = System.AppDomain.CurrentDomain.BaseDirectory + "databases";
            var booking = System.AppDomain.CurrentDomain.BaseDirectory + "databases" + @"\databases.JSON";
            var contents = System.IO.File.ReadAllText(booking);


            dynamic jsonObj = JsonConvert.DeserializeObject(contents);



            var dataP = jsonObj[NewId]["passanger"];
            string andiOuput = JsonConvert.SerializeObject(dataP, Formatting.Indented);



            jsonObj[NewId]["passanger"][rowsB] = NewJson[0];

            var jsonToOutput = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            System.IO.File.WriteAllText(DirectoryDB + @"\databases.JSON", jsonToOutput);






            return Json("edit", JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetPaxs(string id)
        {
            int NewId = int.Parse(id) - 1;

            var DirectoryDB = System.AppDomain.CurrentDomain.BaseDirectory + "databases";
            var booking = System.AppDomain.CurrentDomain.BaseDirectory + "databases" + @"\databases.JSON";
            var contents = System.IO.File.ReadAllText(booking);


            dynamic jsonObj = JsonConvert.DeserializeObject(contents);



            var dataP = jsonObj[NewId]["passanger"];


            var jsonToOutput = JsonConvert.SerializeObject(dataP, Formatting.Indented);




            return Json(jsonToOutput, JsonRequestBehavior.AllowGet);

        }
    }
}