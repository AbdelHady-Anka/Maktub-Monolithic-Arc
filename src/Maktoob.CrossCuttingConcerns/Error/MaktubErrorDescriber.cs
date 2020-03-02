using maktoob.CrossCuttingConcerns.Properties;

namespace maktoob.CrossCuttingConcerns.Error
{
    /// <summary>
    /// Service to enable localization for application facing maktoob errors.
    /// </summary>
    /// <remarks>
    /// These errors are returned to controllers and are generally used as display messages to end users.
    /// </remarks>
    public class maktoobErrorDescriber
    {
        /// <summary>
        /// Returns the default <see cref="maktoobError"/>.
        /// </summary>
        /// <returns>the default <see cref="maktoobError"/>.</returns>
        public virtual maktoobError DefaultError()
        {
            return new maktoobError
            {
                Code = nameof(DefaultError),
                Description = Resources.DefaultError
            };
        }
        /// <summary>
        /// Returns an <see cref="maktoobError"/> indicating a concurrency failure.
        /// </summary>
        /// <returns>An <see cref="maktoobError"/> indicating a concurrency failure.</returns>
        public virtual maktoobError ConcurrencyFailure()
        {
            return new maktoobError
            {
                Code = nameof(ConcurrencyFailure),
                Description = Resources.ConcurrencyFailure
            };
        }
        public virtual maktoobError UserNotInGroup()
        {
            return new maktoobError
            {
                Code = nameof(UserNotInGroup),
                Description = Resources.UserNotInGroup
            };
        }
        public virtual maktoobError UserAlradyInGroup(){
            return new maktoobError 
            {
                Code = nameof(UserAlradyInGroup),
                Description = Resources.UserAlreadyInGroup
            };
        }
    }
}