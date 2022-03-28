using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project4
{
    public static class RandomGen
    {
        public static double NextGaussian(this Random r)
        {   var u1 = r.NextDouble();
            var u2 = r.NextDouble();
            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);
            return rand_std_normal;
        }
    }
}