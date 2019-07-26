using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.Hooks
{
    public interface ForEachHook
    {
        void OnEach(object item, Type itemType);
    }
}
