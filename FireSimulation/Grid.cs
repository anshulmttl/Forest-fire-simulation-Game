using System;
using System.Collections.Generic;
using System.Text;

namespace FireSimulation
{
    class Grid
    {
        public Cell[,] forest = new Cell[21,21];

        public Grid()
        {

        }

        public void Initialise()
        {
            // Initialize the 2D array to beginning state Tree and empty space
            for(int i = 0; i < 21; ++i)
            {
                for(int j = 0; j < 21; ++j)
                {
                    Cell ce = new Cell();
                    if (i == 0 || i == 20 || j == 0 || j == 20)
                        ce.SetState(' '); //Empty border of 1 cell thickness
                    else
                        ce.SetState('&'); //Tree is not burning state initially

                    // Populate 2D array
                    forest[i, j] = ce;
                }
            }
        }

        public void ShowGrid()
        {
            Console.Clear();
            // Show grid on screen
            for(int i = 0; i < 21; ++i)
            {
                for(int j = 0; j < 21; ++j)
                {
                    Console.Write(forest[i,j].GetState());
                    Console.Write("   ");
                }
                Console.WriteLine();
            }
        }

        public void Start()
        {
            // Function to Start the fire at central cell
            // Set fire on center location cell
            forest[10, 10].SetState('X');
            ShowGrid();

            Console.WriteLine();
            Console.ReadKey();

            // Variable to check if fire is contained or burning. Execute loop based on this variable
            bool bFireRunning = true; 

            while(bFireRunning)
            {
                ApplySpread();
                ShowGrid();

                // Variable to exit loop if no tree is burning
                bool bNotBurning = true;
                for(int i = 0; i < 21; ++i)
                {
                    for(int j = 0; j < 21; ++j)
                    {
                        if(forest[i,j].GetState() == 'X')
                        {
                            // There is atleast 1 tree burning, we set bNotBurning = false;
                            bNotBurning = false;
                        }
                    }
                }

                if (bNotBurning)
                {
                    bFireRunning = false;
                    Console.WriteLine();
                    Console.WriteLine("Fire is contained. ");
                    Console.WriteLine("Press enter to exit the simulation ...");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.ReadKey();
                }
            }
        }

        public void ApplySpread()
        {
            // Temporary array to store previous state of forest
            Char[,] map = new Char[21,21];
            for(int i = 0; i < 21; ++i)
            {
                for(int j = 0; j < 21; ++j)
                {
                    map[i, j] = forest[i, j].GetState();
                }
            }


            // Apply the algorithm from assignment for setting fire on neighbouring trees
            for (int i = 0; i < 21; ++i)
            {
                for(int j = 0; j < 21; ++j)
                {
                    if(forest[i,j].GetState() == 'X')
                    {
                        forest[i, j].SetState(' ');
                    }
                    else if(forest[i, j].GetState() == '&')
                    {
                        // If neighbour is on fire create fire status for this variable
                        if((i - 1 > 0 && map[i-1,j] == 'X') 
                            || (i + 1 < 21 && map[i+1,j] == 'X') 
                            || (j - 1 > 0 && map[i,j-1] == 'X') 
                            || (j + 1 < 21 && map[i,j+1] == 'X'))
                        {
                            // If neighbour of a cell is burning get the burning state 
                            // of this cell using random generator
                            Random rnd = new Random();
                            int value = rnd.Next(2);
                            
                            forest[i, j].SetState(value == 0 ? '&' : 'X');
                        }
                    }
                }
            }
        }
    }
}
