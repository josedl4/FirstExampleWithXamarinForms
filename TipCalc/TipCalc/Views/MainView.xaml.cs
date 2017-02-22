using Xamarin.Forms;
using TipCalc.Models;
using System;

namespace TipCalc.Views
{
    public partial class MainView : ContentPage
    {
        private TipInfo _info;

        public MainView()
        {
            InitializeComponent();

            _info = new TipInfo
            {
                TipPercent = 15
            };

            TipPercent.Text = _info.TipPercent.ToString();
            TipPercentSlider.Value = Convert.ToDouble(_info.TipPercent);

            _info.TipValueChanged += (sender, e) =>
            {
                TipValue.Text = _info.TipValue.ToString();
                Total.Text = (_info.TipValue + _info.Total).ToString();
            };

            STotalPT.TextChanged += (sender, e) =>
            {
                _info.Total = Parse(STotalPT.Text);
            };

            TipPercent.TextChanged += (sender, e) =>
            {
                _info.TipPercent = Parse(TipPercent.Text);
                TipPercentSlider.Value = (double)Parse(TipPercent.Text);
            };

            STotal.TextChanged += (sender, e) =>
            {
                _info.Subtotal = Parse(STotal.Text);
            };

            TipPercentSlider.ValueChanged += (sender, e) =>
            {
                TipPercent.Text = e.NewValue.ToString();
                TipPercentSlider.Value = e.NewValue;
            };
        }

        static decimal Parse(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0m;

            try
            {
                return Convert.ToDecimal(text);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return 0m;
            }
        }
    }
}
