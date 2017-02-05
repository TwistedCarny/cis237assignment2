using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        bool mazeSolved;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            PrintMaze(maze);

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            MazeTraversal(maze, xStart, yStart, xStart, yStart);
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void MazeTraversal(char[,] maze, int currentXPos, int currentYPos, int newXPos, int newYPos)
        {

            if (newXPos > -1 && newYPos > -1 & !mazeSolved)
            {
                if (newXPos != maze.GetUpperBound(0))
                {
                    if (maze[newYPos, newXPos] == '.')
                    {
                        currentXPos = newXPos;
                        currentYPos = newYPos;
                        maze[currentYPos, currentXPos] = 'x';
                        PrintMaze(maze);
                        MazeTraversal(maze, currentXPos, currentYPos, currentXPos + 1, currentYPos); // Move right
                        MazeTraversal(maze, currentXPos, currentYPos, currentXPos - 1, currentYPos); // Move left
                        MazeTraversal(maze, currentXPos, currentYPos, currentXPos, currentYPos + 1); // Move up
                        MazeTraversal(maze, currentXPos, currentYPos, currentXPos, currentYPos - 1); // Move down
                    }
                }
                else
                {
                    Console.WriteLine("Solved maze!");
                    mazeSolved = true;
                }
            }

        }

        private void PrintMaze(char[,] maze)
        {
            Console.WriteLine();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
