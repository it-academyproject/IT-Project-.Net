﻿using System.Collections.Generic;

namespace Common.Lib.Infrastructure
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
        public string AllErrors
        {
            get
            {
                var output = string.Empty;
                foreach (var item in Errors) output += item + "\n\r";
                return output;
            }
        }
    }

    public class ValidationResult<T> : ValidationResult
    {
        public T ValidatedResult { get; set; }
    }
}