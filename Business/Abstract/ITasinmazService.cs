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
        IDataResult<List<Log>> GetAllLog();


        IDataResult<List<Tasinmaz>> GetListBySehir(int Sid);
        IDataResult<List<TasinmazDetailDto>> GetTasinmazDetails();
        IDataResult<Tasinmaz> GetById(int tasinmazId);
        
        IDataResult<List<Tasinmaz>> GetByUserId(int userId);

        
        IResult Add(Tasinmaz tasinmaz);
        IResult AddLog(Log log);
        IResult Update(Tasinmaz tasinmaz);

        IResult Delete(Tasinmaz tasinmaz);




    }
}
