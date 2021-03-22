using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hr_MazeRenderer : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private int width = 10;

    [SerializeField]
    [Range(1, 50)]
    private int height = 10;

    [SerializeField]
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

    // Start is called before the first frame update
    void Start()
    {
        int level = controller.GetLevel();
        width = Mathf.Clamp(level + 2, 3, 5);
        height = Mathf.Clamp(level + 2, 3, 5);
        var maze = hr_MazeGenerator.Generate(width, height);
        Draw(maze);
    }

    private void Draw(WallState[,] maze)
    {
        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width * size, height * size, 0);

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(transform.position.x - width * size / 2 + i * size, transform.position.y - height * size / 2 + j * size, 0);

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;

                    leftWall.position = position + new Vector3(0, 0 + size / 2, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);

                    leftWall.eulerAngles = new Vector3(0, 0, 90);
                }

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

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;

                    topWall.position = position + new Vector3(0 + size / 2, size, 0);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;

                        bottomWall.position = position + new Vector3(size / 2, 0, 0);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }

                if (i == width - 1 && j == height - 1)
                {
                    var objective = Instantiate(objectivePrefab, transform) as Transform;
                    objective.position = position + new Vector3(size / 2, size / 2, 0);
                    objective.localScale = new Vector3(size / 2, size / 2, objective.localScale.z);
                }

                if (i == 0 && j == 0)
                {
                    GameObject player = Instantiate(playerPrefab, transform);

                    Transform playerTransform = player.GetComponent<Transform>();
                    player.GetComponent<hr_PlayerController>().controller = controller;

                    playerTransform.position = position + new Vector3(size / 2, size / 2, 0);
                    playerTransform.localScale = new Vector3(size / 2, size / 2, playerTransform.localScale.z);
                }
            }
        }
    }
}
