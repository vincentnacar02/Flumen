using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flumen.SDK.Entities
{
    public class ActivityResult
    {
        private ResultStatus status { get; set; }
        private Exception exception { get; set; }

        public ActivityResult(ResultStatus status)
        {
            this.status = status;
        }

        public ActivityResult(ResultStatus status, Exception e)
        {
            this.status = status;
            this.exception = e;
        }

        public ResultStatus GetStatus()
        {
            return this.status;
        }

        public Exception GetException()
        {
            return this.exception;
        }

        public static ActivityResult Success()
        {
            return new ActivityResult(ResultStatus.SUCCESS);
        }

        public static ActivityResult Failure()
        {
            return new ActivityResult(ResultStatus.FAILURE);
        }

        public static ActivityResult Failure(Exception e)
        {
            return new ActivityResult(ResultStatus.FAILURE, e);
        }
    }
}
