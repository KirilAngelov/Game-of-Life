using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Project
{
    public class GameOfLife
    {
        
        public GameOfLife()
        {
            Display view = new Display();
            Console.CursorVisible = false;
            Load(view.Prop, view.Answer);
        }
        public static int[,] randomState(int width, int height)
        {
            int[,] test = new int[width, height];
            Random generator = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    test[i, j] = generator.Next(0, 2);
                }
            }

            return test;
        }
        public static void Render(int[,] board)
        {
            int rowLength = board.GetLength(0);
            int colLength = board.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                Console.Write('|');
                for (int j = 0; j < colLength; j++)
                {
                    if (board[i, j] == 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.Write('|');
                Console.WriteLine(" ");
                System.Threading.Thread.Sleep(5);
            }

        }
        public static void renderBinary(int[,] board)
        {
            int rowLength = board.GetLength(0);
            int colLength = board.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                Console.Write('|');
                for (int j = 0; j < colLength; j++)
                {


                    Console.Write(board[i, j]);

                }
                Console.Write('|');
                Console.WriteLine();
            }
        }
        public static int getLiveNeighbours(int[,] board, int x, int y)
        {
            int rowLength = board.GetLength(0);
            int colLength = board.GetLength(1);
            int[,] newBoard = new int[rowLength + 2, colLength + 2];
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    var newNum = board[i, j];
                    newBoard[i + 1, j + 1] = newNum;
                }
            }
            var list = new List<int>();
            list.Add(newBoard[x - 1 + 1, y - 1 + 1]);
            list.Add(newBoard[x - 1 + 1, y + 1]);
            list.Add(newBoard[x - 1 + 1, y + 1 + 1]);
            list.Add(newBoard[x + 1, y - 1 + 1]);
            list.Add(newBoard[x + 1, y + 1 + 1]);
            list.Add(newBoard[x + 1 + 1, y - 1 + 1]);
            list.Add(newBoard[x + 1 + 1, y + 1]);
            list.Add(newBoard[x + 1 + 1, y + 1 + 1]);
            return list.Where(z => z == 1).Count();
        }
        public static int[,] deadState(int width, int height)
        {

            int[,] test = new int[width, height];
            return test;

        }
        public static int[,] nextBoardState(int[,] state)
        {
            //Plan -> Iterate every cell of the state and use the GetLiveNeighbours function to 
            // calculate the number of live cells. Update in the DeadState board according the rules.
            int rowLength = state.GetLength(0);
            int colLength = state.GetLength(1);
            int result;
            int[,] newBoard = deadState(rowLength, colLength);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    result = getLiveNeighbours(state, i, j);
                    if ((result == 0 || result == 1) && state[i, j] == 1)
                    {
                        newBoard[i, j] = 0;
                    }
                    if ((result == 2 || result == 3) && state[i, j] == 1)
                    {
                        newBoard[i, j] = 1;
                    }
                    if (result > 3 && state[i, j] == 1)
                    {
                        newBoard[i, j] = 0;
                    }
                    if (result == 3 && state[i, j] == 0)
                    {
                        newBoard[i, j] = 1;
                    }
                }
            }
            return newBoard;
        }
        public static int[,] nextBoardStateZombies(int[,] state)
        {
            int rowLength = state.GetLength(0);
            int colLength = state.GetLength(1);
            int result;
            Random generator = new Random();
            int[,] newBoard = deadState(rowLength, colLength);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    int chance = generator.Next(1,10);
                    if (state[i,j]==0 && chance==1)
                    {
                        state[i, j] = 1;
                    }
                    result = getLiveNeighbours(state, i, j);
                    if ((result == 0 || result == 1) && state[i, j] == 1)
                    {
                        newBoard[i, j] = 0;
                    }
                    if ((result == 2 || result == 3) && state[i, j] == 1)
                    {
                        newBoard[i, j] = 1;
                    }
                    if (result > 3 && state[i, j] == 1)
                    {
                        newBoard[i, j] = 0;
                    }
                    if (result == 3 && state[i, j] == 0)
                    {
                        newBoard[i, j] = 1;
                    }
                }
            }
            return newBoard;
        }
        public static void eternalLife(int[,] initial, string spawnFlag)
        {
            var nextState = initial;
            int gen = 0;
            while (true)
            {

                Console.Title = "Generation: " + gen;
                Console.Clear();
                Render(nextState);
                if (spawnFlag=="Yes" )
                {
                    nextState = nextBoardStateZombies(nextState);
                }
                if (spawnFlag=="No")
                {
                    nextState = nextBoardState(nextState);
                }
               
                gen++;
            }
        }
        public static int[] getArray(string path)
        {
            var list = new List<int>();
            string[] lines = File.ReadLines(path).ToArray();
            foreach (var item in lines)
            {
                list.Add(Int32.Parse(item));

            }
            return list.ToArray();
        }
        public static int[,] convertMatrix(int[] flat, int m, int n)
        {
            int[,] ret = new int[m, n];
            // BlockCopy uses byte lengths: a double is 8 bytes
            Buffer.BlockCopy(flat, 0, ret, 0, flat.Length * sizeof(int));
            return ret;
        }
        public static void Load(string thing,string spawnFlag)
        {
            int a = 0, b = 0;
            if (thing == "Random")
            {
                Random rnd = new Random();
                a = rnd.Next(5, 25);
                b = rnd.Next(5, 50);
                int[,] state = randomState(a, b);
                eternalLife(state,spawnFlag);
            }
            if (thing == "Blinker")
            {
                a = 5;
                b = 5;
            }
            if (thing == "Glasses")
            {
                a = 10;
                b = 20;
            }
            if (thing == "Glider")
            {
                a = 15;
                b = 10;

            }
            if (thing == "Toad" || thing == "Beacon")
            {
                a = 6;
                b = 6;
            }
            if (thing == "Gun")
            {
                a = 15;
                b = 38;
            }
            var documents = System.IO.Directory.GetFiles("../../../../../../Game-of-Life/Starters");
            /*var list = new List<string>();
            var ext = new char[]{ 't', 'x' };
            for (int i = 0; i < documents.Length; i++)
            {
                string a = Regex.Replace(documents[i], "[@,\\.//\";'\\\\]", string.Empty);
                a = a.Remove(0, 12);
                a = a.TrimEnd(ext);
                documents[i] = a;
            }*/

            string load = documents.Where(x => x.Contains(thing)).First();
            var arr = getArray(load);
            var Matrix = convertMatrix(arr, a, b);
            eternalLife(Matrix,spawnFlag);
        }
    }
}
