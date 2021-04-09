using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{//DoğrulamaKuralları
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //Kurallar buraya yazılır.
            RuleFor(p => p.ProductName).MinimumLength(2);//p otomatik üstte verdiğimiz değerden gelir yani Product.
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);//Koşul da sunabilliyoruz.
            //Ürünlerimin isimleri a ile başlamalı ya da bir regexe uymalı gibi bir kural koymak istiyorsak.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");//Kendi yazıcağımız metot.(RegEx yapabiliriz. bu metotta)
        }

        private bool StartWithA(string arg)//arg parametre
        {
            return arg.StartsWith("A");

        }
    }
}
