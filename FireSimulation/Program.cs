using System;

namespace FireSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid();

            // Initialize the 2D grid to starting state
            grid.Initialise();

            // Show initial forest grid on screen
            grid.ShowGrid();

            // Start fire
            grid.Start();
        }
    }
}
