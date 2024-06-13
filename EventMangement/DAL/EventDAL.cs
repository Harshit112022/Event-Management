using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EventDAL
    {
       
        private Database db;
      
        public int EventTaskId { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }
        public int EventTypeId { get; set; }
        public int EventLocationId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int lastIdentity { get; set; }
        public string xmlString;
        public List<EventModel> EventLocationsGetList  = new List<EventModel>();
        public List<EventModel> EventTypesGetList = new List<EventModel>();
        public List<EventModel> TaskGetList = new List<EventModel>();
        public List<EventModel> TaskOtherGetList = new List<EventModel>();
        public EventDAL()
        {
            this.db = DatabaseFactory.CreateDatabase();

        }
        public bool Save()
        {
           if(EventTaskId == 0)
            {
                return InsertEventTask();
            }
            else
            {
                return false;
            }
        }
        private bool InsertEventTask()
        {

            try
            {
                DbCommand com = this.db.GetStoredProcCommand("EventTaskInsert");

                if (!String.IsNullOrEmpty(this.EventName))
                {
                    db.AddInParameter(com, "EventName", DbType.String, this.EventName);
                }
             
                if(this.EventLocationId>0)
                {
                    db.AddInParameter(com, "EventLocationId", DbType.Int32, this.EventLocationId);
                }
               
                if(this.EventTypeId>0)
                {
                    db.AddInParameter(com, "EventTypeId", DbType.Int32, this.EventTypeId);
                }
                DateTime tempObject;
                if (DateTime.TryParse(this.EventDate.ToString(), out tempObject))
                {
                    db.AddInParameter(com, "EventDate", DbType.DateTime, this.EventDate);
                }
                if(DateTime.TryParse(this.EventTime.ToString(), out tempObject))
                {
                    db.AddInParameter(com, "EventTime", DbType.DateTime, this.EventTime);
                }                       
                
                if (this.xmlString != null)
                {
                    db.AddInParameter(com, "TaskList", DbType.Xml, this.xmlString);
                }        


                this.db.ExecuteNonQuery(com);

            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }
            return true; // Return whether ID was returned
        }                      
           
        
        public List<EventModel> GetListTasks()
        {

            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("TasksGetList");
                ds = db.ExecuteDataSet(com);
                foreach (DataRow Row in ds.Tables[0].Rows)
                {
                    TaskGetList.Add(new EventModel
                    {
                        TaskId = Convert.ToInt32(Row["TaskId"]),
                        TaskName = Convert.ToString(Row["TaskName"])
                    });
                }
                return TaskGetList;
            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public List<EventModel> GetListOtherTasks()
        {

            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("OtherTaskGetList");
                ds = db.ExecuteDataSet(com);
                foreach (DataRow Row in ds.Tables[0].Rows)
                {
                    TaskOtherGetList.Add(new EventModel
                    {
                        TaskId = Convert.ToInt32(Row["TaskId"]),
                        TaskName = Convert.ToString(Row["TaskName"])
                    });
                }
                return TaskOtherGetList;
            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public List<EventModel> GetListEventLocation()
        {
         
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("EventLocationsGetList");            
                ds = db.ExecuteDataSet(com);
                foreach (DataRow Row in ds.Tables[0].Rows)
                {
                    EventLocationsGetList.Add(new EventModel
                    {
                        EventLocationId = Convert.ToInt32(Row["EventLocationId"]),
                        EventLocation = Convert.ToString(Row["EventLocation"])                    
                    });
                }
                return EventLocationsGetList;
            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
                Debug.WriteLine(ex.StackTrace);
                return null;
            }


        }
        public List<EventModel> GetListEventTypes()
        {

            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("EventTypesGetList");
                ds = db.ExecuteDataSet(com);
                foreach (DataRow Row in ds.Tables[0].Rows)
                {
                    EventTypesGetList.Add(new EventModel
                    {
                        EventTypeId = Convert.ToInt32(Row["EventTypesId"]),
                        EventType = Convert.ToString(Row["EventType"])
                    });
                }
                return EventTypesGetList;
            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
                Debug.WriteLine(ex.StackTrace);
                return null;
            }


        }
        public int InsertOtherTask()
        {
            try
            {

                DbCommand com = this.db.GetStoredProcCommand("OtherTaskInsert");
                if (!String.IsNullOrEmpty(this.TaskName))
                {
                    this.db.AddInParameter(com, "TaskName", DbType.String, this.TaskName);
                }
                this.db.AddOutParameter(com, "lastIdentity", DbType.Int32, 1024);
                this.db.ExecuteNonQuery(com);
                this.lastIdentity = Convert.ToInt32(this.db.GetParameterValue(com, "lastIdentity"));

                return lastIdentity;
            }
            catch(Exception ex)
            {
                return 0;
            }

        }


    }
}

