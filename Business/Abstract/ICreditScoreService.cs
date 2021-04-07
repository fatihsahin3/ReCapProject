using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditScoreService
    {
        IDataResult<List<CreditScore>> GetAll();
        IDataResult<CreditScore> GetByCustomerId(int customerId);
        IResult Add(CreditScore creditScore);
        IResult Update(CreditScore creditScore);
        IResult Delete(CreditScore creditScore);
    }
}
