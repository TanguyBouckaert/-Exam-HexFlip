using Chess.Model;
using HexFlip.Helper;
using HexFlip.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HexFlip.View
{

    public class BoardView : MonoBehaviour
    {
        [SerializeField]
        private PieceView[] _piecePrefabs;

        public Board BoardModel { get; private set; }

        private void Awake()
        {
              
        }

        private void BoardModel_PieceSpawned(object sender, PieceEventArgs e)
        {
            Piece pieceModel = e.Piece;

            PieceView prefab = _piecePrefabs
                .Where(p => p.PieceType == pieceModel.PieceType && p.PlayerColor == pieceModel.PlayerColor)
                .FirstOrDefault();

            Vector3 worldPos = PositionHelper.GridPositionToWorld(pieceModel.GridPosition);
            Quaternion rot = Quaternion.identity;

            if(pieceModel.PlayerColor == PlayerColor.Black)
            {
                rot = Quaternion.Euler(0, 180, 0);
            }

            GameObject spawnedPieceObject = GameObject.Instantiate(prefab.gameObject, PositionHelper.GridPositionToWorld(pieceModel.GridPosition), rot);
            spawnedPieceObject.GetComponent<PieceView>().SetModel(pieceModel);
        }
    }
}

