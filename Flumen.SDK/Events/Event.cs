using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.Events
{
    public class Event : IEvent
    {
        public Dictionary<object, object> Variables { get; set; }

        public Type EventDataType { get; set; }

        public object EventData { get; set; }

        public object GetEventData()
        {
            return EventData;
        }

        public object GetEventData(String field)
        {
            object data = null;

            if (field.StartsWith("$")) {
                field = field.Replace("$", "");
                data = SelectByProperty(field);
            } else if (field.StartsWith("@"))
            {
                field = field.Replace("@", "");
                data = Variables[field];
            }

            return data;
        }

        private object SelectByProperty(String field)
        {
            if (EventDataType == null)
            {
                throw new Exception(String.Format("EventDataType is required. Tried accessing {0} property", field));
            }
            PropertyInfo prop = EventDataType.GetProperty(field);
            if (prop == null)
            {
                throw new Exception(String.Format("Could not resolve property {0} of {1}", field, EventDataType.Name));
            }
            return prop.GetValue(EventData); ;
        }
    }
}
