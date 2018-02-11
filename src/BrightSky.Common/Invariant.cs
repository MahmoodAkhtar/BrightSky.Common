using System;

namespace BrightSky.Common
{
    public static class Invariant
    {
        public static void SatisfiedBy(Func<bool> predicate, string message)
        {
            if (!predicate())
                throw new InvalidOperationException(message);
        }
    }
}