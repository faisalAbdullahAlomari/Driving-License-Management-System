using DataAccessLayer;

namespace BusinessLayer
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {

            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {

            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
        }

        public static clsUser Find(string UserName, string Password)
        {

            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            if(clsDataAccess.FindUserByUserNameAndPassword(ref UserID, ref PersonID, UserName, Password, ref IsActive))
            {
               return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }
    }
}
