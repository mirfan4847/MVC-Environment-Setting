using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvironmentSetting.Model;
using EnvironmentSetting.Data;
using AutoMapper;
using EnvironmentSetting.ViewModel;
using EnvironmentSetting.ExceptionManager;
using System.Transactions;

namespace EnvironmentSetting.BusinessLogic
{
    public class UsersBusinessLogic : IUsersBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersBusinessLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddUser(UserViewModel model)
        {
            try
            {
                var user = new Users()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Position = model.Position,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNo = model.PhoneNo,
                    MobNo = model.MobNo,
                    Email = model.Email,
                    FaxNo = model.FaxNo,
                    Active = model.Active,
                    ActivatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = DateTime.Now
                };

                _unitOfWork.Users.Add(user);
                using (var scope = new TransactionScope())
                {
                    _unitOfWork.Complete();
                    scope.Complete();
                };
                return true;
            }
            catch (Exception ex)
            {
                BusinessLogicExceptions.WriteExceptionMessageToFile(ex.Message, ex);
                return false;
            }
        }

        public bool Registration(UserViewModel model)
        {
            try
            {
                var user = new Users()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Position = model.Position,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNo = model.PhoneNo,
                    MobNo = model.MobNo,
                    Email = model.Email,
                    FaxNo = model.FaxNo,
                    Active = model.Active,
                    ActivatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = DateTime.Now
                };

                _unitOfWork.Users.Add(user);
                using (var scope = new TransactionScope())
                {
                    _unitOfWork.Complete();
                    scope.Complete();
                };
                return true;
            }
            catch (Exception ex)
            {
                BusinessLogicExceptions.WriteExceptionMessageToFile(ex.Message, ex);
                return false;
            }
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            try
            {
                var result = Mapper.Map<IEnumerable<Users>, IEnumerable<UserViewModel>>
                    (_unitOfWork.Users.GetAllUsers());
                return result;
            }
            catch (Exception ex)
            {
                BusinessLogicExceptions.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}
