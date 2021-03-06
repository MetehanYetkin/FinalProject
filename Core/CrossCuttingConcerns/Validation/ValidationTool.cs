using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
  public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)//HERŞEYİ EKLEYEBİLRİİZ
        {
            var context = new ValidationContext<object>(entity);//Product için bir doğrulama yapacam.
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
