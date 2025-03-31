using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Users
{
    #nullable enable
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken token = default);
        void Add(User user);
    }
}
