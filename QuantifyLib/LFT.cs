using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public class LFT : FloatingRateBond
    {
        public double SELIC
        {
            get { return _index; }
            set { _index = value; }
        }

        public LFT(double faceValue, double rate, DateTime maturity) :
        base(faceValue, rate, maturity, new Du252 ()){
          
        }

        
    }
}
