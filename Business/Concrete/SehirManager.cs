using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SehirManager : ISehirService
    {
        ISehirDal _sehirDal;

        public SehirManager(ISehirDal sehirDal)
        {
            _sehirDal = sehirDal;
        }
        public IDataResult<List<Sehir>> GetAll()
        {
            return new SuccessDataResult<List<Sehir>>(_sehirDal.GetAll(), "Listelendi");
        }
    }
}
