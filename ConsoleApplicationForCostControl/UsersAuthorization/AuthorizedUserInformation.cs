using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.UsersAuthorization
{
    public class AuthorizedUserInformation
    {

        private static int _authorizedUserId;

        public int AuthorizedUserId
        {
            get { return _authorizedUserId; }
            set { _authorizedUserId = value; }
        }
    }
}
