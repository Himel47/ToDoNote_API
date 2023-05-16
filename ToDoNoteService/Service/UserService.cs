using ToDoNoteData.Data;
using ToDoNoteData.Dto;
using ToDoNoteData.Entities;
using ToDoNoteService.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDoNoteService.Service
{
    public class UserService : IUserService
    {
        private readonly dbConnection connection;

        public UserService(dbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<NewUser> RegisterUserAsync(NewUser user)
        {
            if(user != null)
            {
                var RegisteredUser = new User()
                {
                    Name = user.Name,
                    Email = user.Email,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                };
                if(user.ProfilePhoto!= null)
                {
                    RegisteredUser.ProfilePicture = Path.Combine(@"C:\Users\BS358\Documents\ToDoNote_API\ToDoNoteData\Photos\UserProfile\", $"{user.Name}.jpg");
                    using Stream stream = new FileStream(RegisteredUser.ProfilePicture, FileMode.Create);
                    await user.ProfilePhoto.CopyToAsync(stream);
                }
                connection.Users.Add(RegisteredUser);
                var SaveNote = Save();
                if (SaveNote)
                {
                    return user;
                }
            }
            return null;
        }
        public ICollection<User> GetAllUsersAsync()
        {
            var AllUsers = connection.Users.OrderBy(x => x.Id).ToList();
            foreach (var user in AllUsers)
            {
                user.CreatedBy = (int)user.Id;
            }
            return AllUsers;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            var UserById = connection.Users.Where(x => x.Id == id).SingleOrDefault();
            UserById.CreatedBy = id;
            return UserById;
        }
        public async Task<User> DeleteUserAsync(int id)
        {
            var deletedUser = connection.Users.Where(x => x.Id == id).FirstOrDefault();
            if (deletedUser != null)
            {
                deletedUser.IsActive = false;
                var SaveDelete = Save();
                if (SaveDelete) { return deletedUser; }
            }
            return null;
        }
        public async Task<NewUser> UpdateUserAsync(NewUser user)
        {
            var UserById = connection.Users.Where(x => x.Id == user.Id).SingleOrDefault();
            if (UserById != null)
            {
                UserById.Email = user.Email;
                UserById.UpdatedBy = user.Id;
                UserById.UpdatedDate = DateTime.Now;
                if (user.ProfilePhoto != null)
                {
                    UserById.ProfilePicture = Path.Combine(@"C:\Users\BS358\Documents\ToDoNote_API\ToDoNoteData\Photos\UserProfile\", $"{user.Name}.jpg");
                    using Stream stream = new FileStream(UserById.ProfilePicture, FileMode.Create);
                    await user.ProfilePhoto.CopyToAsync(stream);
                }
                UserById.Name = user.Name;
                connection.Users.Update(UserById);
                var SaveUpdate = Save();
                if (SaveUpdate)
                {
                    return user;
                }
            }
            return user;
        }
        public bool IfIdExist(int id)
        {
            return connection.Notes.Any(x => x.Id == id);
        }
        public bool Save() => connection.SaveChanges() > 0 ? true : false;
    } 
}
