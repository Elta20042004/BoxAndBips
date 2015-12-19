namespace BoxAndBips
{
    public interface IValidator
    {
        bool Validate(IWorld world, int x, int y);
    }
}