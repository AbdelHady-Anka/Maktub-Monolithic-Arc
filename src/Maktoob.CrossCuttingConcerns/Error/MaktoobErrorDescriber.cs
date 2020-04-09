using Maktoob.CrossCuttingConcerns.Properties;

namespace Maktoob.CrossCuttingConcerns.Error
{
    /// <summary>
    /// Service to enable localization for application facing Maktoob errors.
    /// </summary>
    /// <remarks>
    /// These errors are returned to controllers and are generally used as display messages to end users.
    /// </remarks>
    public class maktoobErrorDescriber
    {
        /// <summary>
        /// Returns the default <see cref="MaktoobError"/>.
        /// </summary>
        /// <returns>the default <see cref="MaktoobError"/>.</returns>
        public virtual MaktoobError DefaultError()
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
        public virtual MaktoobError ConcurrencyFailure()
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
        public virtual MaktoobError UserNotInGroup(string group)
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

        public virtual MaktoobError UserAlradyInGroup(string group){
            return new MaktoobError
            {
                Code = nameof(UserAlradyInGroup),
                Description = Errors.UserNotInGroupFormat(group)
            };
        }
    }
}