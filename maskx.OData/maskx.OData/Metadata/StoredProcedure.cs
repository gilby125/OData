using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace maskx.OData.Metadata
{
    public class StoredProcedure:MetadataBase
    {
      public ConcurrentDictionary<String, Parameter> Parameters { get; } = new ConcurrentDictionary<string, Parameter>();
        public StoredProcedure Parameter(string name, Action<Parameter> parameterSetting)
        {
            var c = this.Parameters.GetOrAdd(name, (key) =>
            {
                return new Parameter() { Name = key };
            });
            parameterSetting(c);
            return this;
        }
        //TODO: code not complete
        public List<object> ResultType { get; set; }
       
    }
}
