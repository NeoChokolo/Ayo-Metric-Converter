using System;
using System.Collections.Generic;
using System.Text;

namespace MetricConverter.Core.Entities
{
    public class MetricFormulaEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public Guid UnitFromId { get; set; }
        public Guid UnitToId { get; set; }
        public string Formula { get; set; }
    }
}
