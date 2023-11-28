using Chess.Model;
using HexFlip.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace HexFlip.Model
{
    public class Piece
    {
        public event EventHandler PositionChanged;
        public event EventHandler IsHighLightedChanged;
        public event EventHandler Removed;

        public PieceType PieceType => _type;
        public PlayerColor PlayerColor => _color; 

        public GridPosition GridPosition 
        { 
            get => _gridPosition;
            set 
            {
                if(_gridPosition == value)
                    return;
                _gridPosition = value;
                PositionChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GridPosition)));
            }
        }
        public bool IsHighLighted
        {
            get => _isHighLighted;
            set
            {
                if( _isHighLighted == value) 
                    return;
                _isHighLighted = value;
                IsHighLightedChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private GridPosition _gridPosition;
        private bool _isHighLighted = false;
        private readonly Board _board;
        private readonly GridPosition _position;
        private readonly PlayerColor _color;
        private readonly PieceType _type;


        public Piece(Board board, GridPosition pos, PieceType type, PlayerColor color)
        {
            this._board = board;
            this._position = pos;
            this._type = type;
            this._color = color;
        }

        public void Click()
        {
            _board.PieceClicked(this);
        }

        public void Remove()
        {
            Removed?.Invoke(this, EventArgs.Empty);
        }
    }

}
