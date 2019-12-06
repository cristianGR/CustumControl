using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomControl
{
    public class FlipDigit: ContentView
    {
        Image up = new Image();
        Image down = new Image();
        Grid grid = new Grid();
        static uint _configure_Flip_Time_Set;

        public FlipDigit()
        {
            _configure_Flip_Time_Set = 50;
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            Grid.SetRow(up, 0);
            Grid.SetRow(down, 1);
            Grid.SetRowSpan(up, 20);
            Grid.SetRowSpan(down, 20);

            grid.Children.Add(up);
            grid.Children.Add(down);
            
            up.Source = ImageSource.FromFile("up_0");
            down.Source = ImageSource.FromFile("down_0");
            Content = grid;
        }

        public static readonly BindableProperty TextProperty =
              BindableProperty.Create (nameof(Text), typeof(string), typeof(FlipDigit),  propertyChanged: OntextChange);

        private async static void OntextChange(BindableObject bindable, object oldValue, object newValue)
        {
            if(!Equals((string)oldValue,(string)newValue))
            {
                var flip_digit_instance = (FlipDigit)bindable;

                await flip_digit_instance.up.RotateXTo(-90, _configure_Flip_Time_Set, Easing.CubicIn);
                flip_digit_instance.up.Source = ImageSource.FromFile($"up_{newValue}");
                await flip_digit_instance.up.RotateXTo(0, _configure_Flip_Time_Set, Easing.CubicIn);

                await flip_digit_instance.down.RotateXTo(90, _configure_Flip_Time_Set, Easing.CubicIn);
                flip_digit_instance.down.Source = ImageSource.FromFile($"down_{newValue}");
                await flip_digit_instance.down.RotateXTo(0, _configure_Flip_Time_Set/5, Easing.CubicIn);

            }
        }

        public string Text {
            get { return (string) GetValue(TextProperty); }
            set {
                SetValue(TextProperty, value);
            }
        }
    }
}
