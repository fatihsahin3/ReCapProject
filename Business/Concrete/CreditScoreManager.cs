using Business.Abstract;
using Business.Constraints;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditScoreManager : ICreditScoreService
    {
        ICreditScoreDal _creditScoreDal;

        public CreditScoreManager(ICreditScoreDal creditScoreDal)
        {
            _creditScoreDal = creditScoreDal;
        }

        public IDataResult<List<CreditScore>> GetAll()
        {
            return new SuccessDataResult<List<CreditScore>>(_creditScoreDal.GetAll());
        }

        public IDataResult<CreditScore> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CreditScore>(_creditScoreDal.Get(cs => cs.CustomerId == customerId));
        }

        public IResult Add(CreditScore creditScore)
        {
            _creditScoreDal.Add(creditScore);
            return new SuccessResult(Messages.CreditScoreAdded);
        }

        public IResult Delete(CreditScore creditScore)
        {
            _creditScoreDal.Delete(creditScore);
            return new SuccessResult(Messages.CreditScoreDeleted);
        }

        public IResult Update(CreditScore creditScore)
        {
            _creditScoreDal.Update(creditScore);
            return new SuccessResult(Messages.CreditScoreUpdated);
        }
    }
}
