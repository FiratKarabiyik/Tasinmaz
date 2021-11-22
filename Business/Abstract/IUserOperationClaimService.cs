using Core.Entities.Concrete;
using Core.Utilities;
using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Text;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();

    }
}
