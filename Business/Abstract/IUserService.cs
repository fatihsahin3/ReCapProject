using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Core.Entities.Concrete;
using Entities.DTO;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}