using Dal.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public List<UserMenuItem> UserMenuItems { get; set; }
        public List<UserDislike> Dislikes { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
