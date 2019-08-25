using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace maskx.OData.Metadata
{
    public class Table : TableaBase
    {
        public Table Column(string name, Action<Column> columnSetting)
        {
            var c = this.Columns.GetOrAdd(name, new Column() { Name = name });
            columnSetting(c);
            return this;
        }
    }
}
