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
            public override void OnEach(object item, Type itemType)
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
           // Example1();
            Example2();
        }

        static void Example1()
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

        static void Example2()
        {
            List<Person> persons = new List<Person>()
            {
                new Person
                {
                    FirstName = "Vincent",
                    LastName = "Nacar"
                },
                new Person
                {
                    FirstName = "Enteng",
                    LastName = "Nacar"
                }
            };

            // create a foreach activity and inject a list 
            Flumen.Core.Iterators.ForEach<Person> foreachActivity = new Core.Iterators.ForEach<Person>();
            foreachActivity.ItemType = typeof(Person);
            foreachActivity.Items = persons;

            // add printer hook to the foreach activiy
            // to prints each item FirstName
            Flumen.SDK.IO.Printer printer = new Flumen.SDK.IO.Printer();
            printer.Selector = SDK.Utils.Selector.PropertyName("FirstName");
            foreachActivity.AddHook(printer);

            // create condition activity
            // to check if current item FirstName is equal to Vincent
            // if true then stored in FirstName
            Flumen.Core.Condition.IFActivity ifCondition = new Core.Condition.IFActivity();
            ifCondition.Condition = new SDK.Entities.Condition
            {
                Selector = SDK.Utils.Selector.PropertyName("FirstName"),
                Operator = SDK.Entities.ConditionOperator.EQ,
                ExpectedValue = "Enteng"
            };

            Flumen.SDK.IO.Printer printer2 = new Flumen.SDK.IO.Printer("Hello World, $FirstName");
            printer2.Selector = SDK.Utils.Selector.PropertyName("FirstName");

            ifCondition.AddDoNode(printer2);
            // inject to foreach activity
            foreachActivity.AddHook(ifCondition);

            // execute foreach activity
            Flumen.SDK.Entities.ActivityResult resut = foreachActivity.Execute(new Flumen.SDK.Events.StartEvent());
            Console.WriteLine("Execution Status: {0}", resut.GetStatus());
            if (resut.GetException() != null)
                Console.WriteLine("Execution Exception: {0}", resut.GetException().Message);
            Console.Read();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
