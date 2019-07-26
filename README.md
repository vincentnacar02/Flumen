# Flumen
A decoupled control flow engine

### A Basic Example
``` c#
// setup data
var person1 = new Person
{
	FirstName = "Vincent",
	LastName = "Nacar"
};
var person2 = new Person
{
	FirstName = "Enteng",
	LastName = "Nacar"
};

// create a condition
// if Person.FirstName == "Vincent"
Flumen.Core.Condition.IFActivity condition = new Core.Condition.IFActivity();
condition.Condition = new SDK.Entities.Condition
{
	Selector = SDK.Utils.Selector.PropertyName("FirstName"),
	Operator = SDK.Entities.ConditionOperator.EQ,
	ExpectedValue = "Vincent"
};

// if true execute below
condition.AddDoNode(new SDK.IO.Printer
{
	Selector = SDK.Utils.Selector.PropertyName("FirstName"),
	Template = "Hello $FirstName"
});
// or else
condition.AddElseNode(new SDK.IO.Printer
{
	Selector = SDK.Utils.Selector.PropertyName("FirstName"),
	Template = "Hi $FirstName"
});

// execute condition using person1 data
condition.Execute(new SDK.Events.ExecuteEvent
{
	EventData = person1,
	EventDataType = typeof(Person)
});
// Output: Hello Vincent

// execute condition using person2 data
condition.Execute(new SDK.Events.ExecuteEvent
{
	EventData = person2,
	EventDataType = typeof(Person)
});
// Output: Hi Enteng
```
### Using a loop example
``` c#
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
Flumen.Core.Condition.IFActivity ifCondition = new Core.Condition.IFActivity();
ifCondition.Condition = new SDK.Entities.Condition
{
	Selector = SDK.Utils.Selector.PropertyName("FirstName"),
	Operator = SDK.Entities.ConditionOperator.EQ,
	ExpectedValue = "Vincent"
};

// if true then print message
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
```