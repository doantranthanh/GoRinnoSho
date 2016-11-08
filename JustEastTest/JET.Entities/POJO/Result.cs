using System;
using System.Collections.Generic;

namespace JET.Entities.POJO
{
    public class Result
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public String ShortResultText { get; set; }
        public String Area { get; set; }
        public String Errors { get; set; }
        public Boolean HasErros { get; set; }
        public MetaData MetaData { get; set; }
    }
}
