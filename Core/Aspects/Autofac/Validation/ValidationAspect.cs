using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) // If the validatorType is not an IValidator.
            {
                throw new System.Exception("This is not a valdidation class!"); 
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Create an instance of given Validator type.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Get the generic parameters of the base type of the given Validator type. 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //Find the parameters of the invocation (method) which are same as the generic parameters in base class.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //Validate all the found parameters of method by using given validator and type of parameters.
            }
        }
    }
}
