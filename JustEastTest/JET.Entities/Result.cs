using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JET.Entities
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
