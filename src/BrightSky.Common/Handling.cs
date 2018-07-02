using System;

namespace BrightSky.Common
{
    public static class Handling
    {
        public static TOutput TryCatch<TException, TOutput>(Func<TOutput> factory, Func<TException, TOutput> catchFunc) where TException : Exception
        {
            try
            {
                return factory();
            }
            catch (TException ex)
            {
                return catchFunc(ex);
            }
        }

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

        public static bool TryCatch<TException>(Action action, Func<TException, bool> catchAction) where TException : Exception
        {
            try
            {
                action();
                return true;
            }
            catch (TException ex)
            {
                return catchAction(ex);
            }
        }
    }
}