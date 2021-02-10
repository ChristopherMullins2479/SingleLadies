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
        int _canvasHeight = 5;
        int _canvasWeidth = 5;
        int max_weidth = 300;
        int max_height = 300;
        int CanvasPannel_HEIGHT;
        int CanvasPannel_WIDTH;
        public MainPage()
        {
            InitializeComponent();
            GenerateGrid();
        }

        //Generate the Grid for the art
        private void GenerateGrid()
        {
            int CanvasPannel_HEIGHT = 50;
            int CanvasPannel_WIDTH = 50;

            //Grid Canvas = new Grid();
            Canvas.HeightRequest = _canvasHeight * CanvasPannel_HEIGHT;
            Canvas.WidthRequest = _canvasHeight * CanvasPannel_WIDTH;
            BoxView CanvasPannel;
            int r, c;
            int x, y;

            for(r = 0; r < _canvasHeight; r++)
            {
                Canvas.RowDefinitions.Add(new RowDefinition());
            }
            for (c = 0; c < _canvasWeidth; c++)
            {
                Canvas.ColumnDefinitions.Add(new ColumnDefinition());
            }

            //sets up canvas
            for (x = 0; x < _canvasHeight; x++)
            {
                for (y = 0; y < _canvasWeidth; y++)
                {
                    CanvasPannel = new BoxView();
                    CanvasPannel.HeightRequest = CanvasPannel_HEIGHT;
                    CanvasPannel.WidthRequest = CanvasPannel_WIDTH;
                    CanvasPannel.BackgroundColor = Color.White;
                    CanvasPannel.SetValue(Grid.RowProperty, x);
                    CanvasPannel.SetValue(Grid.ColumnProperty, y);
                    Canvas.Children.Add(CanvasPannel);
                }
                
            }

        }
    }
}
