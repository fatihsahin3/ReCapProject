using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetByRentalId(int rentalId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}