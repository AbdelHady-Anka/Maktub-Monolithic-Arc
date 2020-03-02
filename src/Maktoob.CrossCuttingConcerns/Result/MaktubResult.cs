using System.Collections.Generic;
using System.Linq;
using maktoob.CrossCuttingConcerns.Error;

namespace maktoob.CrossCuttingConcerns.Result
{
    /// <summary>
    /// Represents the result of an maktoob operation.
    /// </summary>
    public class maktoobResult
    {
        private static readonly maktoobResult _success = new maktoobResult { Succeeded = true };
        private List<maktoobError> _errors = new List<maktoobError>();
        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; protected set; }
        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of <see cref="maktoobError"/>s containing errors
        /// that occured during the maktoob operation.
        /// </summary>
        /// <value>An <see cref="IEnumerable{T}"/> of <see cref="maktoobError"/>s.</value>
        public IEnumerable<maktoobError> Errors => _errors;
        /// <summary>
        /// Returns an <see cref="maktoobResult"/> indicating a successful maktoob operation.
        /// </summary>
        /// <returns>An <see cref="maktoobResult"/> indicating a successful operation.</returns>
        public static maktoobResult Success => _success;
        /// <summary>
        /// Creates an <see cref="maktoobResult"/> indicating a failed maktoob operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="maktoobError"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="maktoobResult"/> indicating a failed maktoob operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static maktoobResult Failed(params maktoobError[] errors)
        {
            var result = new maktoobResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }
        public override string ToString()
        {
            return Succeeded ?
                    "Succeeded" :
                    string.Format("{0} : {1}", "Failed", string.Join(",", Errors.Select(x => x.Code).ToList()));
        }
    }
}