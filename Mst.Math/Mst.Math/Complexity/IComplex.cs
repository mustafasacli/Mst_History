using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mst.Math.Complexity
{
    public interface IComplex
    {
        Double Real { get; set; }

        Double Imaginer { get; set; }

        Double Angle { get; }

        Double Amplitude { get; }

    }
}
