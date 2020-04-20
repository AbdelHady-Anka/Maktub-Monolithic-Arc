using Maktoob.CrossCuttingConcerns.Properties;

namespace Maktoob.CrossCuttingConcerns.Error
{
    /// <summary>
    /// Service to enable localization for application facing Maktoob errors.
    /// </summary>
    /// <remarks>
    /// These errors are returned to controllers and are generally used as display messages to end users.
    /// </remarks>
    public class MaktoobErrorDescriber
    {

        public MaktoobError NotFound()
        {
            return new MaktoobError
            {
                Code = nameof(NotFound),
                Description = Errors.NotFound
            };
        }
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
        /// Returns an <see cref="MaktoobError"/> indicating a password mismatch.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating a password mismatch.</returns>
        public MaktoobError PasswordMismatch()
        {
            return new MaktoobError
            {
                Code = nameof(PasswordMismatch),
                Description = Errors.PasswordMismatch
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating an invalid token.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating an invalid token.</returns>
        public MaktoobError InvalidToken()
        {
            return new MaktoobError
            {
                Code = nameof(InvalidToken),
                Description = Errors.InvalidToken
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a recovery code was not redeemed.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating a recovery code was not redeemed.</returns>
        public MaktoobError RecoveryCodeRedemptionFailed()
        {
            return new MaktoobError
            {
                Code = nameof(RecoveryCodeRedemptionFailed),
                Description = Errors.RecoveryCodeRedemptionFailed
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating an external login is already associated with an account.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating an external login is already associated with an account.</returns>
        public MaktoobError LoginAlreadyAssociated()
        {
            return new MaktoobError
            {
                Code = nameof(LoginAlreadyAssociated),
                Description = Errors.LoginAlreadyAssociated
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating the specified user <paramref name="userName"/> is invalid.
        /// </summary>
        /// <param name="userName">The user name that is invalid.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating the specified user <paramref name="userName"/> is invalid.</returns>
        public MaktoobError InvalidUserName(string userName)
        {
            return new MaktoobError
            {
                Code = nameof(InvalidUserName),
                Description = Errors.InvalidUserNameFormat(userName)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating the specified <paramref name="email"/> is invalid.
        /// </summary>
        /// <param name="email">The email that is invalid.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating the specified <paramref name="email"/> is invalid.</returns>
        public MaktoobError InvalidEmail(string email)
        {
            return new MaktoobError
            {
                Code = nameof(InvalidEmail),
                Description = Errors.InvalidEmailFormat(email)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating the specified <paramref name="userName"/> already exists.
        /// </summary>
        /// <param name="userName">The user name that already exists.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating the specified <paramref name="userName"/> already exists.</returns>
        public MaktoobError DuplicateUserName(string userName)
        {
            return new MaktoobError
            {
                Code = nameof(DuplicateUserName),
                Description = Errors.DuplicateUserNameFormat(userName)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating the specified <paramref name="email"/> is already associated with an account.
        /// </summary>
        /// <param name="email">The email that is already associated with an account.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating the specified <paramref name="email"/> is already associated with an account.</returns>
        public MaktoobError DuplicateEmail(string email)
        {
            return new MaktoobError
            {
                Code = nameof(DuplicateEmail),
                Description = Errors.DuplicateEmailFormat(email)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating the specified <paramref name="role"/> name is invalid.
        /// </summary>
        /// <param name="role">The invalid role.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating the specific role <paramref name="role"/> name is invalid.</returns>
        public MaktoobError InvalidRoleName(string role)
        {
            return new MaktoobError
            {
                Code = nameof(InvalidRoleName),
                Description = Errors.InvalidRoleNameFormat(role)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating the specified <paramref name="role"/> name already exists.
        /// </summary>
        /// <param name="role">The duplicate role.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating the specific role <paramref name="role"/> name already exists.</returns>
        public MaktoobError DuplicateRoleName(string role)
        {
            return new MaktoobError
            {
                Code = nameof(DuplicateRoleName),
                Description = Errors.DuplicateRoleNameFormat(role)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a user already has a password.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating a user already has a password.</returns>
        public MaktoobError UserAlreadyHasPassword()
        {
            return new MaktoobError
            {
                Code = nameof(UserAlreadyHasPassword),
                Description = Errors.UserAlreadyHasPassword
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating user lockout is not enabled.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating user lockout is not enabled.</returns>
        public MaktoobError UserLockoutNotEnabled()
        {
            return new MaktoobError
            {
                Code = nameof(UserLockoutNotEnabled),
                Description = Errors.UserLockoutNotEnabled
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a user is already in the specified <paramref name="role"/>.
        /// </summary>
        /// <param name="role">The duplicate role.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating a user is already in the specified <paramref name="role"/>.</returns>
        public MaktoobError UserAlreadyInRole(string role)
        {
            return new MaktoobError
            {
                Code = nameof(UserAlreadyInRole),
                Description = Errors.UserAlreadyInRoleFormat(role)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a user is not in the specified <paramref name="role"/>.
        /// </summary>
        /// <param name="role">The duplicate role.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating a user is not in the specified <paramref name="role"/>.</returns>
        public MaktoobError UserNotInRole(string role)
        {
            return new MaktoobError
            {
                Code = nameof(UserNotInRole),
                Description = Errors.UserNotInRoleFormat(role)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a password of the specified <paramref name="length"/> does not meet the minimum length requirements.
        /// </summary>
        /// <param name="length">The length that is not long enough.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating a password of the specified <paramref name="length"/> does not meet the minimum length requirements.</returns>
        public MaktoobError PasswordTooShort(int length)
        {
            return new MaktoobError
            {
                Code = nameof(PasswordTooShort),
                Description = Errors.PasswordTooShortFormat(length)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a password does not meet the minimum number <paramref name="uniqueChars"/> of unique chars.
        /// </summary>
        /// <param name="uniqueChars">The number of different chars that must be used.</param>
        /// <returns>An <see cref="MaktoobError"/> indicating a password does not meet the minimum number <paramref name="uniqueChars"/> of unique chars.</returns>
        public MaktoobError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new MaktoobError
            {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = Errors.PasswordRequiresUniqueCharsFormat(uniqueChars)
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a password entered does not contain a non-alphanumeric character, which is required by the password policy.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating a password entered does not contain a non-alphanumeric character.</returns>
        public MaktoobError PasswordRequiresNonAlphanumeric()
        {
            return new MaktoobError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = Errors.PasswordRequiresNonAlphanumeric
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a password entered does not contain a numeric character, which is required by the password policy.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating a password entered does not contain a numeric character.</returns>
        public MaktoobError PasswordRequiresDigit()
        {
            return new MaktoobError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = Errors.PasswordRequiresDigit
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a password entered does not contain a lower case letter, which is required by the password policy.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating a password entered does not contain a lower case letter.</returns>
        public MaktoobError PasswordRequiresLower()
        {
            return new MaktoobError
            {
                Code = nameof(PasswordRequiresLower),
                Description = Errors.PasswordRequiresLower
            };
        }

        /// <summary>
        /// Returns an <see cref="MaktoobError"/> indicating a password entered does not contain an upper case letter, which is required by the password policy.
        /// </summary>
        /// <returns>An <see cref="MaktoobError"/> indicating a password entered does not contain an upper case letter.</returns>
        public MaktoobError PasswordRequiresUpper()
        {
            return new MaktoobError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = Errors.PasswordRequiresUpper
            };
        }
    }
}