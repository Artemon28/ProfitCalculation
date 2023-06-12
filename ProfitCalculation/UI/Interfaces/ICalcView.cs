using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.UI.Interfaces
{
    public interface ICalcView
    {
        public RadioButton radioButton1 { get; }
        public RadioButton radioButton2 { get; }

        public DateTimePicker dateTimePicker1 { get; }
        public DateTimePicker dateTimePicker2 { get; }
        Label labelWarning { get; set; }

        event EventHandler CalculateProfit;

        void Show();
    }
}
