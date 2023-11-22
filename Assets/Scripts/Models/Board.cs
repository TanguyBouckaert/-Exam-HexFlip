using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexFlip.Model
{
    public class Board
    {
        public Tile AddTile(GridPosition position)
        {
            //TODO: Implement AddTile
            return null;
        }

        public void Tile_Clicked(object sender, Sytem.EventArgs e)
        {
            //TODO: Implement HighLight of tile when clicked.s
        }

        internal void PieceClicked(Piece piece1, object piece2)
        {
            //TODO: Notify game piece is clicked
        }
    }
}


