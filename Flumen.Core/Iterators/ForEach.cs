using Flumen.SDK.Entities;
using Flumen.SDK.Events;
using Flumen.SDK.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.Core.Iterators
{
    public class ForEach<T>
    {
        public IEnumerable<T> Items { get; set; }

        private IList<ForEachHook> _hooks = new List<ForEachHook>();

        public void AddHook(ForEachHook hook)
        {
            this._hooks.Add(hook);
        }

        public ActivityResult Execute(IEvent e)
        {
            try
            {
                foreach (var item in Items)
                {
                    foreach (var hook in this._hooks)
                    {
                        hook.OnEach(item);
                    }
                }
            }
            catch (Exception ex)
            {
                return ActivityResult.Failure(ex);
            }
            return ActivityResult.Success();
        }
    }
}
