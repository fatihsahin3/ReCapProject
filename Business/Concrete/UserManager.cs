using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Entities.Concrete;
using Entities.DTO;
using Core.Utilities.Security.Hashing;
using Business.Constraints;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        ICustomerDal _customerDal;

        public UserManager(IUserDal userDal, ICustomerDal customerDal)
        {
            _userDal = userDal;
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
        {
            var user = GetByUserId(userDetailForUpdate.Id).Data;

            if (!HashingHelper.VerifyPasswordHash(userDetailForUpdate.CurrentPassword, user.PasswordHash,
                user.PasswordSalt)) return new ErrorResult(Messages.PasswordError);

            user.FirstName = userDetailForUpdate.FirstName;
            user.LastName = userDetailForUpdate.LastName;
            user.Email = userDetailForUpdate.Email;
            if (!string.IsNullOrEmpty(userDetailForUpdate.NewPassword))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userDetailForUpdate.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _userDal.Update(user);

            var customer = _customerDal.Get(c => c.Id == userDetailForUpdate.CustomerId);
            customer.CompanyName = userDetailForUpdate.CompanyName;
            _customerDal.Update(customer);

            return new SuccessResult(Messages.UserDetailsUpdated);
        }

            public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(b => b.Id == id));
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}