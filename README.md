# Flumen
A decoupled control flow engine

### A working example
``` c#
public class FileInfo : Activity
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
            Flumen.Core.Iterators.ForEach<String> test1 = new Core.Iterators.ForEach<string>();
            test1.Items = items;
			
			// add printer hook to the foreach activiy
			// to prints each item
            test1.AddHook(new Flumen.SDK.IO.Printer());

			// create assign activity
			// inject variable registry to assign activiy
			// add variable name; the value will be added in variable registry dictionary and variable name act as a key
            Flumen.SDK.IO.Assign assign = new TestAssign(); //Flumen.SDK.IO.Assign();
            assign.Variables = variables;
            assign.VariableName = "Name";

			// inject to foreach activity
            test1.AddHook(assign);

			// execute foreach activity
            Flumen.SDK.Entities.ActivityResult resut = test1.Execute(new Flumen.SDK.Events.StartEvent());
            Console.WriteLine("Execution Status: {0}", resut.GetStatus());

			// print variable "Name"
            Console.WriteLine("Name variable value: {0}", variables["Name"]);
            Console.Read();
        }
    }
```