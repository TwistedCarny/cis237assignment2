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
        bool solved;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        { }


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

            PrintMaze(maze); // Print the blank maze

            solved = false;

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            MazeTraversal(maze, xStart, yStart);

            Console.WriteLine("The maze has been solved!");

        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void MazeTraversal(char[,] maze, int xPos, int yPos)
        {
            if (xPos > -1 && yPos > -1 && !solved)
            {
                if(xPos == maze.GetLength(1) | yPos == maze.GetLength(0)) // Check to see if we're at the end of the maze
                {
                    solved = true;
                    return; // Return because we don't need to try to move any more
                }

                if (maze[yPos, xPos] == '.' && !solved)
                {
                    maze[yPos, xPos] = 'X'; // Mark spot on sucessful path
                    PrintMaze(maze); // Print the maze after doing so

                    MazeTraversal(maze, xPos + 1, yPos); // Attempt to move right
                    MazeTraversal(maze, xPos - 1, yPos); // Attempt to move left
                    MazeTraversal(maze, xPos, yPos + 1); // Attempt to move up
                    MazeTraversal(maze, xPos, yPos - 1); // Attempt to move down

                    if (!solved) // Check to make sure the maze hasn't been solved when backtracking and place down "O" when it does
                    {
                        maze[yPos, xPos] = 'O';
                        PrintMaze(maze);
                    }
                }
            }
        }

        // Prints maze to console
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
