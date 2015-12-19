namespace BoxAndBips
{
    public class BoxAssaultValidator : IValidator
    {
        public bool Validate(IWorld world, int x, int y)
        {
            return !(world.GetCell(x, y) is Box);
        }
    }
}