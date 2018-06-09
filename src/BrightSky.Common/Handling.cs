using System;

namespace BrightSky.Common
{
    public static class Handling
    {
        public static TOutput TryCatch<TException, TOutput>(Func<TOutput> factory, Action<TException> catchAction) where TException : Exception
        {
            TOutput output = default(TOutput);

            try
            {
                output = factory();
            }
            catch (TException ex)
            {
                catchAction(ex);
            }

            return output;
        }

        public static void TryCatch<TException>(Action action, Action<TException> catchAction) where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException ex)
            {
                catchAction(ex);
            }
        }

    }
}