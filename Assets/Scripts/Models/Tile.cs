using HexFlip.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HexFlip.Model
{

    public class Tile
    {
        public event EventHandler Clicked;
        public event EventHandler IsHighlightedChanged;

        private bool _isHighlighted;

        public GridPosition GridPosition { get; private set; }
        public bool IsHighlighted
        {
            get => _isHighlighted;
            set
            {
                if (_isHighlighted != value)
                {
                    _isHighlighted = value;
                    OnIsHighlightedChanged();
                }
            }
        }

        public Tile(GridPosition gridPosition)
        {
            GridPosition = gridPosition;
        }

        public void Click()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnIsHighlightedChanged()
        {
            IsHighlightedChanged?.Invoke(this, EventArgs.Empty); ;
        }
    }

}
