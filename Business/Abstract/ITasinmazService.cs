using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITasinmazService
    {
        IDataResult<List<Tasinmaz>> GetAll();
        IDataResult<List<Tasinmaz>> GetAllByCategoryId(int id);
        IDataResult<List<TasinmazDetailDto>> GetTasinmazDetails();
        IDataResult<Tasinmaz> GetById(int tasinmazId);
        IResult Add(Tasinmaz tasinmaz);
        IResult Update(Tasinmaz tasinmaz);



    }
}
