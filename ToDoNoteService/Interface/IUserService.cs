
using ToDoNoteData.Dto;
using ToDoNoteData.Entities;

namespace ToDoNoteService.Interface
{
    public interface IUserService
    {
        Task<NewUser> RegisterUserAsync(NewUser user);
        Task<NewUser> UpdateUserAsync(NewUser user);
        ICollection<User> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> DeleteUserAsync(int id);
        bool IfIdExist(int id);
        bool Save();
    }
}
