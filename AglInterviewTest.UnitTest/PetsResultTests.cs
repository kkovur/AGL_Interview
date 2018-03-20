using System;
using AglInterviewTest.Models;
using System.Collections.Generic;
using NUnit.Framework;

namespace AglInterviewTest.UnitTest
{
    [TestFixture]
    public class PetsResultTests
    {
        private List<Person> CreateTestPersons()
        {
            List<Person> persons = new List<Person>();
            Person p = new Person()
            {
                Name = "Smith",
                Age = 20,
                Gender = "Male",
                Pets = new List<Pet>(){
                     new Pet() { Name="Jimmy0", Type="Dog" },
                    new Pet() { Name = "Simmy0", Type = "Cat" },
                    new Pet() { Name = "Manny0", Type = "Cat" }
                }
            };
            persons.Add(p);
            p = new Person()
            {
                Name = "John",
                Age = 20,
                Gender = "Male",
                Pets = new List<Pet>(){
                     new Pet() { Name="Jimmy1", Type="Dog" },
                    new Pet() { Name = "Simmy1", Type = "Cat" },
                    new Pet() { Name = "Manny1", Type = "Cat" }
                }
            };
            persons.Add(p);
            p = new Person()
            {
                Name = "Lima",
                Age = 20,
                Gender = "Female",
                Pets = new List<Pet>(){
                     new Pet() { Name="Jimmy2", Type="Dog" },
                    new Pet() { Name = "Simmy2", Type = "Cat" },
                    new Pet() { Name = "Manny2", Type = "Cat" }
                }
            };
            persons.Add(p);
            p = new Person()
            {
                Name = "Nancy",
                Age = 20,
                Gender = "Female",
                Pets = new List<Pet>(){
                     new Pet() { Name="Jimmy3", Type="Dog" },
                    new Pet() { Name = "Simmy3", Type = "Cat" },
                    new Pet() { Name = "Manny3", Type = "Cat" }
                }
            };
            persons.Add(p);

            p = new Person()
            {
                Name = "Andrea",
                Age = 20,
                Gender = "Female",
                Pets = new List<Pet>(){
                     new Pet() { Name="Jimmy4", Type="Dog" },
                    new Pet() { Name = "Simmy4", Type = "Cat" },
                    new Pet() { Name = "Manny4", Type = "Cat" }
                }
            };
            persons.Add(p);

            p = new Person()
            {
                Name = "Gimson",
                Age = 20,
                Gender = "Male",
                Pets = new List<Pet>(){
                     new Pet() { Name="Jimmy5", Type="Dog" },
                    new Pet() { Name = "Simmy5", Type = "Cat" },
                    new Pet() { Name = "Manny5", Type = "Cat" }
                }
            };
            persons.Add(p);
            return persons;
        }
        [Test]
        public void GetPets_WithMaleOwner_Cats()
        {
            //Arrange
            PetsResultModel petResults = new PetsResultModel();
            List<Person> testPersons = CreateTestPersons();
            //Act
            var maleOwnerCats = petResults.GetPets("Male", "Cat", testPersons);            

            //Assert
            foreach (var pet in maleOwnerCats)
            {                
                Assert.AreEqual("Cat",pet.PetType);
                Assert.AreEqual("Male",pet.OwnerGender);
            }            
        }

        [Test]
        public void GetPets_WithFemaleOwner_Cats()
        {
            //Arrange
            PetsResultModel petResults = new PetsResultModel();
            List<Person> testPersons = CreateTestPersons();
            //Act
            var femaleOwnerCats = petResults.GetPets("Female", "Cat", testPersons);

            //Assert
            foreach (var pet in femaleOwnerCats)
            {
                Assert.AreEqual("Cat", pet.PetType);
                Assert.AreEqual("Female", pet.OwnerGender);
            }
        }

        [Test]
        public void GetPets_WithNoPetTypeAvailable()
        {
            //Arrange
            PetsResultModel petResults = new PetsResultModel();
            List<Person> testPersons = CreateTestPersons();
            //Act
            var maleOwnerCats = petResults.GetPets("Male", "", testPersons);

            //Assert
            Assert.AreEqual(maleOwnerCats.Count, 0);
        }
    }
}
