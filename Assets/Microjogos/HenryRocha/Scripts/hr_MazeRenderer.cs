// =========================================================================================
// Esse código foi retirado do tutorial:
// https://www.youtube.com/watch?v=ya1HyptE5uc
// "Maze Generation Unity Tutorial"
// Também existe o repositório do tutorial:
// https://github.com/gamedolphin/youtube_unity_maze/blob/master/Assets/Scripts/MazeGenerator.cs
// 
// 
// O código foi alterado para funcionar em um sistema 2D. Além disso, esse script controla
// a dificuldade do jogo, aumentando o tamanho do labirinto de acordo com o level atual.
// 
// =========================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hr_MazeRenderer : MonoBehaviour
{
    // The maze's width.
    private int width = 10;

    // The maze's height.
    private int height = 10;

    // The maze's cell size.
    private float size = 1f;

    [SerializeField]
    private Transform wallPrefab = null;

    [SerializeField]
    private Transform floorPrefab = null;

    [SerializeField]
    private Transform objectivePrefab = null;

    [SerializeField]
    private GameObject playerPrefab = null;

    [SerializeField]
    private hr_GameController controller;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Start()
    {
        // Pegando o nível atual.
        int level = controller.GetLevel();

        // Create the maze based on the current level.
        // But keep the size between 3 and 5, due to the time constraints.
        width = Mathf.Clamp(level + 2, 3, 5);
        height = Mathf.Clamp(level + 2, 3, 5);
        var maze = hr_MazeGenerator.Generate(width, height);

        // Depending on the level, change the size of each cell on the maze.
        // This is needed to make sure the maze fits on the screen.
        switch (level)
        {
            case 0:
                size = 2.5f;
                break;
            case 1:
                size = 2.5f;
                break;
            case 2:
                size = 1.75f;
                break;
            default:
                size = 1.5f;
                break;
        }

        // Instantiate all objects of the maze.
        Draw(maze);
    }

    /// <summary>
    /// Draws all the objects to the screen.
    /// </summary>
    private void Draw(WallState[,] maze)
    {
        // Draw the maze's background.
        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width * size, height * size, 0);

        // Loop through all the cells of the maze, creating all needed objects.
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                // Get the current cell and offset it's position so that the center of the maze is at 0,0.
                var cell = maze[i, j];
                var position = new Vector3(transform.position.x - width * size / 2 + i * size, transform.position.y - height * size / 2 + j * size, 0);

                // Draw the left wall.
                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;

                    leftWall.position = position + new Vector3(0, 0 + size / 2, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);

                    leftWall.eulerAngles = new Vector3(0, 0, 90);
                }

                // Draw the right wall.
                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;

                        rightWall.position = position + new Vector3(+size, 0 + size / 2, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);

                        rightWall.eulerAngles = new Vector3(0, 0, 90);
                    }
                }

                // Draw the top wall.
                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;

                    topWall.position = position + new Vector3(0 + size / 2, size, 0);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                // Draw the bottom wall.
                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;

                        bottomWall.position = position + new Vector3(size / 2, 0, 0);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }

                // Draw the objective.
                // Position of the objective is always at the top-right corner.
                if (i == width - 1 && j == height - 1)
                {
                    var objective = Instantiate(objectivePrefab, transform) as Transform;

                    objective.position = position + new Vector3(size / 2, size / 2, 0);
                    objective.localScale = new Vector3(size / 2, size / 2, objective.localScale.z);
                }

                // Draw the player.
                // Position of the player is always at the bottom-left corner.
                if (i == 0 && j == 0)
                {
                    GameObject player = Instantiate(playerPrefab, transform);

                    // Pass the controller to the player's object.
                    // This is needed because it's not possible to pass a reference of an
                    // object to a prefab (The player is a prefab).
                    player.GetComponent<hr_PlayerController>().controller = controller;

                    // We need the player's transform to position it correctly.
                    Transform playerTransform = player.GetComponent<Transform>();

                    playerTransform.position = position + new Vector3(size / 2, size / 2, 0);
                    playerTransform.localScale = new Vector3(size / 2, size / 2, playerTransform.localScale.z);
                }
            }
        }
    }
}
