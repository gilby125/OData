using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace maskx.OData.Metadata
{
    public class Function : MetadataBase
    {
        public Table ResultType { get; set; }
        public ConcurrentDictionary<string, Parameter> Parameters { get; } = new ConcurrentDictionary<string, Parameter>();
        public Function Parameter(string name, Action<Parameter> parameterSetting)
        {
            var c = this.Parameters.GetOrAdd(name, (key) =>
            {
                return new Parameter() { Name = key };
            });
            parameterSetting(c);
            return this;
        }
    }
}
