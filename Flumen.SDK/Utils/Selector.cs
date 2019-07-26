using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.Utils
{
    public class Selector
    {
        static String _variableMarker = "@";
        static String _propertyMarker = "$";
        public static String VariableName(String variable)
        {
            return _variableMarker + variable;
        }

        public static String PropertyName(String property)
        {
            return _propertyMarker + property;
        }
    }
}
