using DbConnection;
using PowerPack.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerPack.API.Repositories
{
    public interface ILogInUserRepository: IGenericRepository<LogInUser>
    {
        Task<LogInUser> GetLogInUserByUserName(string UserName,string Password);
        Task<IEnumerable<LogInUser>> GetUserList(int Id);
    }
}
