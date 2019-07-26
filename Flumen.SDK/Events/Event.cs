using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.Events
{
    public class Event : IEvent
    {
        public object EventData { get; set; }

        public object GetEventData()
        {
            return EventData;
        }
    }
}
