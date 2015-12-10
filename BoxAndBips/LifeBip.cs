namespace Game
{
    public class LifeBip : Bip
    {
        public int Life { get; private set; }

        public LifeBip(int life)
        {
           Life = life;
        }

        public override string ToString()
        {
            return "$";
        }
    }
}