using Flumen.SDK.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen
{
    class Program
    {
        class TestAssign : SDK.IO.Assign
        {
            public override void OnEach(object item)
            {
                if (item.Equals("Vincent"))
                {
                    Execute(new Flumen.SDK.Events.ExecuteEvent
                    {
                        EventData = item
                    });
                }
            }
        }
        static void Main(string[] args)
        {
            Dictionary<object, object> variables = new Dictionary<object, object>();
            variables.Add("Name", null);

            List<string> items = new List<string>
            {
                "Im", "Vincent", "Nacar"
            };

            Flumen.Core.Iterators.ForEach<String> test1 = new Core.Iterators.ForEach<string>();
            test1.Items = items;
            test1.AddHook(new Flumen.SDK.IO.Printer());

            Flumen.SDK.IO.Assign assign = new TestAssign(); //Flumen.SDK.IO.Assign();
            assign.Variables = variables;
            assign.VariableName = "Name";

            test1.AddHook(assign);

            Flumen.SDK.Entities.ActivityResult resut = test1.Execute(new Flumen.SDK.Events.StartEvent());
            Console.WriteLine("Execution Status: {0}", resut.GetStatus());

            Console.WriteLine("Name variable value: {0}", variables["Name"]);
            Console.Read();
        }
    }
}
