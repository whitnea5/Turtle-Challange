namespace TurtleChallenge.Models
{
    class Moves
    {
        public string[][] Sequences { get; set; }

        public Moves(int size)
        {
            Sequences = new string[size][];
        }
    }
}
