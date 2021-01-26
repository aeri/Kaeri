using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kaeri.Dto
{
    public class KaeriObjectDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime Created { get; set; }
    }
}
