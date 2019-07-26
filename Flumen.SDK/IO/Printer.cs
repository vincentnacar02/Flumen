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
        public string Field { get; set; }

        public override ActivityResult Execute(IEvent e)
        {
            if (Field != null)
            {
                Console.WriteLine(e.GetEventData(Field).ToString());
            } else
            {
                Console.WriteLine(e.GetEventData().ToString());
            }
            return ActivityResult.Success();
        }
    }
}
