using E_Commerce_API.src.Models;
using E_Commerce_API.src.Repositories;

namespace E_Commerce_API.src.Service
{
    public class UserService
    {
        private readonly Repository<User> _repository;

        public UserService(Repository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetUserByID(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<User> CreatedUser(User user)
        {
            await _repository.Create(user);
            return user;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            User user = new User();
            user = await GetUserByID(id);

            if (user == null)
            {
                return false;
            }

            await _repository.Delete(user);
            return true;
        }
    }
}
