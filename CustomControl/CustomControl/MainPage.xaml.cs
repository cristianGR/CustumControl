using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomControl
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), FlipRefresh);
        }

        bool FlipRefresh()
        {
            Flip.Text = DigitoDerecha(DateTime.Now.Second);
            return true;
        }
        string DigitoDerecha(int segundos)
        {
            string seg = segundos.ToString("00");
            return seg.First().ToString();
        }
    }
}
