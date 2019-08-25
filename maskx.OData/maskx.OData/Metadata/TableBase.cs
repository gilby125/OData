using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace maskx.OData.Metadata
{
    public class TableaBase : MetadataBase
    {

        public ConcurrentDictionary<string, Column> Columns { get; } = new ConcurrentDictionary<string, Column>();


    }
}
