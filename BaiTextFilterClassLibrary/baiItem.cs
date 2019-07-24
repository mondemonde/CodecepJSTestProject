using MyCommonLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTextFilterClassLibrary
{
    public class WebItem: BaseModel
    {
        public string ReferenceUrl { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }




    }
}
