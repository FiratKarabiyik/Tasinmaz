using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTasinmaz : EfEntityRepositoryBase<Tasinmaz, Context>, ITasinmazDal
    {
        public List<TasinmazDetailDto> GetTasinmazDetails()
        {
            using (Context context = new Context())

            {
                var result = from p in context.Tasinmaz
                             join c in context.User
                             on p.UserId equals c.Id
                             select new TasinmazDetailDto
                             {
                                 TasinmazId = p.TasinmazId,
                                 Il = p.Il,
                                 UserId = c.Id,
                                 Ilce = p.Ilce
                             };
                return result.ToList();

            }
        }
    }
}
