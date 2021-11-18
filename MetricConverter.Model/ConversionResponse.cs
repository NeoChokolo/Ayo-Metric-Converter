using System.Runtime.Serialization;

namespace MetricConverter.Model
{
    /// <summary>
    /// Response object returned after calculation
    /// </summary>
    [DataContract]
    public class ConversionResponse
    {
        /// <summary>
        /// Conversion type e.g. Length, Temperature, Weight
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Conversion results after calulation e.g. 2 Micrometer = 0.0000021872 Yard
        /// </summary>
        [DataMember(Name = "result")]
        public string Result { get; set; }
    }
}
