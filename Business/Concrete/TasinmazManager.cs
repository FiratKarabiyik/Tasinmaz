using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;

using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class TasinmazManager : ITasinmazService
    {
        ITasinmazDal _tasinmazDal;
        ILogDal _logDal;
        public TasinmazManager(ITasinmazDal tasinmazDal , ILogDal logDal)
        {
            _tasinmazDal = tasinmazDal;
            _logDal = logDal;
        }

        //[SecuredOperation("tasinmaz.add,admin")]
        [ValidationAspect(typeof(TasinmazValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Tasinmaz tasinmaz)
        {
            //iş kodları
            IResult result = BusinessRules.Run(CheckIfTasinmazCountOfCategoryCorrect(tasinmaz.TasinmazId));

            if (result != null)
            {
                return result;
            }

            _tasinmazDal.Add(tasinmaz);
            return new SuccessResult("Eklendi");

        }
        public IResult AddLog(Log log)
        {
            _logDal.Add(log);
            return new SuccessResult("Eklendi");
        }


        public IDataResult<List<Tasinmaz>> GetAll()
        {
            return new SuccessDataResult<List<Tasinmaz>>(_tasinmazDal.GetAll(), "Listelendi");
        }

        public IDataResult<List<Log>> GetAllLog()
        {
            return new SuccessDataResult<List<Log>>(_logDal.GetAll(), "Listelendi");
        }

        public IDataResult<List<Tasinmaz>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Tasinmaz>>(_tasinmazDal.GetList(p => p.UserId == userId).ToList());
        }

        public IDataResult<List<Tasinmaz>> GetAllByCategoryId(int userId)
        {
            return new SuccessDataResult<List<Tasinmaz>>(_tasinmazDal.GetList(p => p.UserId == userId).ToList());
        }

        

        public IDataResult<Tasinmaz> GetById(int tasinmazId)
        {
            return new SuccessDataResult<Tasinmaz>(_tasinmazDal.Get(p => p.TasinmazId == tasinmazId));
        }

       

        public IDataResult<List<Tasinmaz>> GetByUserId()
        {
            return new SuccessDataResult<List<Tasinmaz>>(_tasinmazDal.GetAll(), "Listelendi");
        }



        public IDataResult<List<TasinmazDetailDto>> GetTasinmazDetails()
        {
            return new SuccessDataResult<List<TasinmazDetailDto>>(_tasinmazDal.GetTasinmazDetails());
        }

        public IResult Update(Tasinmaz tasinmaz)
        {

            _tasinmazDal.Update(tasinmaz);
            return new SuccessResult("Güncellendi");
        }



        private IResult CheckIfTasinmazCountOfCategoryCorrect(int tasinmazId)
        {
            var result = _tasinmazDal.GetAll(p => p.TasinmazId == tasinmazId).Count;
            if (result >= 15)
            {
                return new ErrorResult("hata");

            }
            return new SuccessResult();
        }




        public IResult Delete(Tasinmaz tasinmaz)
        {
            _tasinmazDal.Delete(tasinmaz);
            return new SuccessResult("silindi");
        }

        public IDataResult<List<Tasinmaz>> GetListBySehir(int Sid)
        {
            throw new NotImplementedException();
        }

      
    }
}
