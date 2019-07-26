using Flumen.SDK.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.IO
{
    public class Assign : ForEachHook
    {
        public IDictionary<object, object> Variables { get; set; }

        public String VariableName { get; set; }

        public void OnEach(object item)
        {
            Variables[VariableName] = item;
        }
    }
}
