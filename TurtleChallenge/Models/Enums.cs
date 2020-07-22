namespace TurtleChallenge.Models
{
    public enum Components
    {
        Turtle,
        Exit,
        Mine
    }

    public enum Directions
    {
        North,
        South,
        East,
        West
    }

    public enum GameState
    {
        Mine,
        Exit,
        Normal,
        OutOfBounds
    }
}
