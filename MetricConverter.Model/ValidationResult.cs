using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricConverter.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidationResult
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public bool IsValid => !this.ValidationMessages.Any();
        public List<string> ValidationMessages { get; set; } = new List<string>();
        public string FullValidationMessage => !this.ValidationMessages.Any() ? "Valid" : string.Join(Environment.NewLine, ValidationMessages);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidationResult<T> : ValidationResult
    {
        public T Data { get; set; }
    }
}
