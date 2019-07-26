using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.Entities
{
    public class Condition
    {
        public String Selector { get; set; }
        public ConditionOperator Operator { get; set; }
        public object ExpectedValue { get; set; }

    }
}
