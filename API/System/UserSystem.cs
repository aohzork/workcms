using API.Database;
using API.Models;

namespace API.System
{
    public class UserSystem
    {
        public UserSystem() { }

        public bool ValidateIfUserExists(string userName, CrmContext context)
        {
            var storedUser = context.Set<User>().Where(x => x.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
            if (storedUser != null)
            {
                return true;
            }

            return false;
        }
    }
}
