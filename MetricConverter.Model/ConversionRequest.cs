using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MetricConverter.Model
{
    /// <summary>
    /// Conversion calculator request.
    /// </summary>
    [DataContract]
    public class ConversionRequest
    {
        /// <summary>
        /// Conversion type e.g. Length, Temperature, Weight as per look up endpoint e.g. 2c32be51-8c58-407b-be0a-fc89bf79cc1d
        /// </summary>
        [DataMember(Name = "typeId")]
        public Guid TypeId { get; set; }

        /// <summary>
        /// Unit identifier to convert from e.g. 2c32be51-8c58-407b-be0a-fc89bf79cc1d
        /// </summary>
        [DataMember(Name = "unitFromId")]
        public Guid UnitFromId { get; set; }
        /// <summary>
        /// Unit identifier to convert to e.g. fa4b5338-8be3-4845-a4ca-d334aba0c32d
        /// </summary>
        [DataMember(Name = "unitToId")]
        public Guid UnitToId { get; set; }

        /// <summary>
        /// Unit value to calculate from
        /// </summary>
        [DataMember(Name = "value")]
        public double Value { get; set; }
    }
}
