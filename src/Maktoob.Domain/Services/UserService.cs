using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Maktoob.CrossCuttingConcerns.Error;
using Maktoob.CrossCuttingConcerns.Exceptions;
using Maktoob.CrossCuttingConcerns.Normalizers;
using Maktoob.CrossCuttingConcerns.Result;
using Maktoob.CrossCuttingConcerns.Security;
using Maktoob.Domain.Entities;
using Maktoob.Domain.Events;
using Maktoob.Domain.Repositories;
using Maktoob.Domain.Specifications;
using Maktoob.Domain.Validators;

namespace Maktoob.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKeyNormalizer _keyNormalizer;
        private readonly IValidator<User> _validator;
        private readonly MaktoobErrorDescriber _errorDescriber;

        public UserService(IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        MaktoobErrorDescriber errorDescriber,
        IKeyNormalizer keyNormalizer,
        IPasswordHasher passwordHasher,
        IValidator<User> validator)
        {
            _errorDescriber = errorDescriber;
            _keyNormalizer = keyNormalizer;
            PasswordHasher = passwordHasher;
            this._validator = validator;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public IPasswordHasher PasswordHasher { get; }

        public async Task<MaktoobResult> CreateAsync(User user)
        {
            var result = await _validator.ValidateAsync(user);
            if (!result.Succeeded)
            {
                return result;
            }
            if (string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                throw new InvalidPasswordHashException($"password hash of {typeof(User)} null or empty");
            }
            user.NormalizedName = _keyNormalizer.Normalize(user.Name);
            user.NormalizedEmail = _keyNormalizer.Normalize(user.Email);
            await _userRepository.AddAsync(user);
            try
            {
                await _unitOfWork.SaveChangesAsync();
                DomainEvents.Dispatch(new UserCreatedEvent(user));
                return result;
            }
            catch (Exception)
            {
                return MaktoobResult.Failed(_errorDescriber.DefaultError());
            }
        }

        public Task<MaktoobResult> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<MaktoobResult> ReadAsync(Specification<User> spec)
        {
            if (spec is SingleResultSpec<User>)
            {
                var result = await _userRepository.GetAsync((SingleResultSpec<User>)spec);
                if(result != null)
                {
                    return MaktoobResult<User>.Success(result);
                }
                else
                {
                    return MaktoobResult.Failed(_errorDescriber.NotFound());
                }
            }
            if(spec is MultiResultSpec<User>)
            {
                var result = await _userRepository.GetAsync((MultiResultSpec<User>)spec);
                if(result != null)
                {
                    return MaktoobResult<IEnumerable<User>>.Success(result);
                }
                else
                {
                    return MaktoobResult.Failed(_errorDescriber.NotFound());
                }
            }
            throw new InvalidSpecificationException($"spec paramater must be derived from {typeof(SingleResultSpec<User>)} or {typeof(MultiResultSpec<User>)}");
        }

        public Task<MaktoobResult> SignInAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<MaktoobResult> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
