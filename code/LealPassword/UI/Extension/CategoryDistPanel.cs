using LealPassword.Database.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LealPassword.UI.Extension
{
    internal sealed partial class CategoryDistPanel : UserControl
    {
        internal CategoryDistPanel()
        {
            InitializeComponent();
            Region = Program.GenerateRoundRegion(Width, Height);
        }

        internal void LoadObjects(Font titleFont, List<Register> registers)
        {
            label1.Font = titleFont;

            var avaiableCategories = new Dictionary<string, int>();

            foreach (var register in registers)
            {
                if (!avaiableCategories.ContainsKey(register.Tag))
                    avaiableCategories.Add(register.Tag, 1);
                else
                    avaiableCategories[register.Tag]++;
            }

            CreatePieChart(avaiableCategories);
        }

        private void CreatePieChart(Dictionary<string, int> avaiableCategories)
        {
            graph.Series.Clear();

            var series = new Series("Categories")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = false
            };

            foreach (var category in avaiableCategories)
            {
                var dataPoint = series.Points.Add(category.Value);
                dataPoint.Label = category.Key;
                dataPoint.IsVisibleInLegend = true;
                dataPoint.IsValueShownAsLabel = false;
                dataPoint.LegendText = category.Key;
            }

            graph.Series.Add(series);
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";
            graph.Invalidate();
            graph.Enabled = false;
        }
    }
}
