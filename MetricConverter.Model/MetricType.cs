using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MetricConverter.Model
{
    /// <summary>
    /// Metric Type
    /// </summary>
    [DataContract]
    public class MetricType
    {
        /// <summary>
        /// Type Id e.g. 2c32be51-8c58-407b-be0a-fc89bf79cc1d
        /// </summary>
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Type name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

    }
}
