using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Models
{
    public class MinMaxParameterPair
    {
        public Parameter<double?> MinParameter { get; set; }
        public Parameter<double?> MaxParameter { get; set; }

    }
}
