using Flumen.SDK.Entities;
using Flumen.SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK
{
    public interface IActivity
    {
        ActivityResult Execute(IEvent e);
    }
}
