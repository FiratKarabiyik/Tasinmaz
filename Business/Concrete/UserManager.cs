using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
     
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
            
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Listelendi");
        }


        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id));
        }



        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("silindi");
        }

      

        public IResult UpdateUser(UserUpdateDto userUpdateDto) 
        {

            var userResult = GetById(userUpdateDto.Id);
            if (!userResult.Success)
                return new ErrorResult(userResult.Message);

            if (!HashingHelper.VerifyPasswordHash(userUpdateDto.ActivePassword, userResult.Data.PasswordHash, userResult.Data.PasswordSalt))
                return new ErrorResult("Şifre hatalı");

            // var customerResult = _userDal.Get(u => u.Email == userUpdateDto.Email);
            // if (customerResult != null)
            // return new ErrorResult("Bu Eposta Adresi kullanılıyor");


            if (userResult.Data.Email != userUpdateDto.Email)
            {
                if (GetByMail(userUpdateDto.Email) != null)
                {

                    return new ErrorResult("Kullanıcı mevcut");
                }



            }


            userResult.Data.FirstName = userUpdateDto.FirstName;
            userResult.Data.LastName = userUpdateDto.LastName;
            userResult.Data.Email = userUpdateDto.Email;

         
            if (userUpdateDto.NewPassword.Length > 5)
            {
                HashingHelper.CreatePasswordHash(userUpdateDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
                userResult.Data.PasswordHash = passwordHash;
                userResult.Data.PasswordSalt = passwordSalt;
            }


            try
            {
                Update(userResult.Data);
            }
            catch (Exception)
            {
                return new ErrorResult("Güncelleme Başarısız");
            }

            return new SuccessResult("Güncelleme Başarılı");


            
        }

        public IDataResult<User> GetByIdLogin(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id));
        }

        public User GetUserById(int id)
        {
            return _userDal.GetUserById(id);
        }

        public IResult Update(User user)
        {


          
            _userDal.Update(user);
            return new SuccessResult("Başarılı");
        }
    }
}
