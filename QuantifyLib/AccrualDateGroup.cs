using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public class AccrualDateGroup
    {
        private DateTime _accrualStartDate;
        private DateTime _accrualEndDate;
        private DateTime _referenceStartDate;
        private DateTime _referenceEndDate;

        public DateTime AccrualStartDate
        {
            get { return _accrualStartDate; }
        }

        public DateTime AccrualEndDate
        {
            get { return _accrualEndDate; }
        }

        public DateTime ReferenceStartDate
        {
            get { return _referenceStartDate; }
        }

        public DateTime ReferenceEndDate
        {
            get { return _referenceEndDate; }
        }

        

        public AccrualDateGroup(DateTime accrualStart, DateTime accrualEnd)
        {
            if (accrualStart > accrualEnd)
            {
                throw new ArgumentException("AccrualStart cannot be later than AccrualEnd parameter");
            }
            
            _accrualStartDate = accrualStart;
            _accrualEndDate = accrualEnd;

            _referenceStartDate = _accrualStartDate;
            _referenceEndDate = _accrualEndDate;
        }

        public AccrualDateGroup(DateTime accrualStart, DateTime accrualEnd, DateTime referenceStart, DateTime referenceEnd)
        {
            if (accrualStart > accrualEnd)
            {
                throw new ArgumentException("AccrualStart cannot be later than AccrualEnd parameter");
            }

            if (referenceStart > referenceEnd)
            {
                throw new ArgumentException("ReferenceStart cannot be later than ReferenceEnd parameter");
            }

            _accrualStartDate = accrualStart;
            _accrualEndDate = accrualEnd;
            _referenceStartDate = referenceStart;
            _referenceEndDate = referenceEnd;
        }

    }
}
