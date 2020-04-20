using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Maktoob.CrossCuttingConcerns.Error;
using Microsoft.AspNetCore.Identity;

namespace Maktoob.CrossCuttingConcerns.Result
{
    public static class IdentityResultEthistensions
    {
        public static MaktoobResult ToMaktoobResult(this IdentityResult identityResult)
        {
            if (identityResult.Succeeded)
            {
                return MaktoobResult.Success;
            }
            else
            {
                var errors = identityResult.Errors.Select(ie => ie.ToMaktoobError()).ToArray();
                return MaktoobResult.Failed(errors);
            }
        }
    }
    /// <summary>
    /// Represents the result of an Maktoob operation that can have an outcome.
    /// </summary>
    /// <typeparam name="TOutcome">The type of outcome object.</typeparam>
    
    public class MaktoobResult<TOutcome> : MaktoobResult where TOutcome : class
    {
        /// <summary>
        /// containing an outcome that produced during the Maktoob operation.
        /// </summary>
        public TOutcome Outcome { get; protected set; }
        /// <summary>
        /// Returns an <see cref="MaktoobResult"/> indicating a successful Maktoob operation.
        /// </summary>
        /// <returns>An <see cref="MaktoobResult"/> indicating a successful operation.</returns>
        public new static MaktoobResult<TOutcome> Success(TOutcome result)
        {
            return new MaktoobResult<TOutcome> { Succeeded = true, Outcome = result };
        }
    }
    /// <summary>
    /// Represents the result of an Maktoob operation.
    /// </summary>
    public class MaktoobResult : IEquatable<MaktoobResult>
    {
        private List<MaktoobError> _errors = new List<MaktoobError>();

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of <see cref="MaktoobError"/>s containing an errors
        /// that occurred during the Maktoob operation.
        /// </summary>
        /// <value>An <see cref="IEnumerable{T}"/> of <see cref="MaktoobError"/>s.</value>
        public IEnumerable<MaktoobError> Errors => _errors;

        /// <summary>
        /// Returns an <see cref="MaktoobResult"/> indicating a successful Maktoob operation.
        /// </summary>
        /// <returns>An <see cref="MaktoobResult"/> indicating a successful operation.</returns>
        public static MaktoobResult Success { get; } = new MaktoobResult { Succeeded = true };

        /// <summary>
        /// Creates an <see cref="MaktoobResult"/> indicating a failed Maktoob operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="MaktoobError"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="MaktoobResult"/> indicating a failed Maktoob operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static MaktoobResult Failed(params MaktoobError[] errors)
        {
            var result = new MaktoobResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }

        /// <summary>
        /// Converts the value of the current <see cref="MaktoobResult"/> object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the current <see cref="MaktoobResult"/> object.</returns>
        /// <remarks>
        /// If the operation was successful the ToString() will return "Succeeded" otherwise it returned 
        /// "Failed : " followed by a comma delimited list of error codes from its <see cref="Errors"/> collection, if any.
        /// </remarks>
        public override string ToString()
        {
            return Succeeded ?
                   "Succeeded" :
                   string.Format("{0} : {1}", "Failed", string.Join(",", Errors.Select(x => x.Code).ToList()));
        }

        public bool Equals([AllowNull] MaktoobResult other)
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

            if (this.Succeeded && other.Succeeded)
            {
                return true;
            }

            if (this.Errors.SequenceEqual(other.Errors))
            {
                return true;
            }
            return false;
        }
    }
}