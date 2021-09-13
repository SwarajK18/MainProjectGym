using MainProjectGym.DAL.Data.Models;
using MainProjectGym.DAL.Repository;
using MainProjectGym.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProjectGym.Services.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserViewModel>> GetAllUsers();
        public Task<User> GetUserByID(int Id);
        public Task<User> CreateUser(User user);
        public Task<User> UpdateUser(User user);
        public Task<bool> DeleteUser(int Id);
    }
    public class UserService : IUserService
    {
        public async Task<User> CreateUser(User user)
        {
            bool isAdded = new GenericRepository<User>().Create(user);
            if (isAdded)
            {
                return user;
            }
            return null;
        }

        public async Task<bool> DeleteUser(int Id)
        {
            GenericRepository<User> genericRepository = new GenericRepository<User>();
            User user = genericRepository.GetById(Id);
            if (user != null)
            {
                user.IsActive = false;
                genericRepository.Update(user);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            var res = new GenericRepository<User>().GetAll();

            var users = res.Where(doc => doc.IsActive != false).Select(o => new UserViewModel
            {
                UserId = o.UserId,
                FirstName = o.UserName,
                Email = o.Email,
                Age = o.Age,
                Gender = o.Gender,
                Membership = o.Membership,
                Number = o.PhoneNumber,
                Role = o.Role
 

            });

            return users;
        }

        public async Task<User> GetUserByID(int Id)
        {
            return new GenericRepository<User>().GetByCondition(user => user.UserId == Id && user.IsActive != false).SingleOrDefault();
        }

        public async Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}