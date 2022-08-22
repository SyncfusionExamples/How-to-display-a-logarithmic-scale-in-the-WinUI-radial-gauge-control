using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.Gauges;
using System;
using System.Collections.Generic;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LogarithmicAxis
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
    }

    public class RadialAxisExt : RadialAxis
    {
        int labelsCount = 0;
        public override List<AxisLabelData> GenerateVisibleLabels()
        {
            List<AxisLabelData> customLabels = new List<AxisLabelData>();

            var _minimum = (int)logBase(this.Minimum, 10);
            var _maximum = (int)logBase(this.Maximum, 10);
            for (var i = _minimum; i <= _maximum; i++)
            {
                int value = (int)Math.Floor(Math.Pow(10, i));// logBase  value is 10
                AxisLabelData label = new AxisLabelData
                {
                    Value = value,
                    Text = value.ToString()
                };
                customLabels.Add(label);
            }

            labelsCount = customLabels.Count;
            return customLabels;
        }

        double logBase(double value, double baseValue)
        {
            return Math.Log(value) / Math.Log(baseValue);
        }

        public override double ValueToCoefficient(double value)
        {
            return logBase(value, 10) / (labelsCount - 1);
        }
    }
}
