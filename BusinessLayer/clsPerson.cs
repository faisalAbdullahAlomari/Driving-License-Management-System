using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPerson
    {

        private bool _AddNewPerson()
        {
            this.PersonID = clsDataAccess.AddNewPerson(this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        
            return (this.PersonID != -1);
        }

        enum enMode { AddNewPerson = 1, UpdatePerson = 2 }

        enMode Mode = enMode.AddNewPerson;

        int PersonID { get; set; }
        string NationalNumber { get; set }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string ThirdName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        bool Gender { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        int NationalityCountryID { get; set; }
        string ImagePath { get; set; }

        public clsPerson()
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
            this.NationalityCountryID = -1;
            this.ImagePath = "";
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNewPerson:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.UpdatePerson;
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                default:
                    return false;
            }
        }
    }
}
