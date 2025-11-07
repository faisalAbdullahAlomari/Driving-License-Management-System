using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPeople
    {

        int PersonID { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string ThirdName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        bool Gender { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string NationalityCountryID { get; set; }
        string ImagePath { get; set; }

        public clsPeople()
        {

            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = true;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = "";
            this.ImagePath = "";
        }

        public static DataTable Find()
        {
            return clsDataAccess.GetAllThePeople();
        }
    }
}
