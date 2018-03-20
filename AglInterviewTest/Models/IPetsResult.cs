using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AglInterviewTest.Models
{
    public interface IPetsResult
    {
        List<PetsResultModel> GetPets(string Gender, string PetType, List<Person> Persons);
    }
}
