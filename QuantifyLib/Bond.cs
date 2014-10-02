using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public abstract class Bond
    {
        private bool _isExpired = false;
        private bool _isCalculated = false;
        protected decimal _NVP = 0;
        protected DateTime _maturityDate;
        private DateTime _issueDate;
        protected DateTime _currentDate;
       

        #region "Properties"

        public bool IsExpired
        {
            get
            {
                return _isExpired;
            }
        }

        public bool IsCalculated
        {
            get
            {
                return _isCalculated;
            }
        }

        public DateTime MaturityDate
        {
            get { return _maturityDate; }
        }

        public DateTime IssueDate
        {
            get { return _issueDate; }
        }


        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; }
        }

        #endregion

        #region "Public Methods"

        public decimal NPV()
        {
            Calculate();
            return _NVP;
        }

        
        public abstract decimal CleanPrice();
        public abstract decimal DirtyPrice();
        public abstract decimal CurrentYield();
        
        #endregion

        #region "Internal Methods"

        protected void Calculate()
        {
            if (_isExpired == true)
            {
                _isCalculated = true;
            }
            else
            {
                PerformCalculate();
            }
        }

        protected abstract void PerformCalculate();

        #endregion

        

    }
}
