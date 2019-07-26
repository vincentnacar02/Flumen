using Flumen.SDK;
using Flumen.SDK.Entities;
using Flumen.SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.Core.Condition
{
    public class IFActivity : Activity
    {
        public Flumen.SDK.Entities.Condition Condition { get; set; }

        private List<Activity> DoNodes = new List<Activity>();

        private List<Activity> ElseNodes = new List<Activity>();

        public IFActivity()
        {

        }

        public void AddDoNode(Activity activity)
        {
            this.DoNodes.Add(activity);
        }

        public void AddElseNode(Activity activity)
        {
            this.ElseNodes.Add(activity);
        }

        private void ExecuteDoNodes(IEvent e)
        {
            foreach (var activity in DoNodes)
            {
                activity.Execute(e);
            }
        }

        private void ExecuteElseNodes(IEvent e)
        {
            foreach (var activity in ElseNodes)
            {
                activity.Execute(e);
            }
        }

        public override ActivityResult Execute(IEvent e)
        {
            try
            {
                if (e.GetEventData() != null)
                {
                    object data = Condition.Selector != null ? e.GetEventData(Condition.Selector) : e.GetEventData();
                    switch (Condition.Operator)
                    {
                        case ConditionOperator.EQ:
                            if (data.Equals(Condition.ExpectedValue))
                            {
                                ExecuteDoNodes(e);
                            } else
                            {
                                ExecuteElseNodes(e);
                            }
                            break;
                        case ConditionOperator.NE:
                            if (!data.Equals(Condition.ExpectedValue))
                            {
                                ExecuteDoNodes(e);
                            }
                            else
                            {
                                ExecuteElseNodes(e);
                            }
                            break;
                        default:
                            break;
                    }
                } else
                {
                    throw new Exception("Expected condition in ConditionEvent.");
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
