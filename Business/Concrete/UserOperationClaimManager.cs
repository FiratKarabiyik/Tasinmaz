using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class UserOperationClaimManager :IUserOperationClaimService
    {
        IUserOperationClaimDal _useroperationclaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal useroperationclaimDal)
        {
            _useroperationclaimDal = useroperationclaimDal;
        }
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_useroperationclaimDal.GetAll(), "Listelendi");
        }

    }
}
