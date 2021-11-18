using System;
using System.Collections.Generic;
using System.Text;

namespace MetricConverter.Core.Entities
{
    public class MetricUnitEntity :BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }

    }
}
