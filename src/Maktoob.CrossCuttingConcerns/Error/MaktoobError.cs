
using Microsoft.AspNetCore.Identity;

namespace Maktoob.CrossCuttingConcerns.Error
{
    public static class IdentityErrorExtensions
    {
        public static MaktoobError ToMaktoobError(this IdentityError identityError)
        {
            var maktoobError = new MaktoobError { Code = identityError.Code, Description = identityError.Description };

            return maktoobError;
        }
    }
    /// <summary>
    /// Encapsulates an error from the Maktoob subsystem.
    /// </summary>
    public class MaktoobError
    {
        /// <summary>
        /// Gets or sets the code for this error.
        /// </summary>
        /// <value>
        /// The code for this error.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description for this error.
        /// </summary>
        /// <value>
        /// The description for this error.
        /// </value>
        public string Description { get; set; }
    }
}