using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AglInterviewTest.Models
{
    public class PetsResultModel : IPetsResult
    {
        public string PetName { get; set; }
        public string OwnerGender { get; set; }
        public string PetType { get; set; }
        private string APIUrl;
        public PetsResultModel()
        {
         
        }
        public PetsResultModel(string apiURL)
        {
            this.APIUrl = apiURL;
        }

        public List<PetsResultModel> GetPets(string Gender, string PetType, List<Person> Persons)
        {
            try
            {                
                List<PetsResultModel> cats = (from person in Persons
                                              where person.Pets != null && person.Gender.ToLower() == Gender.ToLower()
                                              orderby person.Name
                                              from pet in person.Pets
                                              where pet.Type.ToLower() == PetType.ToLower()
                                              select new PetsResultModel()
                                              {
                                                  PetName = pet.Name,
                                                  OwnerGender = person.Gender,
                                                  PetType = pet.Type
                                              }).ToList<PetsResultModel>();
                return cats;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}