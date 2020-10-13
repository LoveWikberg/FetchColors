using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch_Colors.Models
{
    public class ColorListModel
    {
        public string ListHeader { get; set; }
        public IEnumerable<ColorModel> Colors { get; set; }
    }
}
