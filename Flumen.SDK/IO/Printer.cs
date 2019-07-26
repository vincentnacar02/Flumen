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
    public class Printer : Activity
    {
        public override ActivityResult Execute(IEvent e)
        {
            Console.WriteLine(e.GetEventData().ToString());
            return ActivityResult.Success();
        }
    }
}
