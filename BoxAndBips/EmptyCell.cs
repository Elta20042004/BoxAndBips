namespace BoxAndBips
{
    class EmptyCell : ICell //pustaya kletka
    {
        public int X { get; }
        public int Y { get; }

        public override string ToString()
        {
            return ".";
        }
    }
}