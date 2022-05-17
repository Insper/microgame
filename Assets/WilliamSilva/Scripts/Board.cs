using UnityEngine;
using UnityEngine.Tilemaps;

/*
Credits to Zigurous for the original Tetris code.

Tutorial: https://www.youtube.com/watch?v=ODLzYI4d-J8
Source Code: https://github.com/zigurous/unity-tetris-tutorial 
*/
namespace WilliamSilva {
    public class Board : MonoBehaviour
    {
        private MicrogameInternal.GameManager gm;

        bool gameOver_ = false;

        public Tilemap tilemap { get; private set; }
        public WilliamSilva.Piece activePiece { get; private set; }
        public WilliamSilva.TetrominoData[] tetrominoes;
        public Vector3Int spawnPosition;
        public Vector2Int boardSize = new Vector2Int(18, 10);

        public RectInt Bounds
        {
            get
            {
                Vector2Int position = new Vector2Int(-this.boardSize.x / 2, -this.boardSize.y / 2);
                return new RectInt(position, this.boardSize);
            }
        }

        private void Awake()
        {
        
            this.tilemap = GetComponentInChildren<Tilemap>();
            this.activePiece = GetComponentInChildren<WilliamSilva.Piece>();

            for(int i = 0; i < this.tetrominoes.Length; i++)
            {
                this.tetrominoes[i].Initialize();
            }
        }

        private void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            gm.StartTimer();
            Invoke(nameof(EndGame), gm.MaxTime-0.1f);
            SpawnPiece();
        }

        public void SpawnPiece()
        {
            int random = Random.Range(0, this.tetrominoes.Length);
            WilliamSilva.TetrominoData data = this.tetrominoes[random];

            this.activePiece.Initialize(this, this.spawnPosition, data);

            if (IsValidPosition(this.activePiece, this.spawnPosition)){
                Set(this.activePiece);
            } else {
                GameOver();
                gameOver_ = true;
            }

        }

        private void EndGame()
        {
            if(gameOver_)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            gm.GameLost();
            // this.tilemap.ClearAllTiles();
            // Here I can do my things
        }

        public void Set(WilliamSilva.Piece piece)
        {
            for(int i = 0; i < piece.cells.Length; i++)
            {
                Vector3Int position = piece.cells[i] + piece.position;
                this.tilemap.SetTile(position, piece.data.tile);
            }
        }
        
        public void Clear(WilliamSilva.Piece piece)
        {
            for(int i = 0; i < piece.cells.Length; i++)
            {
                Vector3Int position = piece.cells[i] + piece.position;
                this.tilemap.SetTile(position, null);
            }
        }

        public bool IsValidPosition(WilliamSilva.Piece piece, Vector3Int position)
        {
            RectInt bounds = this.Bounds;

            for(int i = 0; i < piece.cells.Length; i++){
                Vector3Int tilePosition = piece.cells[i] + position;

                if (!bounds.Contains( (Vector2Int) tilePosition)) {
                    return false;
                }

                if(this.tilemap.HasTile(tilePosition)){
                    return false;
                }
            }

            return true;
        }

        public void ClearLines()
        {
            RectInt bounds = this.Bounds;
            int row = bounds.yMin;

            while (row < bounds.yMax)
            {
                if(IsLineFull(row)){
                    LineClear(row);
                } else {
                    row++;
                }
            }


        }

        private bool IsLineFull(int row)
        {
            RectInt bounds = this.Bounds;

            for(int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row, 0);
                if(!this.tilemap.HasTile(position))
                {
                    return false;
                }
            }

            return true;
        }

        private void LineClear(int row)
        {
            RectInt bounds = this.Bounds;
            for(int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row, 0);
                this.tilemap.SetTile(position, null);
            }

            while (row < bounds.yMax)
            {
                for(int col = bounds.xMin; col < bounds.xMax; col++)
                {
                    Vector3Int position = new Vector3Int(col, row + 1, 0);
                    TileBase above = this.tilemap.GetTile(position);
                    position = new Vector3Int(col, row, 0);

                    this.tilemap.SetTile(position, above);
                }

                row++;
            }

        }

    }
}
