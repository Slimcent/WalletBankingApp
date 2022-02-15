using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Services.Exceptions
{
    public class UserExistException : NotFoundException
    {
        public UserExistException(string email)
            : base($"The user with email: {email} already exist in the database.")
        {
        }
    }
}
