using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kaeri.Dto
{
    public class KaeriObject
    {
        [Required]
        public int Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
