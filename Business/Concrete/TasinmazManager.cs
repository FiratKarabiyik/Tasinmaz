using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TasinmazManager : ITasinmazService
    {
        ITasinmazDal _tasinmazDal;
        public TasinmazManager(ITasinmazDal tasinmazDal)
        {
            _tasinmazDal = tasinmazDal;
        }


        [ValidationAspect(typeof(TasinmazValidator))]
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

        public IDataResult<List<Tasinmaz>> GetAll()
        {
            return new SuccessDataResult<List<Tasinmaz>>(_tasinmazDal.GetAll(), "Listelendi");
        }

        public IDataResult<List<Tasinmaz>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Tasinmaz>>(_tasinmazDal.GetAll(p => p.TasinmazId == id));
        }

        public IDataResult<Tasinmaz> GetById(int tasinmazId)
        {
            return new SuccessDataResult<Tasinmaz>(_tasinmazDal.Get(p => p.TasinmazId == tasinmazId));
        }

        public IDataResult<List<TasinmazDetailDto>> GetTasinmazDetails()
        {
            return new SuccessDataResult<List<TasinmazDetailDto>>(_tasinmazDal.GetTasinmazDetails());
        }

        public IResult Update(Tasinmaz tasinmaz)
        {
            throw new NotImplementedException();
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

    }
}
