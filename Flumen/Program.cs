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
            // a variable registry is initialized
            Dictionary<object, object> variables = new Dictionary<object, object>();
            variables.Add("Name", null);

            List<string> items = new List<string>
            {
                "Im", "Vincent", "Nacar"
            };

            // create a foreach activity and inject a list 
            Flumen.Core.Iterators.ForEach<String> foreachActivity = new Core.Iterators.ForEach<string>();
            foreachActivity.Items = items;

            // add printer hook to the foreach activiy
            // to prints each item
            foreachActivity.AddHook(new Flumen.SDK.IO.Printer());

            // create assign activity
            // inject variable registry to assign activiy
            // add variable name; the value will be added in variable registry dictionary and variable name act as a key
            Flumen.SDK.IO.Assign assign = new TestAssign(); //Flumen.SDK.IO.Assign();
            assign.Variables = variables;
            assign.VariableName = "Name";

            // inject to foreach activity
            foreachActivity.AddHook(assign);

            // create condition activity
            // to check if current item is equal to Nacar
            // if true then stored in LastName
            Flumen.Core.Condition.IFActivity ifCondition = new Core.Condition.IFActivity();
            ifCondition.Condition = new SDK.Entities.Condition
            {
                Operator = SDK.Entities.ConditionOperator.EQ,
                ExpectedValue = "Nacar"
            };
            ifCondition.AddDoNode(new Flumen.SDK.IO.Assign
            {
                Variables = variables,
                VariableName = "LastName"
            });

            // inject to foreach activity
            foreachActivity.AddHook(ifCondition);

            // execute foreach activity
            Flumen.SDK.Entities.ActivityResult resut = foreachActivity.Execute(new Flumen.SDK.Events.StartEvent());
            Console.WriteLine("Execution Status: {0}", resut.GetStatus());

            // print variable "Name"
            Console.WriteLine("Name variable value: {0}", variables["Name"]);
            Console.WriteLine("LastName variable value: {0}", variables["LastName"]);
            Console.Read();
        }
    }
}
