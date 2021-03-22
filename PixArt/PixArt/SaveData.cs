using System;
using System.Collections.Generic;
using System.Text;

namespace PixArt
{
    class SaveData
    {
        // This string will be used to store the name of pieces
       //public string SavedPixArtName { get; set; }

        // This int is used to store the dimensions of the array, only one int needs be stored as the grid shall always be square
        public int SavedGridSize { get; set; }

        // This string is used to store the arrays, as in my functions I have created code to convert the _piecePosition[,] array to and from the SavedPiecePositionArray string
        public string SavedPixelValueArray { get; set; }
    }
}
