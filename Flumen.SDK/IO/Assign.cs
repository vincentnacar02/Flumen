using Flumen.SDK.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.IO
{
    public class Assign : IStatement, ForEachHook
    {
        public IDictionary<object, object> Variables { get; set; }

        public String VariableName { get; set; }

        public void AssignValue(object value)
        {
            Variables[VariableName] = value;
        }

        public virtual void OnEach(object item)
        {
            AssignValue(item);
        }
    }
}
