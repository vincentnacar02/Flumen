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
                    AssignValue(item);
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

            test1.Execute();

            Console.WriteLine("Name variable value: {0}", variables["Name"]);
            Console.Read();
        }
    }
}
