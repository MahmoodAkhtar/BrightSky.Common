using System;

namespace BrightSky.Common
{
    public static class Handling
    {
        public static TResult TryCatch<TException, TResult>(Func<TResult> factory, Action<TException> catchAction) where TException : Exception
        {
            TResult result = default(TResult);

            try
            {
                result = factory();
            }
            catch (TException ex)
            {
                catchAction(ex);
            }

            return result;
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