// =========================================================================================
// Esse código foi retirado do tutorial:
// https://www.youtube.com/watch?v=ya1HyptE5uc
// "Maze Generation Unity Tutorial"
// Também existe o repositório do tutorial:
// https://github.com/gamedolphin/youtube_unity_maze/blob/master/Assets/Scripts/MazeGenerator.cs
// 
// O Algoritmo usado para gerar os labirintos é o Recursive Backtracker.
// A implementação é baseada em uma matriz de 2 dimensões. Cada elemento da matriz contém
// um struct WallState.
// O WallState representa quais paredes existem em um determinado elemento, além de guardar
// se aquele elemento já foi visitado.
// 
// =========================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum WallState
{
    // A representação da parede é feita usando bits, por isso cada
    // valor é uma potência de 2.
    // Caso uma célula tenha todas as paredes e já tenha sido visitada
    // esse será o WallState dela: 1000 1111
    LEFT = 1, // 0000 0001
    RIGHT = 2, // 0000 0010
    UP = 4, // 0000 0100
    DOWN = 8, // 0000 1000
    VISITED = 128, // 1000 0000
}

public struct Position
{
    // Struct usado para guardar qual a posição atual no labirinto.
    public int X;
    public int Y;
}

public struct Neighbour
{
    // Struct que indica o vizinho de uma célula.

    // Posição do visinho.
    public Position Position;

    // Paredes compartilhadas com o vizinho.
    public WallState SharedWall;
}

public static class hr_MazeGenerator
{
    // Gets the opposite wall of a shared wall.
    private static WallState GetOppositeWall(WallState wall)
    {
        switch (wall)
        {
            case WallState.RIGHT: return WallState.LEFT;
            case WallState.LEFT: return WallState.RIGHT;
            case WallState.UP: return WallState.DOWN;
            case WallState.DOWN: return WallState.UP;
            default: return WallState.LEFT;
        }
    }


    private static WallState[,] ApplyRecursiveBacktracker(WallState[,] maze, int width, int height)
    {
        // A random generator is needed to choose a random position.
        // Generates the starting position.
        // If a seed is given, it makes the mazes reproducible.
        var rng = new System.Random(/*seed*/);

        // Stack of positions.
        var positionStack = new Stack<Position>();

        // Create a random position.
        var position = new Position { X = rng.Next(0, width), Y = rng.Next(0, height) };

        // Marks the starting position as visited.
        maze[position.X, position.Y] |= WallState.VISITED; // The state will be: 1000 1111.
        positionStack.Push(position);

        // While there are position on the stack...
        while (positionStack.Count > 0)
        {
            // Get the last position added to the stack.
            var current = positionStack.Pop();

            // Get all the neighbours of the current position.
            var neighbours = GetUnvisitedNeighbours(current, maze, width, height);

            // If the cell has neighbours, it means that are still cells which have not
            // been visited yet.
            if (neighbours.Count > 0)
            {
                // Add the current position back to the stack.
                positionStack.Push(current);

                // Take a random neighbour of the current position.
                var randIndex = rng.Next(0, neighbours.Count);
                var randomNeighbour = neighbours[randIndex];
                var nPosition = randomNeighbour.Position;

                // Remove the shared wall between the current cell and it's neighbour.
                maze[current.X, current.Y] &= ~randomNeighbour.SharedWall;

                // Remove the shared wall on the neighbour.
                // (The shared wall is opposite of the current cell's wall.)
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbour.SharedWall);

                // Marks this neighbour as visited.
                maze[nPosition.X, nPosition.Y] |= WallState.VISITED;

                // Add the neighbour to the stack.
                positionStack.Push(nPosition);
            }
        }

        return maze;
    }

    // Gera uma lista de vizinhos que ainda não foram visitados.
    private static List<Neighbour> GetUnvisitedNeighbours(Position p, WallState[,] maze, int width, int height)
    {
        // List of neighbours.
        var list = new List<Neighbour>();

        // Checks the left wall.
        // This is needed to prevent deleting the left border of the maze.
        if (p.X > 0)
        {   
            // Verify if the cell to left has already been visited,
            // if not, add it to the list of neighbours.
            if (!maze[p.X - 1, p.Y].HasFlag(WallState.VISITED))
            {
                // Create a new neighbour, with the shared wall on the left.
                list.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    SharedWall = WallState.LEFT
                });
            }
        }

        // Checks the bottom wall.
        // This is needed to prevent deleting the bottom border of the maze.
        if (p.Y > 0)
        {
            // Verify if the cell to the bottom has already been visited,
            // if not, add it to the list of neighbours.
            if (!maze[p.X, p.Y - 1].HasFlag(WallState.VISITED))
            {
                // Create a new neighbour, with the shared wall on the bottom.
                list.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y - 1
                    },
                    SharedWall = WallState.DOWN
                });
            }
        }

        // Checks the top wall.
        // This is needed to prevent deleting the top border of the maze.
        if (p.Y < height - 1)
        {
            // Verify if the cell to the top has already been visited,
            // if not, add it to the list of neighbours.
            if (!maze[p.X, p.Y + 1].HasFlag(WallState.VISITED))
            {
                // Create a new neighbour, with the shared wall on the top.
                list.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y + 1
                    },
                    SharedWall = WallState.UP
                });
            }
        }

        // Checks the right wall.
        // This is needed to prevent deleting the right border of the maze.
        if (p.X < width - 1)
        {   
            // Verify if the cell to the right has already been visited,
            // if not, add it to the list of neighbours.
            if (!maze[p.X + 1, p.Y].HasFlag(WallState.VISITED))
            {
                // Create a new neighbour, with the shared wall on the right.
                list.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X + 1,
                        Y = p.Y
                    },
                    SharedWall = WallState.RIGHT
                });
            }
        }

        return list;
    }

    // Create a 2D array of WallStates..
    public static WallState[,] Generate(int width, int height)
    {
        // Create the maze variable, a 2D array of size width x height.
        WallState[,] maze = new WallState[width, height];

        // The initial state of each cell of the maze.
        WallState initial = WallState.RIGHT | WallState.LEFT | WallState.UP | WallState.DOWN;

        // Fill the maze with the initial state.
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                maze[i, j] = initial;
            }
        }

        return ApplyRecursiveBacktracker(maze, width, height);
        // return maze;
    }
}
