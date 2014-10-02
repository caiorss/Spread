using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public class CashFlow
    {
        #region "Variables"

        private DateTime _paymentDate;
        private bool _hasOccurred = false;
        private decimal _amount;

        #endregion
        

        #region "Properties"

        public DateTime PaymentDate
        {
            get { return _paymentDate; }
        }

        public bool HasOccurred
        {
            get { return _hasOccurred; }
            set { _hasOccurred = value; }
        }

        #endregion

        #region "Public Methods"

        public virtual decimal Amount()
        {
            return _amount;
        }

        #endregion

        public CashFlow(DateTime paymentDate, decimal amount)
        {
            _paymentDate = paymentDate;
            _amount = amount;
        }


        

    }
}
