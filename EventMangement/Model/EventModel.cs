using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
        public class TaskListclass
        {
            public int TaskId { get; set; }
        }
    public class EventModel
    {
            public int EventLocationId { get; set;}
         
            public string EventLocation { get; set; }
            public int EventTypeId { get; set; }
            public string EventType { get; set; }
            public string EventName { get; set; }
            public DateTime EventDate { get; set; }
            public DateTime EventTime { get; set; }
            public int EventTaskId { get; set; }
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int lastIdentity { get; set; }
            public List<EventModel> EventLocationsGetList { get; set; }
        public List<EventModel> EventTypesGetList { get; set; }
        public List<EventModel> TaskGetList { get; set; }
        public List<EventModel> TaskOtherGetList { get; set; }
        public List<TaskListclass> TaskList { get; set; }
    }
}
