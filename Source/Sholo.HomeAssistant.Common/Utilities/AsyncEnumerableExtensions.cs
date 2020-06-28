using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Utilities
{
    [PublicAPI]
    public static class AsyncEnumerableExtensions
    {
        public static async IAsyncEnumerable<T> WithEnforcedCancellation<T>(
            this IAsyncEnumerable<T> source,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            cancellationToken.ThrowIfCancellationRequested();

            await foreach (var item in source.WithCancellation(cancellationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return item;
            }
        }
    }
}
