using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project
{
    class Program
    {
        //Starting as of now, our first goal will be to make Life work and then we will separate
        //it into classes and such - Done!.
        /*Milestone 1: Make a function called randomState which will return a board with random
        *  dead or alive cells. Alive is represented by 1 and Dead is 0. ->Done!
        *  
        *Milestone 2: Create a Render function which will print the board nicely and replace the
        * 0's and 1's with an element. (Example: # ,$ ,%) ->Done!
        * 
        *Milestone 3: Calculate the next state of the board using Life's rules.
        * Rules:
        * 1. Any live cell with 0 or 1 live neighbors becomes dead, because of underpopulation.
        * 2. Any live cell with 2 or 3 live neighbors stays alive, because its neighborhood is just right.
        * 3. Any live cell with more than 3 live neighbors becomes dead, because of overpopulation.
        * 4. Any dead cell with exactly 3 live neighbors becomes alive, by reproduction.
        -> Done!
        *Milestone 4: Run Life forever. -> Done!
         */


        static void Main(string[] args)
        {
            GameOfLife game = new GameOfLife();
        }
        

    }
}
