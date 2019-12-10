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
            FlipDerechaSegundo.Text = DigitoDerecha(DateTime.Now.Second);
            FlipDerechaMinuto.Text = DigitoDerecha(DateTime.Now.Minute);
            FlipDerechaHora.Text = DigitoDerecha(DateTime.Now.Hour);

            FlipIzquierdaSegundo.Text = DigitoIzquierda(DateTime.Now.Second);
            FlipIzquierdaMinuto.Text = DigitoIzquierda(DateTime.Now.Minute);
            FlipIzquierdaHora.Text = DigitoIzquierda(DateTime.Now.Hour);

            return true;
        }

        //////////////////
      
        string DigitoDerecha(int nros)
        {
            string digitos = nros.ToString("00");
            return digitos.Last().ToString();
        }
        string DigitoIzquierda(int nros)
        {
            string digitos = nros.ToString("00");
            return digitos.First().ToString();
        }
    }
}
