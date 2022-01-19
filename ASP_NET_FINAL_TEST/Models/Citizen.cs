using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_FINAL_TEST.Models
{
    public class Citizen
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string FatherName { get; set; }

        public string Gender { get; set; }

        public bool BornedInVillage { get; set; }

        public int BirthDay { get; set; }

        public Citizen(int id, string fullName, string fatherName, string gender, bool bornedInVillage, int birthDay)
        {
            Id = id;
            FullName = fullName;
            FatherName = fatherName;
            Gender = gender;
            BornedInVillage = bornedInVillage;
            BirthDay = birthDay;
        }
        
        public Citizen() { }

    }
}