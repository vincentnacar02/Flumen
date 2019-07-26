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
        public string Template { get; set; }

        public Printer()
        {

        }

        public Printer(String template)
        {
            this.Template = template;
        }

        public override ActivityResult Execute(IEvent e)
        {
            var text = Selector != null ? e.GetEventData(Selector).ToString() : e.GetEventData().ToString();
            if (Template != null)
            {
                Console.WriteLine(Template.Replace(Selector, text));
            }
            else
            {
                Console.WriteLine(text);
            }
            return ActivityResult.Success();
        }
    }
}
