﻿namespace BoxAndBips
{
    public class BoundValidator : IValidator
    {
        public bool Validate(IWorld world, int x, int y)
        {
            if ((x >= 0 && x < world.M) && (y >= 0 && y < world.N))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}