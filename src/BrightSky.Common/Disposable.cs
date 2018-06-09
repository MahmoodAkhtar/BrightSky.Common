using System;

namespace BrightSky.Common
{
    public static class Disposable
    {
        public static TOutput Using<TInput, TOutput>(Func<TInput> factory, Func<TInput, TOutput> function) where TInput : IDisposable
        {
            using (var disposable = factory())
            {
                return function(disposable);
            }
        }
    }
}