using System;

namespace HexFlip.Model
{
    public class PieceEventArgs: EventArgs
    {
        public Piece Piece { get; }

        public PieceEventArgs(Piece piece)
        {
            Piece = piece;
        }

    }

    public class PositionEventArgs: EventArgs
    {
        public GridPosition GridPosition { get; }

        public PositionEventArgs(GridPosition gridPosition)
        {
            GridPosition = gridPosition;
        }
    }
}


