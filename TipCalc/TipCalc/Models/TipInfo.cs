using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalc.Models
{
    class TipInfo
    {
        private decimal _total;
        private decimal _subTotal;
        private decimal _tipPercent;

        public decimal Total
        {
            get { return _total; }
            set
            {
                if(_total != value)
                {
                    _total = value;
                    OnTipValueChanged();
                }
            }
        }

        public decimal Subtotal
        {
            get { return _subTotal; }
            set
            {
                if (_subTotal != value)
                {
                    _subTotal = value;
                    OnTipValueChanged();
                }
            }
        }

        public decimal TipPercent
        {
            get { return _tipPercent; }
            set
            {
                if (_tipPercent != value)
                {
                    _tipPercent = value;
                    OnTipValueChanged();
                }
            }
        }

        private void OnTipValueChanged()
        {
            var h = TipValueChanged;
            if (h != null)
                h(this, EventArgs.Empty);
        }

        public decimal Tax
        {
            get { return Total - Subtotal; }
        }

        public decimal TipValue
        {
            get
            {
                if (Total == 0m || Subtotal == 0m || TipPercent == 0m)
                    return 0m;

                var percent = TipPercent;
                percent /= 100;
                decimal value = (Subtotal * (1 + percent)) + (Total - Subtotal);
                decimal fract = value - Math.Truncate(value);
                int f = (int)(fract * 100);

                while ((f % 25) != 0)
                    ++f;

                fract = f;
                fract /= 100;
                value = Math.Truncate(value) + fract;

                return value - Total;
            }
        }

        public event EventHandler TipValueChanged;
    }
}
