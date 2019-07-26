using Flumen.SDK.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.IO
{
    public class Printer : ForEachHook
    {
        public void OnEach(object item)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
