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
        const int ROWS = 16;
        const int COLS = 16;
        const int COLOURROW = 2;
        const int COLOURCOL = 8;
        string selectedColour = "000000", savedPixels;
        string[,] _coloursStored = new string[ROWS, COLS];


        public MainPage()
        {
            InitializeComponent();
            InitializeBoard();
            CreateNormalColourSelector();
        }

        private void CreateNormalColourSelector()
        {
            int iR, iC;
            double squareSize;
            BoxView bv;
            TapGestureRecognizer ColorTapGR;

            ColorTapGR = new TapGestureRecognizer();
            ColorTapGR.Tapped += ColorTapGR_Tapped;

            int ColourNumber = 0;

            //loops to create rows and colums for thr grid
            for (iR = 0; iR < COLOURROW; iR++)
            {
                ColourSelector.RowDefinitions.Add(new RowDefinition());
            }
            for (iC = 0; iC < COLOURCOL; iC++)
            {
                ColourSelector.ColumnDefinitions.Add(new ColumnDefinition());
            }

            squareSize = PixelArtBoard.HeightRequest / ROWS;

            //This adds boxviews to the grid that the user will interact with to create their art
            for (iR = 0; iR < COLOURROW; iR++)
            {
                for (iC = 0; iC < COLOURCOL; iC++)
                {
                    ColourNumber = iC + (iR *8);
                    bv = new BoxView();
                    bv.SetValue(Grid.ColumnProperty, iC);
                    bv.SetValue(Grid.RowProperty, iR);
                    //bv.BackgroundColor = Color.FromHex(coloursStored[iR, iC]);
                    bv.BackgroundColor = Color.White;
                    _coloursStored[iR, iC] = "FFFFFF";
                    bv.ClassId = "Square";
                    bv.HeightRequest = squareSize;
                    bv.WidthRequest = squareSize;
                    bv.HorizontalOptions = LayoutOptions.Center;
                    bv.VerticalOptions = LayoutOptions.Center;
                    bv.GestureRecognizers.Add(ColorTapGR);
                    SetBackgroundForColourMenue(ColourNumber,bv);
                    ColourSelector.Children.Add(bv);
                }
            }
        }

        //Using a formala this sets colours to the colour picker Grid
        private void SetBackgroundForColourMenue(int ColourNumber,BoxView bv)
        {
            //sets the colours in the basic colour menue
            #region Colour menu setup
            switch(ColourNumber)
            {
                case 0:
                    bv.BackgroundColor = Color.FromRgb(0, 0, 0);//value for black
                    break;
                case 1:
                    bv.BackgroundColor = Color.FromRgb(255, 255, 255);//Value for white
                    break;
                case 2:
                    bv.BackgroundColor = Color.FromRgb(255, 0, 0);//value for red
                    break;
                case 3:
                    bv.BackgroundColor = Color.FromRgb(0, 255, 0);//value for green
                    break;
                case 4:
                    bv.BackgroundColor = Color.FromRgb(0, 0, 255);//value for blue
                    break;
                case 5:
                    bv.BackgroundColor = Color.FromRgb(255, 255, 0);//value for yellow
                    break;
                case 6:
                    bv.BackgroundColor = Color.FromRgb(0, 255, 255);//value for cyan
                    break;
                case 7:
                    bv.BackgroundColor = Color.FromRgb(255, 0, 255);//value for magenta
                    break;
                case 8:
                    bv.BackgroundColor = Color.FromRgb(192, 192, 192);//value for silver
                    break;
                case 9:
                    bv.BackgroundColor = Color.FromRgb(128, 128, 128);//value for gray
                    break;
                case 10:
                    bv.BackgroundColor = Color.FromRgb(128, 0, 0);//value for magenta
                    break;
                case 11:
                    bv.BackgroundColor = Color.FromRgb(128, 128, 0);//value for olive
                    break;
                case 12:
                    bv.BackgroundColor = Color.FromRgb(0, 128, 0);//value for green
                    break;
                case 13:
                    bv.BackgroundColor = Color.FromRgb(128, 0, 128);//value for purple
                    break;
                case 14:
                    bv.BackgroundColor = Color.FromRgb(0, 128, 128);//value for teal
                    break;
                case 15:
                    bv.BackgroundColor = Color.FromRgb(0, 0, 128);//value for navey
                    break;
            }
            #endregion
            #region commentedOutCode
            /*if (ColourNumber == 0)
            {
                bv.BackgroundColor = Color.FromRgb(0, 0, 0);//value for black
            }
           else if(ColourNumber == 1)
            {
                bv.BackgroundColor = Color.FromRgb(255, 255, 255);//Value for white
            }
            else if (ColourNumber == 2)
            {
                bv.BackgroundColor = Color.FromRgb(255, 0, 0);//value for red
            }
            else if (ColourNumber == 3)
            {
                bv.BackgroundColor = Color.FromRgb(0, 255, 0);//value for green
            }
            else if (ColourNumber == 4)
            {
                bv.BackgroundColor = Color.FromRgb(0, 0, 255);//value for blue
            }
            else if (ColourNumber == 5)
            {
                bv.BackgroundColor = Color.FromRgb(255, 255, 0);//value for yellow
            }
            else if (ColourNumber == 6)
            {
                bv.BackgroundColor = Color.FromRgb(0, 255, 255);//value for cyan
            }
            else if (ColourNumber == 7)
            {
                bv.BackgroundColor = Color.FromRgb(255, 0, 255);//value for magenta
            }
            else if (ColourNumber == 8)
            {
                bv.BackgroundColor = Color.FromRgb(192, 192, 192);//value for silver
            }
            else if (ColourNumber == 9)
            {
                bv.BackgroundColor = Color.FromRgb(128, 128, 128);//value for gray
            }
            else if (ColourNumber == 10)
            {
                bv.BackgroundColor = Color.FromRgb(128, 0, 0);//value for magenta
            }
            else if (ColourNumber == 11)
            {
                bv.BackgroundColor = Color.FromRgb(128, 128, 0);//value for olive
            }
            else if (ColourNumber == 12)
            {
                bv.BackgroundColor = Color.FromRgb(0, 128, 0);//value for green
            }
            else if (ColourNumber == 13)
            {
                bv.BackgroundColor = Color.FromRgb(128, 0, 128);//value for purple
            }
            else if (ColourNumber == 14)
            {
                bv.BackgroundColor = Color.FromRgb(0, 128, 128);//value for teal
            }
            else if (ColourNumber == 15)
            {
                bv.BackgroundColor = Color.FromRgb(0, 0, 128);//value for navey
            }*/
            #endregion
        }

        //Runs when the user selects a colour from the colour menue
        private void ColorTapGR_Tapped(object sender, EventArgs e)
        {
            int fromR, fromC;
            int valueofcolour;
            BoxView BasicColourPicked = (BoxView)sender;

            fromR = (int)BasicColourPicked.GetValue(Grid.RowProperty);
            fromC = (int)BasicColourPicked.GetValue(Grid.ColumnProperty);

            valueofcolour = fromC + (fromR * 8);

            #region Colour Picker
            switch (valueofcolour)
            {
                case 0:
                    r = 0;
                    g = 0;
                    b = 0;
                    SetcolourFromMenue(r, g, b);
                    break; // Black
                case 1:
                    r = 255;
                    g = 255;
                    b = 255;
                    SetcolourFromMenue(r, g, b);
                    break; // White
                case 2:
                    r = 255;
                    g = 0;
                    b = 0;
                    SetcolourFromMenue(r, g, b);
                    break; // Red
                case 3:
                    r = 0;
                    g = 255;
                    b = 0;
                    SetcolourFromMenue(r, g, b);
                    break; // Green
                case 4:
                    r = 0;
                    g = 0;
                    b = 255;
                    SetcolourFromMenue(r, g, b);
                    break; // Blue
                case 5:
                    r = 255;
                    g = 255;
                    b = 0;
                    SetcolourFromMenue(r, g, b);
                    break; // Yellow
                case 6:
                    r = 0;
                    g = 255;
                    b = 255;
                    SetcolourFromMenue(r, g, b);
                    break; // Cyan
                case 7:
                    r = 255;
                    g = 0;
                    b = 255;
                    SetcolourFromMenue(r, g, b);
                    break; // Magenta
                case 8:
                    r = 192;
                    g = 192;
                    b = 192;
                    SetcolourFromMenue(r, g, b);
                    break; // Silver
                case 9:
                    r = 128;
                    g = 128;
                    b = 128;
                    SetcolourFromMenue(r, g, b);
                    break; // Grey
                case 10:
                    r = 128;
                    g = 0;
                    b = 0;
                    SetcolourFromMenue(r, g, b);
                    break; // Maroon
                case 11:
                    r = 128;
                    g = 128;
                    b = 0;
                    SetcolourFromMenue(r, g, b);
                    break; // Olive
                case 12:
                    r = 0;
                    g = 128;
                    b = 0;
                    SetcolourFromMenue(r, g, b);
                    break; // Dark-Green
                case 13:
                    r = 128;
                    g = 0;
                    b = 128;
                    SetcolourFromMenue(r, g, b);
                    break; // Purple
                case 14:
                    r = 0;
                    g = 128;
                    b = 128;
                    SetcolourFromMenue(r, g, b);
                    break; // Teal
                case 15:
                    r = 0;
                    g = 0;
                    b = 128;
                    SetcolourFromMenue(r, g, b);
                    break; // Navy

            }
            #endregion
            #region IfBranch
            if (valueofcolour == 0)//black
            {
                r = 0;
                g = 0;
                b = 0;
                SetcolourFromMenue(r, g, b);  
            }
            else if (valueofcolour == 1)//white
            {
                r = 255;
                g = 255;
                b = 255;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 2)//red
            {
                r = 255;
                g = 0;
                b = 0;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 3)//green
            {
                r = 0;
                g = 255;
                b = 0;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 4)//blue
            {
                r = 0;
                g = 0;
                b = 255;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 5)//yellow
            {
                r = 255;
                g = 255;
                b = 0;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 6)//cyan
            {
                r = 0;
                g = 255;
                b = 255;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 7)//magenta
            {
                r = 255;
                g = 0;
                b = 255;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 8)//silver
            {
                r = 192;
                g = 192;
                b = 192;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 9)//gray
            {
                r = 128;
                g = 128;
                b = 128;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 10)//marone
            {
                r = 128;
                g = 0;
                b = 0;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 11)//olive
            {
                r = 128;
                g = 128;
                b = 0;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 12)//dark green
            {
                r = 0;
                g = 128;
                b = 0;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 13)//purple
            {
                r = 128;
                g = 0;
                b = 128;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 14)//teal
            {
                r = 0;
                g = 128;
                b = 128;
                SetcolourFromMenue(r, g, b);
            }
            else if (valueofcolour == 15)//navey
            {
                r = 0;
                g = 0;
                b = 128;
                SetcolourFromMenue(r, g, b);
            }
            #endregion

        }
        //method to set colour rgb values
        private void SetcolourFromMenue(int r, int g,int b)
        {
            i1 = r;
            i2 = g;
            i3 = b;

            //Red_Slider.Value = i1;
            //Green_Slider.Value = i2;
            //Blue_Slider.Value = i3;

            SampleColour.BackgroundColor = Color.FromRgb(i1, i2, i3);
            selectedColour = i1.ToString("X2");
            selectedColour += i2.ToString("X2");
            selectedColour += i3.ToString("X2");
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
                    bv.BackgroundColor = Color.FromHex("FFFFFF");
                    _coloursStored[iR, iC] = "FFFFFF";
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

        // Note: SelectColour Function was obsoleted by Slider_ValueChanged Function
        private void SelectColour(object sender, EventArgs E)
        {
            //selectedColour = "";
            //selectedColour += pckFirstChar.SelectedIndex.ToString("X1");
            //selectedColour += pckSecondChar.SelectedIndex.ToString("X1");
            //selectedColour += pckThirdChar.SelectedIndex.ToString("X1");
            //selectedColour += pckFourthChar.SelectedIndex.ToString("X1");
            //selectedColour += pckFifthChar.SelectedIndex.ToString("X1");
            //selectedColour += pckSixthChar.SelectedIndex.ToString("X1");

            //if (selectedColour.Length >6)
            //{
            //    return;
            //}
            //SampleColour.BackgroundColor = Color.FromHex(selectedColour);
        }

        //Runs as the user moves the RGB sliders
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            v1 = Double.Parse(RedValue.Text);
            v2 = Double.Parse(GreenValue.Text);
            v3 = Double.Parse(BlueValue.Text);

            i1 = (int)Math.Truncate(v1);
            i2 = (int)Math.Truncate(v2);
            i3 = (int)Math.Truncate(v3);

            SampleColour.BackgroundColor = Color.FromRgb(i1, i2, i3);

            selectedColour = i1.ToString("X2");
            selectedColour += i2.ToString("X2");
            selectedColour += i3.ToString("X2");
        }

        //Runs when the user taps a square on the canvas
        private void PixelTapGR_Tapped(object sender, EventArgs E)
        {
            int fromR, fromC;
            BoxView pixelToPaint = (BoxView)sender;

            pixelToPaint.BackgroundColor = Color.FromRgb(i1, i2, i3);
            fromR = (int)pixelToPaint.GetValue(Grid.RowProperty);
            fromC = (int)pixelToPaint.GetValue(Grid.ColumnProperty);

            _coloursStored[fromR, fromC] = selectedColour;
        }

        private void savePixArt(object sender, EventArgs E)
        {
            int iR, iC;

            savedPixels = "";
            for (iR = 0; iR < ROWS; iR++)
            {
                for (iC = 0; iC < COLS; iC++)
                {
                    savedPixels += _coloursStored[iR, iC];
                }
            }
            //DisplayAlert("Output", savedPixels + " String length was: " + savedPixels.Length, "leave");
            return;
        }

        private void loadPixArt(object sender, EventArgs E)
        {
            int iR, iC, fromR, fromC, j, stringIncrement, expectedLength;
            string currentPixelColour;
            BoxView pixelToModify;

            expectedLength = ROWS * COLS * 6;
            stringIncrement = 0;

            if (savedPixels.Length == expectedLength)
            {
                //DisplayAlert("Success", "String length was " + savedPixels.Length, "leave");
                for (iR = 0; iR < ROWS; iR++)
                {
                    for (iC = 0; iC < COLS; iC++)
                    {
                        currentPixelColour = "";
                        for (j = 0; j < 6; j++)
                        {
                            currentPixelColour += savedPixels[stringIncrement++];
                        }
                        _coloursStored[iR, iC] = currentPixelColour;
                    }
                }
                for (j = PixelArtBoard.Children.Count - 1; j >= 0; j--)
                {
                    pixelToModify = (BoxView)PixelArtBoard.Children[j];
                    fromR = (int)pixelToModify.GetValue(Grid.RowProperty);
                    fromC = (int)pixelToModify.GetValue(Grid.ColumnProperty);
                    pixelToModify.BackgroundColor = Color.FromHex(_coloursStored[fromR, fromC]);
                }
            }
            else
            {
                //DisplayAlert("Oops", "String of sufficient length not found, string length was: " + savedPixels.Length, "leave");
            }
        }
    }
}

