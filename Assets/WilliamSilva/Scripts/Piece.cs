using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Credits to Zigurous for the original Tetris code.

Tutorial: https://www.youtube.com/watch?v=ODLzYI4d-J8
Source Code: https://github.com/zigurous/unity-tetris-tutorial 
*/
namespace WilliamSilva
{
    public class Piece : MonoBehaviour
    {
        private MicrogameInternal.GameManager gm;

        public WilliamSilva.Board board { get; private set; }
        public WilliamSilva.TetrominoData data { get; private set; }
        public Vector3Int[] cells { get; private set; }
        public Vector3Int position { get; private set; }
        public int rotationIndex { get; private set; }

        public float stepDelay;
        public float lockDelay = 0.1f;

        private float stepTime;
        private float lockTime;

        public void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            if (gm.ActiveLevel == 0) {
                stepDelay = 0.25f;
                print("LEVEL 1\n");
            } else if (gm.ActiveLevel == 1) {
                stepDelay = 0.1f;
                print("LEVEL 2\n");
            } else if(gm.ActiveLevel == 2) {
                stepDelay = 0.05f;
                print("LEVEL 3\n");
            }
        }

        public void Initialize(WilliamSilva.Board board, Vector3Int position, WilliamSilva.TetrominoData data)
        {

            this.board = board;
            this.position = position;
            this.data = data;
            this.rotationIndex = 0;
            this.stepTime = Time.time + this.stepDelay;
            this.lockTime = 0f;

            if (this.cells == null){
                this.cells = new Vector3Int[data.cells.Length];
            }

            for (int i = 0; i < data.cells.Length; i++)
            {
                this.cells[i] = (Vector3Int) data.cells[i];
            }
        }

        private void Update()
        {
            this.board.Clear(this);

            this.lockTime += Time.deltaTime;

            if(Input.GetKeyDown(KeyCode.UpArrow)){
                Rotate(1);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(Vector2Int.left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(Vector2Int.right);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move(Vector2Int.down);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                HardDrop();
            }

            if (Time.time >= this.stepTime)
            {
                Step();
            }

            this.board.Set(this);
        }

        private void Step(){
            this.stepTime = Time.time + this.stepDelay;

            Move(Vector2Int.down);

            if(this.lockTime >= this.lockDelay){
                Lock();
            }
        }

        private void Lock()
        {
            this.board.Set(this);
            this.board.ClearLines();
            this.board.SpawnPiece();
        }

        private void HardDrop()
        {
            while(Move(Vector2Int.down)){
                continue;
            }

            Lock();
        }

        private bool Move(Vector2Int translation)
        {
            Vector3Int newPosition = this.position;
            newPosition.x += translation.x;
            newPosition.y += translation.y;

            bool valid = this.board.IsValidPosition(this, newPosition);

            if (valid)
            {
                this.position = newPosition;
                this.lockTime = 0f;
            }
            
            return valid;
        }

        private void Rotate(int direction)
        {
            int originalRotationIndex = this.rotationIndex;
            this.rotationIndex = Wrap(this.rotationIndex + direction, 0, 4);

            ApplyRotation(direction);

            if (!TestWallKicks(this.rotationIndex, direction)){
                this.rotationIndex = originalRotationIndex;
                ApplyRotation(-direction);
            }
        }

        private void ApplyRotation(int direction){
            for (int i = 0; i < this.cells.Length; i++)
            {
                Vector3 cell = this.cells[i];
                int x, y;

                switch (this.data.tetromino)
                {
                    case WilliamSilva.Tetromino.I:
                    case WilliamSilva.Tetromino.O:
                        cell.x -= 0.5f;
                        cell.y -= 0.5f;
                        x = Mathf.CeilToInt((cell.x * WilliamSilva.Data.RotationMatrix[0] * direction) + (cell.y * WilliamSilva.Data.RotationMatrix[1] * direction));
                        y = Mathf.CeilToInt((cell.x * WilliamSilva.Data.RotationMatrix[2] * direction) + (cell.y * WilliamSilva.Data.RotationMatrix[3] * direction));
                        break;
                    default:
                        x = Mathf.RoundToInt((cell.x * WilliamSilva.Data.RotationMatrix[0] * direction) + (cell.y * WilliamSilva.Data.RotationMatrix[1] * direction));
                        y = Mathf.RoundToInt((cell.x * WilliamSilva.Data.RotationMatrix[2] * direction) + (cell.y * WilliamSilva.Data.RotationMatrix[3] * direction));
                        break;
                }
                this.cells[i] = new Vector3Int(x, y, 0);
            }
        }

        private bool TestWallKicks(int rotationIndex, int rotationDirection)
        {
            int wallKickIndex = GetWallKickIndex(rotationIndex, rotationDirection);

            for (int i = 0; i < data.wallKicks.GetLength(1); i++)
            {
                Vector2Int translation = data.wallKicks[wallKickIndex, i];

                if (Move(translation)) {
                    return true;
                }
            }

            return false;
        }

        private int GetWallKickIndex(int rotationIndex, int rotationDirection)
        {
            int wallKickIndex = rotationIndex * 2;

            if (rotationDirection < 0) {
                wallKickIndex--;
            }

            return Wrap(wallKickIndex, 0, data.wallKicks.GetLength(0));
        }

        private int Wrap(int input, int min, int max)
        {
            if (input < min) {
                return max - (min - input) % (max - min);
            } else {
                return min + (input - min) % (max - min);
            }
        }
    }
}
