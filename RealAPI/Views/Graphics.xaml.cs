using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Entry = Microcharts.ChartEntry;
using Microcharts;

namespace RealAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graphics : ContentPage
    {


        List<Entry> entries = new  List<Entry>
            {
              
               new Entry(200)
               {
                   Color = SKColor.Parse("#FF1493"),
                   Label = "January",
                   ValueLabel = "200"
               },
               new Entry(360)
               {
                   Color = SKColor.Parse("#00BFFF"),
                   Label = "February",
                   ValueLabel = "360"
               },
               new Entry(-100)
               {
                   Color = SKColor.Parse("#00CED1"),
                   Label = "March",
                   ValueLabel = "-100"
               },


            };


        public Graphics()
        {

            InitializeComponent();
            Chart1.Chart = new RadialGaugeChart { Entries = entries };
        }
    }
}