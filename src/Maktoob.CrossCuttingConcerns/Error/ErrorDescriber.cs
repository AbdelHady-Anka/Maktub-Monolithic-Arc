using Maktoob.CrossCuttingConcerns.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maktoob.CrossCuttingConcerns.Error
{
    public class ErrorDescriber
    {
        /// <summary>
        /// Returns the default <see cref="MaktoobError"/>.
        /// </summary>
        /// <returns>The default <see cref="MaktoobError"/>.</returns>
        public MaktoobError DefaultError()
        {
            return new MaktoobError
            {
                Code = nameof(DefaultError),
                Description = Errors.DefaultError
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a concurrency failure.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating a concurrency failure.</returns>
        public MaktoobError ConcurrencyFailure()
        {
            return new MaktoobError
            {
                Code = nameof(ConcurrencyFailure),
                Description = Errors.ConcurrencyFailure
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a user is not in the specified <paramref name="group"/>.
        /// </summary>
        /// <param name="group">The chat group name.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating a user is not in the specified <paramref name="group"/>.</returns>
        public MaktoobError UserNotInGroup(string group)
        {
            return new MaktoobError
            {
                Code = nameof(UserNotInGroup),
                Description = Errors.UserNotInGroupFormat(group)
            };
        }
        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a user is already in the specified <paramref name="group"/>.
        /// </summary>
        /// <param name="group">The chat group name.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating a user is already in the specified <paramref name="group"/>.</returns>

        public MaktoobError UserAlradyInGroup(string group)
        {
            return new MaktoobError
            {
                Code = nameof(UserAlradyInGroup),
                Description = Errors.UserNotInGroupFormat(group)
            };
        }

    }
}
