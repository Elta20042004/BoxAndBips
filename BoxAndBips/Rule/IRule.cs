namespace BoxAndBips.Rule
{
    public interface IRule
    {
        void Apply(Box box, IWorld w);

    }
}