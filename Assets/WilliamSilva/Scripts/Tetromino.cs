using UnityEngine;
using UnityEngine.Tilemaps;

/*
Credits to Zigurous for the original Tetris code.

Tutorial: https://www.youtube.com/watch?v=ODLzYI4d-J8
Source Code: https://github.com/zigurous/unity-tetris-tutorial 
*/
namespace WilliamSilva {
    public enum Tetromino
    {
        I,
        O,
        T,
        J,
        L,
        S,
        Z,
    }

    [System.Serializable]
    public struct TetrominoData
    {
        public WilliamSilva.Tetromino tetromino;
        public Tile tile;
        public Vector2Int[] cells { get; private set; }
        public Vector2Int[,] wallKicks { get; private set; }

        public void Initialize()
        {
            this.cells = WilliamSilva.Data.Cells[this.tetromino];
            this.wallKicks = WilliamSilva.Data.WallKicks[this.tetromino];
        }
    }
}