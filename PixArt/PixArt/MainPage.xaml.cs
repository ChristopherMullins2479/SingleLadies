using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PixArt
{
    public partial class MainPage : ContentPage
    {
        //global variables
        int r, g, b;
        double v1, v2, v3;
        int i1, i2, i3;
        const int ROWS = 8;
        const int COLS = 8;
        string selectedColour;


        public MainPage()
        {
            InitializeComponent();
            InitializeBoard();
        }

        //Creates grid to store the canvas
        private void InitializeBoard()
        {
            int iR, iC;
            double squareSize;
            BoxView bv;
            TapGestureRecognizer PixelTapGR;

            PixelTapGR = new TapGestureRecognizer();
            PixelTapGR.Tapped += PixelTapGR_Tapped;

            //loops to create rows and colums for thr grid
            for (iR = 0; iR < ROWS; iR++)
            {
                PixelArtBoard.RowDefinitions.Add(new RowDefinition());
            }
            for (iC = 0; iC < COLS; iC++)
            {
                PixelArtBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }

            squareSize = PixelArtBoard.HeightRequest / ROWS;

            //This adds boxviews to the gris that the user will interact with to create their art
            for (iR = 0; iR < ROWS; iR++)
            {
                for (iC = 0; iC < COLS; iC++)
                {
                    bv = new BoxView();
                    bv.SetValue(Grid.ColumnProperty, iC);
                    bv.SetValue(Grid.RowProperty, iR);
                    //bv.BackgroundColor = Color.FromHex(coloursStored[iR, iC]);
                    bv.BackgroundColor = Color.FromHex("ffffff");
                    bv.ClassId = "Square";
                    bv.HeightRequest = squareSize;
                    bv.WidthRequest = squareSize;
                    bv.HorizontalOptions = LayoutOptions.Center;
                    bv.VerticalOptions = LayoutOptions.Center;
                    bv.GestureRecognizers.Add(PixelTapGR);

                    PixelArtBoard.Children.Add(bv);
                }
            }
        }

        private void SelectColour(object sender, EventArgs E)
        {
            //selectedColour = "";
            //selectedColour += pckFirstChar.SelectedIndex.ToString("X1");
            //selectedColour += pckSecondChar.SelectedIndex.ToString("X1");
            //selectedColour += pckThirdChar.SelectedIndex.ToString("X1");
            //selectedColour += pckFourthChar.SelectedIndex.ToString("X1");
            //selectedColour += pckFifthChar.SelectedIndex.ToString("X1");
            //selectedColour += pckSixthChar.SelectedIndex.ToString("X1");

            //if (selectedColour.Length > 6)
            //{
            //    return;
            //}
            //SampleColour.BackgroundColor = Color.FromHex(selectedColour);
        }

        //converts the decimal values of the slider to whole numbers

        //rens as the user moves the RGB sliders
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            v1 = Double.Parse(RedValue.Text);
            v2 = Double.Parse(GreenValue.Text);
            v3 = Double.Parse(BlueValue.Text);

            i1 = (int)Math.Truncate(v1);
            i2 = (int)Math.Truncate(v2);
            i3 = (int)Math.Truncate(v3);

            SampleColour.BackgroundColor = Color.FromRgb(i1, i2, i3);

        }

        //Runs when the user taps a square on the canvas
        private void PixelTapGR_Tapped(object sender, EventArgs E)
        {
            BoxView pixelToPaint = (BoxView)sender;

            pixelToPaint.BackgroundColor = Color.FromRgb(i1,i2,i3);
        }

    }
}

