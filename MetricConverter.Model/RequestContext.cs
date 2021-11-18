using System;
using System.Collections.Generic;
using System.Text;

namespace MetricConverter.Model
{
    public class RequestContext
    {
        public Guid RequestId { get; set; }
        public string UserId { get; set; }
        public string RequestDate { get; set; }

    }
}
