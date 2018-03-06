﻿using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingContractResolver
{
    public class ConverterContractResolver : DefaultContractResolver
    {
        public new static readonly ConverterContractResolver Instance = new ConverterContractResolver();

        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);
            if (objectType == typeof(DateTime) || objectType == typeof(DateTimeOffset))
            {
                contract.Converter = new JavaScriptDateTimeConverter();
            }
            return contract;
        }
    }
}
