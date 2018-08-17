using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Visifire.Charts.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var listX = new List<string>() { "苹果", "樱桃", "菠萝", "香蕉", "榴莲", "葡萄", "桃子", "猕猴桃" };
            var listY = new List<string>() { "13", "75", "60", "38", "97", "22", "39", "80" };

            var lsTime = new List<DateTime>()
            {
                new DateTime(2018, 1, 1),
                new DateTime(2018, 2, 1),
                new DateTime(2018, 3, 1),
                new DateTime(2018, 4, 1),
                new DateTime(2018, 5, 1),
                new DateTime(2018, 6, 1),
                new DateTime(2018, 7, 1),
                new DateTime(2018, 8, 1),
                new DateTime(2018, 9, 1),
                new DateTime(2018, 10, 1),
                new DateTime(2018, 11, 1),
                new DateTime(2018, 12, 1),
            };

            var cherry = new List<string>() { "33", "75", "60", "98", "67", "88", "39", "45", "13", "22", "45", "80" };
            var pineapple = new List<string>() { "13", "34", "38", "12", "45", "76", "36", "80", "97", "22", "76", "39" };

            InitializeChartsStackColumn("8月份水果销量", listX, listY);
            InitializeChartsPie("8月份水果销量", listX, listY);
            InitializeChartsSpline("2018年樱桃、菠萝销量", lsTime, cherry, pineapple);
        }

        /// <summary>
        /// 初始化柱状图
        /// </summary>
        /// <param name="name">图表标题</param>
        /// <param name="valueX">X 轴数值列表</param>
        /// <param name="valueY">Y 轴数值列表</param>
        private void InitializeChartsStackColumn(string name, List<string> valueX, List<string> valueY)
        {
            //是否启用打印和保存图片工具栏
            this.chartStackedColumn.ToolBarEnabled = false;

            //是否启用滚动
            this.chartStackedColumn.ScrollingEnabled = false;
            //是否启用3D效果显示
            this.chartStackedColumn.View3D = false;

            //创建一个标题实例
            var title = new Title();
            //设置标题的文本
            title.Text = name;

            //添加新建的标题实例
            this.chartStackedColumn.Titles.Add(title);

            //创建 y 轴
            var yAxis = new Axis();
            //设置 y 轴最小值
            yAxis.AxisMinimum = 0;
            //设置 y 轴显示的后缀
            yAxis.Suffix = "斤";

            //创建一条新的数据线
            var dataSeries = new DataSeries();
            //设置数据线的渲染格式
            dataSeries.RenderAs = RenderAs.StackedColumn;

            //创建数据点
            DataPoint dataPoint;
            for (var i = 0; i < valueX.Count; i++)
            {
                //创建一个数据点实例
                dataPoint = new DataPoint();
                //设置 x 轴点
                dataPoint.AxisXLabel = valueX[i];
                //设置 y 轴点
                dataPoint.YValue = double.Parse(valueY[i]);
                dataSeries.DataPoints.Add(dataPoint);
            }

            this.chartStackedColumn.Series.Add(dataSeries);
        }

        /// <summary>
        /// 初始化饼状图
        /// </summary>
        /// <param name="name">图表标题</param>
        /// <param name="valueX">X 轴数值列表</param>
        /// <param name="valueY">Y 轴数值列表</param>
        private void InitializeChartsPie(string name, List<string> valueX, List<string> valueY)
        {
            this.chartsPie.ToolBarEnabled = false;
            this.chartsPie.ScrollingEnabled = false;
            this.chartsPie.View3D = false;

            var title = new Title();
            title.Text = name;

            this.chartsPie.Titles.Add(title);

            var dataSeries = new DataSeries();
            dataSeries.RenderAs = RenderAs.Pie;

            DataPoint dataPoint;
            for (var i = 0; i < valueX.Count; i++)
            {
                dataPoint = new DataPoint();
                dataPoint.AxisXLabel = valueX[i];
                dataPoint.YValue = double.Parse(valueY[i]);
                dataSeries.DataPoints.Add(dataPoint);
            }

            this.chartsPie.Series.Add(dataSeries);
        }

        /// <summary>
        /// 初始化折线图
        /// </summary>
        /// <param name="name">图表标题</param>
        /// <param name="lsTime">Y 轴数据日期</param>
        /// <param name="cherry">樱桃数值列表</param>
        /// <param name="pineapple">菠萝数值列表</param>
        private void InitializeChartsSpline(string name, List<DateTime> lsTime, List<string> cherry, List<string> pineapple)
        {
            this.chartsSpline.ToolBarEnabled = false;
            this.chartsSpline.ScrollingEnabled = false;
            this.chartsSpline.View3D = false;

            var title = new Title();
            title.Text = name;
            this.chartsSpline.Titles.Add(title);

            var xAxis = new Axis();
            xAxis.IntervalType = IntervalTypes.Months;
            xAxis.Interval = 1;
            xAxis.ValueFormatString = "MM月";
            this.chartsSpline.AxesX.Add(xAxis);

            var yAxis = new Axis();
            yAxis.AxisMinimum = 0;
            yAxis.Suffix = "斤";
            this.chartsSpline.AxesY.Add(yAxis);

            var dataSeriesCherry = new DataSeries();
            dataSeriesCherry.LegendText = "樱桃";
            dataSeriesCherry.RenderAs = RenderAs.Spline;
            dataSeriesCherry.XValueType = ChartValueTypes.DateTime;

            DataPoint dataPoint;
            for (var i = 0; i < lsTime.Count; i++)
            {
                dataPoint = new DataPoint();
                dataPoint.XValue = lsTime[i];
                dataPoint.YValue = double.Parse(cherry[i]);
                dataSeriesCherry.DataPoints.Add(dataPoint);
            }
            this.chartsSpline.Series.Add(dataSeriesCherry);


            var dataSeriesPineapple = new DataSeries();
            dataSeriesPineapple.LegendText = "菠萝";
            dataSeriesPineapple.RenderAs = RenderAs.Spline;
            dataSeriesPineapple.XValueType = ChartValueTypes.DateTime;

            for (var i = 0; i < lsTime.Count; i++)
            {
                dataPoint = new DataPoint();
                dataPoint.XValue = lsTime[i];
                dataPoint.YValue = double.Parse(pineapple[i]);
                dataSeriesPineapple.DataPoints.Add(dataPoint);
            }
            this.chartsSpline.Series.Add(dataSeriesPineapple);
        }
    }
}
