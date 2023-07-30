using Class_Scheduler.Common.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Extensions
{
    public static class DialogExtension
    {
        public static void UpdateLoading(this IEventAggregator aggregator, UpdateModel updateModel)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Publish(updateModel);
        }

        public static void Register(this IEventAggregator aggregator, Action<UpdateModel> action)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(action);
        }
    }
}
