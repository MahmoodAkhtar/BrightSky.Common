using System;

namespace BrightSky.Common
{
    public static class Disposable
    {
        public static TResult Using<TDisposable, TResult>(Func<TDisposable> factory, Func<TDisposable, TResult> function) where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                return function(disposable);
            }
        }
    }
}