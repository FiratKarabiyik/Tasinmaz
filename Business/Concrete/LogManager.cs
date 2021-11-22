using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LogManager : ILogService
    {
        ILogDal _logDal;

        public LogManager(ILogDal logDal)
        {
            _logDal = logDal;
        }
        public IResult Add(Log log)
        {
            //iş kodları                  

            _logDal.Add(log);
            return new SuccessResult("Eklendi");

        }
    }


}
