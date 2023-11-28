using Chess.Model;
using HexFlip.Helper;
using HexFlip.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace HexFlip.View
{
    public class PieceView : MonoBehaviour, IPointerClickHandler
    {
        public PieceType PieceType;
        public PlayerColor PlayerColor;

        public Piece PieceModel { get; private set; }


        [SerializeField]
        private MeshRenderer _renderer;
        [SerializeField]
        private Material _highlightMaterial;

        private Material _defaultMaterial;


        private void Awake()
        {
            Assert.IsNotNull(_renderer);
            Assert.IsNotNull(_highlightMaterial);

            _defaultMaterial = _renderer.sharedMaterial;
        }

        public void SetModel(Piece piece)
        {
            PieceModel = piece;
            piece.IsHighLightedChanged += Piece_IsHighLightedChanged;
            piece.PositionChanged += Piece_PositionChanged;
            piece.Removed += Piece_Removed;
        }

        //Events
        #region Events
        public void OnPointerClick(PointerEventData eventData)
        {
            PieceModel.Click();
        }

        private void Piece_PositionChanged(object sender, EventArgs e)
        {
            transform.position = PositionHelper.GridPositionToWorld(PieceModel.GridPosition);
        }

        private void Piece_IsHighLightedChanged(object sender, EventArgs e)
        {
            _renderer.sharedMaterial = PieceModel.IsHighLighted ? _highlightMaterial : _defaultMaterial;
        }

        public void Piece_Removed(object sender, System.EventArgs e)
        {
            Destroy(this.gameObject);
        }
        #endregion

        //Destroy piece logic
        private void OnDestroy()
        {
            PieceModel.IsHighLightedChanged -= Piece_IsHighLightedChanged;
            PieceModel.PositionChanged -= Piece_PositionChanged;
            PieceModel.Removed -= Piece_Removed;
        }
    }
}


