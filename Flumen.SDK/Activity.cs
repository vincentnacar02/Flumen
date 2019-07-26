using Flumen.SDK.Entities;
using Flumen.SDK.Events;
using Flumen.SDK.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK
{
    public class Activity : IActivity, ForEachHook
    {
        public virtual ActivityResult Execute(IEvent e)
        {
            return ActivityResult.Success();
        }

        public virtual void OnEach(object item, Type itemType)
        {
            Execute(new ExecuteEvent
            {
                EventData = item,
                EventDataType = itemType
            });
        }
    }
}
