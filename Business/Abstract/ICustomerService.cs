using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByCustomerId(int customerId);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}