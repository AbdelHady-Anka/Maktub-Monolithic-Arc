using Maktoob.CrossCuttingConcerns.Properties;

namespace Maktoob.CrossCuttingConcerns.Error
{
    /// <summary>
    /// Service to enable localization for application facing Maktoob errors.
    /// </summary>
    /// <remarks>
    /// These errors are returned to controllers and are generally used as display messages to end users.
    /// </remarks>
    public class GErrorDescriber
    {
        /// <summary>
        /// Returns an <see cref="GError"/> indicating an invalid token.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating an invalid token.</returns>
        public GError InvalidToken(string cause)
        {
            return new GError
            {
                Code = nameof(InvalidToken),
                Description = Errors.InvalidTokenFormat(cause)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating user sign out can not be completed.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating user sign out can not be completed.</returns>
        public GError SignOutFailed()
        {
            return new GError
            {
                Code = nameof(SignOutFailed),
                Description = Errors.SignOutFailed
            };
        }
        /// <summary>
        /// Returns an <see cref="GError"/> indicating an invalid credentials.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating an invalid credentials.</returns>
        public GError InvalidCredentials()
        {
            return new GError
            {
                Code = nameof(InvalidCredentials),
                Description = Errors.InvalidCredentials
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a resource not found.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating a resource not found.</returns>
        public GError NotFound()
        {
            return new GError
            {
                Code = nameof(NotFound),
                Description = Errors.NotFound
            };
        }
        /// <summary>
        /// Returns the default <see cref="GError"/>.
        /// </summary>
        /// <returns>The default <see cref="GError"/>.</returns>
        public GError DefaultError()
        {
            return new GError
            {
                Code = nameof(DefaultError),
                Description = Errors.DefaultError
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a concurrency failure.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating a concurrency failure.</returns>
        public GError ConcurrencyFailure()
        {
            return new GError
            {
                Code = nameof(ConcurrencyFailure),
                Description = Errors.ConcurrencyFailure
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a password mismatch.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating a password mismatch.</returns>
        public GError PasswordMismatch()
        {
            return new GError
            {
                Code = nameof(PasswordMismatch),
                Description = Errors.PasswordMismatch
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating an invalid token.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating an invalid token.</returns>
        public GError InvalidToken()
        {
            return new GError
            {
                Code = nameof(InvalidToken),
                Description = Errors.InvalidToken
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a recovery code was not redeemed.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating a recovery code was not redeemed.</returns>
        public GError RecoveryCodeRedemptionFailed()
        {
            return new GError
            {
                Code = nameof(RecoveryCodeRedemptionFailed),
                Description = Errors.RecoveryCodeRedemptionFailed
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating an external login is already associated with an account.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating an external login is already associated with an account.</returns>
        public GError LoginAlreadyAssociated()
        {
            return new GError
            {
                Code = nameof(LoginAlreadyAssociated),
                Description = Errors.LoginAlreadyAssociated
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating the specified user <paramref name="userName"/> is invalid.
        /// </summary>
        /// <param name="userName">The user name that is invalid.</param>
        /// <returns>An <see cref="GError"/> indicating the specified user <paramref name="userName"/> is invalid.</returns>
        public GError InvalidUserName(string userName)
        {
            return new GError
            {
                Code = nameof(InvalidUserName),
                Description = Errors.InvalidUserNameFormat(userName)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating the specified <paramref name="email"/> is invalid.
        /// </summary>
        /// <param name="email">The email that is invalid.</param>
        /// <returns>An <see cref="GError"/> indicating the specified <paramref name="email"/> is invalid.</returns>
        public GError InvalidEmail(string email)
        {
            return new GError
            {
                Code = nameof(InvalidEmail),
                Description = Errors.InvalidEmailFormat(email)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating the specified <paramref name="userName"/> already exists.
        /// </summary>
        /// <param name="userName">The user name that already exists.</param>
        /// <returns>An <see cref="GError"/> indicating the specified <paramref name="userName"/> already exists.</returns>
        public GError DuplicateUserName(string userName)
        {
            return new GError
            {
                Code = nameof(DuplicateUserName),
                Description = Errors.DuplicateUserNameFormat(userName)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating the specified <paramref name="email"/> is already associated with an account.
        /// </summary>
        /// <param name="email">The email that is already associated with an account.</param>
        /// <returns>An <see cref="GError"/> indicating the specified <paramref name="email"/> is already associated with an account.</returns>
        public GError DuplicateEmail(string email)
        {
            return new GError
            {
                Code = nameof(DuplicateEmail),
                Description = Errors.DuplicateEmailFormat(email)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating the specified <paramref name="role"/> name is invalid.
        /// </summary>
        /// <param name="role">The invalid role.</param>
        /// <returns>An <see cref="GError"/> indicating the specific role <paramref name="role"/> name is invalid.</returns>
        public GError InvalidRoleName(string role)
        {
            return new GError
            {
                Code = nameof(InvalidRoleName),
                Description = Errors.InvalidRoleNameFormat(role)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating the specified <paramref name="role"/> name already exists.
        /// </summary>
        /// <param name="role">The duplicate role.</param>
        /// <returns>An <see cref="GError"/> indicating the specific role <paramref name="role"/> name already exists.</returns>
        public GError DuplicateRoleName(string role)
        {
            return new GError
            {
                Code = nameof(DuplicateRoleName),
                Description = Errors.DuplicateRoleNameFormat(role)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a user already has a password.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating a user already has a password.</returns>
        public GError UserAlreadyHasPassword()
        {
            return new GError
            {
                Code = nameof(UserAlreadyHasPassword),
                Description = Errors.UserAlreadyHasPassword
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating user lockout is not enabled.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating user lockout is not enabled.</returns>
        public GError UserLockoutNotEnabled()
        {
            return new GError
            {
                Code = nameof(UserLockoutNotEnabled),
                Description = Errors.UserLockoutNotEnabled
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a user is already in the specified <paramref name="role"/>.
        /// </summary>
        /// <param name="role">The duplicate role.</param>
        /// <returns>An <see cref="GError"/> indicating a user is already in the specified <paramref name="role"/>.</returns>
        public GError UserAlreadyInRole(string role)
        {
            return new GError
            {
                Code = nameof(UserAlreadyInRole),
                Description = Errors.UserAlreadyInRoleFormat(role)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a user is not in the specified <paramref name="role"/>.
        /// </summary>
        /// <param name="role">The duplicate role.</param>
        /// <returns>An <see cref="GError"/> indicating a user is not in the specified <paramref name="role"/>.</returns>
        public GError UserNotInRole(string role)
        {
            return new GError
            {
                Code = nameof(UserNotInRole),
                Description = Errors.UserNotInRoleFormat(role)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a password of the specified <paramref name="length"/> does not meet the minimum length requirements.
        /// </summary>
        /// <param name="length">The length that is not long enough.</param>
        /// <returns>An <see cref="GError"/> indicating a password of the specified <paramref name="length"/> does not meet the minimum length requirements.</returns>
        public GError PasswordTooShort(int length)
        {
            return new GError
            {
                Code = nameof(PasswordTooShort),
                Description = Errors.PasswordTooShortFormat(length)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a password does not meet the minimum number <paramref name="uniqueChars"/> of unique chars.
        /// </summary>
        /// <param name="uniqueChars">The number of different chars that must be used.</param>
        /// <returns>An <see cref="GError"/> indicating a password does not meet the minimum number <paramref name="uniqueChars"/> of unique chars.</returns>
        public GError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new GError
            {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = Errors.PasswordRequiresUniqueCharsFormat(uniqueChars)
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a password entered does not contain a non-alphanumeric character, which is required by the password policy.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating a password entered does not contain a non-alphanumeric character.</returns>
        public GError PasswordRequiresNonAlphanumeric()
        {
            return new GError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = Errors.PasswordRequiresNonAlphanumeric
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a password entered does not contain a numeric character, which is required by the password policy.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating a password entered does not contain a numeric character.</returns>
        public GError PasswordRequiresDigit()
        {
            return new GError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = Errors.PasswordRequiresDigit
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a password entered does not contain a lower case letter, which is required by the password policy.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating a password entered does not contain a lower case letter.</returns>
        public GError PasswordRequiresLower()
        {
            return new GError
            {
                Code = nameof(PasswordRequiresLower),
                Description = Errors.PasswordRequiresLower
            };
        }

        /// <summary>
        /// Returns an <see cref="GError"/> indicating a password entered does not contain an upper case letter, which is required by the password policy.
        /// </summary>
        /// <returns>An <see cref="GError"/> indicating a password entered does not contain an upper case letter.</returns>
        public GError PasswordRequiresUpper()
        {
            return new GError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = Errors.PasswordRequiresUpper
            };
        }
    }
}