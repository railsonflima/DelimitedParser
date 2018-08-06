using System;

namespace GenericParser.Utils.Extensions
{
    public static class FuncExtension
    {
        public static TOut ContinueWith<TIn, TOut>(this TIn param, Func<TIn, TOut> continueWith)
        {
            return continueWith(param);
        }
    }
}
