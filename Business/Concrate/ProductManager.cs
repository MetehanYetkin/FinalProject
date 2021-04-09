using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.CCS;
using Business.Concrate;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrate.InMemory;
using Entities.Concrate;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrate
{//Bir managerin içinde başka bir dal injection edilemez. ama servis olur.
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;


        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _productDal = productDal;
            
        }
        [CacheAspect]//Key,value
        [SecuredOperation("productadd,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductServiceGet")]//Yeni ürün eklediğimizde cache silinir tekrar eklenir .
        public IResult Add(Product product)
        {

            //Bussines codes(İş Kodu)//İş ihtiyaçlarımıza Uygunluktur.(Ehliyet alıcaksın Ehliyet verip vermeme gibi iş kuralları burada olur.)
            //Validation(Doğrulama Kodu)//Yapısal uyum ile olan her şeye denir.(Max Karakter sayısı vs.)

            IResult result = BusinessRules.Run(ChechIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfProductNameExist(product.ProductName),CheckIfCategoryLimitExceded());
            if (result != null)//kurala uymayan bir durum ise
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            //return new Result(true,"Başarıyla Eklendi");

        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //İş Kodları
            //Yetkisi varmı ?
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);// Bunu yapabilmemiz için IEntitiyRepositoy classında ekleme yaptık expression

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));//Benim gönderdiğim CategoryId si oradaki categoryid sine eşit ise onları filtrele.

        }

        [CacheAspect]
        [PerformanceAspect(5)]//sistemin çalışması 5sn geçerse beni uyar demek.
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));//2 fiyat aralığında olan datayı getirecektir.

        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductServiceGet")]//IProductService İçindeki get olan her şeyi siler.
        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new SuccessResult();
        }
        private IResult ChechIfProductCountOfCategoryCorrect(int categoryId)
        {
            var results = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (results >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();//any varmı?
            if (result == true)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();

        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);

            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product); 
            if (product.UnitPrice<10)
            {
                throw new Exception("");
            }
            Add(product);
            return null;
        }
    }

}
