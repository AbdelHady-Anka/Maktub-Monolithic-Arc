
using Microsoft.AspNetCore.Identity;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Maktoob.CrossCuttingConcerns.Error
{
    public static class IdentityErrorEthistensions
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
    public class MaktoobError : IEquatable<MaktoobError>
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

        public bool Equals([AllowNull] MaktoobError other)
        {
            if (ReferenceEquals(this, null) && ReferenceEquals(other, null))
            {
                return true;
            }

            if (ReferenceEquals(this, null) || ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.Code == other.Code)
            {
                return true;
            }
            return false;
        }
    }
}