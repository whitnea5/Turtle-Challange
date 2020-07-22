namespace TurtleChallenge.Models
{
    class Grid
    {
        public int [][] grid;
        public int Width;
        public int Height;

        public Grid(int x, int y)
        {
            Width = y;
            Height = x;

            //initialise grid
            grid = new int [Height][];
            for(int i = 0; i <= Width; i++)
            {
                grid[i] = new int[Width];
            }
        }
    }
}
