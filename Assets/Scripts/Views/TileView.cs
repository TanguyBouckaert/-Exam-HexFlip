using HexFlip.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace HexFlip.View
{

    public class TileView : MonoBehaviour, IPointerClickHandler
    {
        public Tile TileModel { get; private set; }

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

        public void SetModel(Tile tile)
        {
            TileModel = tile;
            tile.IsHighlightedChanged += Tile_IsHighlightedChanged;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Tile {gameObject} is on {TileModel.GridPosition}");
            TileModel.Click();
        }

        private void Tile_IsHighlightedChanged(object sender, EventArgs e)
        {
            _renderer.sharedMaterial = TileModel.IsHighlighted ? _highlightMaterial : _defaultMaterial;
        }
    }

}
