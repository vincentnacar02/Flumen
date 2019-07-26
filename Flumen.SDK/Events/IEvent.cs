using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.Events
{
    public interface IEvent
    {
        object GetEventData();

        object GetEventData(String field);
    }
}
