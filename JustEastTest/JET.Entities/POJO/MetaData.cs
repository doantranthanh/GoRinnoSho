using System;
using System.Collections.Generic;

namespace JET.Entities.POJO
{
    public class MetaData
    {
        public String SearchedTerms { get; set; }
        public IEnumerable<TagDetail> TagDetailses { get; set; }
    }
}