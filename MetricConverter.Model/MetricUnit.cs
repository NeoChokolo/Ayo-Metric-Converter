using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MetricConverter.Model
{
    /// <summary>
    /// Metric Unit
    /// </summary>
    [DataContract]
    public class MetricUnit
    {
        /// <summary>
        /// Unit Id e.g. 2c32be51-8c58-407b-be0a-fc89bf79cc1d
        /// </summary>
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Unit name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Unit type identifier .e.g 2c32be51-8c58-407b-be0a-fc89bf79cc1d
        /// </summary>
        [DataMember(Name = "typeId")]
        public Guid TypeId { get; set; }
    }
}
