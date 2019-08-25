using System;
using System.Collections.Generic;
using System.Text;

namespace maskx.OData.Metadata
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int? MaxLength { get; set; }
        public bool Nullable { get; set; }
        public string Mode { get; set; }
        public Table UDT { get; set; }
        string _Alias;
        public string Alias
        {
            get
            {
                if (string.IsNullOrEmpty(_Alias))
                    _Alias = Name;
                return _Alias;
            }
            set
            {
                _Alias = value;
            }
        }

    }
}
