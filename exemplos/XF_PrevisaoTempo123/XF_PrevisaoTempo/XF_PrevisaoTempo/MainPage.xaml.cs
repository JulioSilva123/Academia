using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace XF_PrevisaoTempo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<Tempo> Tempos { get => TempoData(); }

        private List<Tempo> TempoData()
        {
            var tempList = new List<Tempo>();
            tempList.Add(new Tempo { Temp = "22", Date = "Domingo 16", Icon = "weather.png" });
            tempList.Add(new Tempo { Temp = "21", Date = "Segunda 17", Icon = "weather.png" });
            tempList.Add(new Tempo { Temp = "20", Date = "Terça 18", Icon = "weather.png" });
            tempList.Add(new Tempo { Temp = "12", Date = "Quarta 19", Icon = "weather.png" });
            tempList.Add(new Tempo { Temp = "17", Date = "Quinta 20", Icon = "weather.png" });
            tempList.Add(new Tempo { Temp = "20", Date = "Sexta 21", Icon = "weather.png" });

            return tempList;
        }
    }

    public class Tempo
    {
        public string Temp { get; set; }
        public string Date { get; set; }
        public string Icon { get; set; }
    }
}
