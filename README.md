# AGL_Interview
This repository is for AGL Coding test purpose.

1) Application is Developed in Sitecore MVC. All the renderings are available in the web project "AglInterviewTest".
2) All the sitecore serialized items are provided in "Sitecore.AglInterviewTest.Serialization" project under "Serialization" folder. 
3) Please change the physicalPath value in both the projects for Unicorn serialization items to sync up with your local sitecore instance.

# Web Project - AglInterviewTest
1) This project is developed in ASP.Net MVC 5 with .Net Framework 4.5.2
2) Below are the models created as part of this project
  2.1) IGlassBase - Interface with default sitecore fields
  2.2) IPageInfo - Interface (Object modal) for the Home template (/sitecore/templates/Person/Home) in sitecore
  2.3) IPetsResult - Interface for actual results, which contains a method (GetPets) to get the Pets for provided Gendar, PetType from the list of Persons.
  2.4) PersonModel - Is the Object Model for json content of provided api (http://agl-developer-test.azurewebsites.net/people.json).
  2.5) PetsResultModel - Is the model class which implements the IPetsResult interface and implements the business logic to filter the Pets based on the input parametrs and sort by the Pet Owner Name. Also it contains the properties to store the Pets information.
3) PersonInfoController - is the MVC Controller having the two action methods
  3.1) For Male Owner Pets
  3.2) For Female Owner Pets
4) Each of the above action methods retrive the people information from api (which reads from Sitecore Item field APIUrl), and uses te PetsResultModel to get the respective Pets information and passes to the view.
5) RESTClient - is the Generic class which has been developed for send and receive the Web Service requests and transform the JSON respons to the Generic Object. Provided the capability to perform all the HTTP method request types such as GET, POST, PUT and DELETE.

# Serialization Project - Sitecore.AglInterviewTest.Serialization
1) This project is for Serializing the Sitecore (Templates/Layouts and Renderings/Content) items.
2) This is useful when you try to move the application from one environment to other. even for testing in your local machine.

# Unit Tests Project - AglInterviewTest.UnitTests
1) This Project is for all the Unit tests that are part of the solution.
2) Created Unit Tests for validating the PetsResults against the Male, Female and Pet Type.
3) Created Unit Test for validating the Sitecore item null validity.

# Sitecore Items
  1) Templates: 
    1.1) /sitecore/templates/person/home
  2) Layouts: 
    2.1) /sitecore/layout/layouts/person/basicpersonlayout
  3) Renderings: 
    3.1) /sitecore/layout/rendering/person/pageblocks/2Columns
    3.2) /sitecore/layout/rendering/person/maleownercats
    3.3) /sitecore/layout/rendering/person/femaleownercats
   4) Content:
    4.1) /sitecore/content/Home/PetsByOwnerGender
   
