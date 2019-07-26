using Flumen.SDK.Entities;
using Flumen.SDK.Events;
using Flumen.SDK.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.IO
{
    public class Assign : Activity
    {
        public IDictionary<object, object> Variables { get; set; }

        public String VariableName { get; set; }

        public override ActivityResult Execute(IEvent e)
        {
            var data = Selector != null ? e.GetEventData(Selector) : e.GetEventData();
            Variables[VariableName] = data;
            return ActivityResult.Success();
        }
    }
}
