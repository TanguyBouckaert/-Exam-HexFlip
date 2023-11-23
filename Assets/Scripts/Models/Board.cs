using Chess.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexFlip.Model
{
    public class Board
    {
        public event EventHandler<PositionEventArgs> PositionClicked;
        public event EventHandler<PieceEventArgs> PieceSpawned;

        private Dictionary<GridPosition, Tile> _tiles = new Dictionary<GridPosition, Tile>();
        private Dictionary<GridPosition, Tile> _pieces = new Dictionary<GridPosition, Piece>();

        public Tile AddTile(GridPosition position)
        {
            Tile tile = new Tile(position);
            tile.Clicked += Tile_Clicked;
            _tiles.Add(position, tile);
            return tile;
        }

        //Clicking Logic (Tile and Piece)
        public void Tile_Clicked(object sender, System.EventArgs e)
        {
            //highlight the tile
            if(sender is Tile tileModel)
            {
                //Notify that tile is clicked
                PositionClicked?.Invoke(this, new PositionEventArgs(tileModel.GridPosition));
            }
        }

        internal void PieceClicked(Piece piece)
        {
            //Notify game piece is clicked
            PositionClicked?.Invoke(this, new PositionEventArgs(piece.GridPosition));
        }

        //Spawn, move and remove pieces
        public Piece SpawnPiece(GridPosition pos, PieceType type, PlayerColor color)
        {
            Piece piece = new Piece(this, pos, type, color);
            _pieces.Add(pos, piece);
            PieceSpawned?.Invoke(this, new PieceEventArgs(piece));

            return piece;
        }

        public void RemovePiece(GridPosition pos)
        {
            if (_pieces.ContainsKey(pos))
            {
                _pieces[pos].Remove(); 
                _pieces.Remove(pos);
            }
        }

        public void MovePiece(GridPosition fromPos, GridPosition toPos)
        {
            if(_pieces.TryGetValue(fromPos, out Piece piece))
            {
                piece.GridPosition = toPos;
                _pieces.Remove(fromPos);
                _pieces.Add(toPos, piece);
            }
        }

        //Highlight, GetPieceOnPosition, GetTileOnPosition
        public Piece GetPieceOnPosition(GridPosition position)
        {
            return _pieces.GetValueOrDefault(position);
        }

        public Tile GetTileOnPosition(GridPosition position)
        {
            return _tiles.GetValueOrDefault(position);
        }

        public void HighlightTiles(List<GridPosition> positions)
        {
            foreach (Tile tile in _tiles.Values)
            {
                tile.IsHighlighted = false;
            }

            foreach (GridPosition pos in positions)
            {
                Tile tile = GetTileOnPosition(pos);
                if (tile == null) continue;

                tile.IsHighlighted = true;
            }
        }
    }
}


