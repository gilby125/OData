using System;
using System.Collections.Generic;
using System.Text;

namespace maskx.OData.Metadata
{
    public class Relationship
    {
        public string Key
        {
            get;set;
        }
        public string ParentSchema { get; set; }
        public string Parent { get; set; }
        public string ParentFullName
        {
            get
            {
                return $"{ParentSchema}:{Parent}";
            }
        }
        public string ParentColumn { get; set; }
        public string Refrenced { get; set; }
        public string RefrencedSchema { get; set; }
        public string RefrencedColumn { get; set; }
        public string RefrencedFullName
        {
            get
            {
                return $"{RefrencedSchema}.{Refrenced}";
            }
        }
    }
}
