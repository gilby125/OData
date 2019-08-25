using System;
using System.Collections.Generic;
using System.Text;

namespace maskx.OData.Metadata
{
    public class MetadataBase
    {
        public string Schema { get; set; }
        public string Name { get; set; }
        public string FullName
        {
            get { return $"{Schema}.{Name}"; }
        }
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
        public string FullAlias
        {
            get { return $"{Schema}.{Alias}"; }
        }
    }
}
