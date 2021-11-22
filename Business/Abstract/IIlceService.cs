using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IIlceService
    {
        IDataResult<List<Ilce>> GetAll();

        IDataResult<Ilce> GetById(int Iid);
        IDataResult<List<Ilce>> GetList();
        IDataResult<List<Ilce>> GetListByCategory(int categoryId);

        IDataResult<List<Ilce>> GetBySehirID(int id);

    }
}
