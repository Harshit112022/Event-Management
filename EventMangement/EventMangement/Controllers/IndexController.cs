using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using DAL;
using System.Text;

namespace EventMangement.Controllers
{
    public class IndexController : Controller
    {
        EventDAL eventDAL = new EventDAL();
        EventModel eventModel = new EventModel();
        StringBuilder xmlString = new StringBuilder();

        // GET: Index
        public ActionResult Index()
        {
            eventModel.EventLocationsGetList = eventDAL.GetListEventLocation();
            eventModel.EventTypesGetList = eventDAL.GetListEventTypes();
            return View(eventModel);
        }
        public ActionResult TaksListView()
        {
            eventModel.TaskOtherGetList = eventDAL.GetListOtherTasks();
            return View("_TaksList", eventModel);
        }
        public ActionResult TaksList()
        {

            eventModel.TaskGetList = eventDAL.GetListTasks();
            return Json(eventModel, JsonRequestBehavior.AllowGet);
        }

        public int Insert(EventModel eventModel)
        {
            eventDAL.TaskName = eventModel.TaskName;
            eventModel.lastIdentity = eventDAL.InsertOtherTask();
            return eventModel.lastIdentity;
        }
        [HttpPost]
        public ActionResult EventTaskInsert(EventModel eventModel)
        {
            try
            {
                if (ConvertToXml(eventModel.TaskList))
                {
                    eventDAL.EventName = eventModel.EventName;
                    eventDAL.EventLocationId = eventModel.EventLocationId;
                    eventDAL.EventTypeId = eventModel.EventTypeId;
                    eventDAL.EventDate = eventModel.EventDate;
                    eventDAL.EventTime = eventModel.EventTime;
                    eventDAL.xmlString = xmlString.ToString();
                    return Json(eventDAL.Save());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
         
                return Json(new {success=false});
        }
        public bool ConvertToXml( List<TaskListclass> TaskList)
        {
            if (TaskList == null || TaskList.Count == 0)
                return false;



            xmlString.AppendLine("<?xml version=\"1.0\"?>");
            xmlString.AppendLine("<TaskListParent>");
            foreach (var Task in TaskList)
            {
                xmlString.AppendLine("<TaskList>");
                xmlString.AppendLine($"    <TaskId>{Task.TaskId}</TaskId>");            
                xmlString.AppendLine("  </TaskList>");
            }

            xmlString.AppendLine("</TaskListParent>");
            return true;
        }
    }
}