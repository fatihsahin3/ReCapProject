using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}