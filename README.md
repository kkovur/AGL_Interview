# AGL_Interview
This repository is for AGL Coding test purpose.

*  Application is Developed in Sitecore MVC. All the renderings are available in the web project "AglInterviewTest".
*  All the sitecore serialized items are provided in "Sitecore.AglInterviewTest.Serialization" project under "Serialization" folder. 
*  Please change the physicalPath value in both the projects for Unicorn serialization items to sync up with your local sitecore instance.

# Web Project - AglInterviewTest
*  This project is developed in ASP.Net MVC 5 with .Net Framework 4.5.2
*  Below are the models created as part of this project
	* **IGlassBase** - Interface with default sitecore fields
	*	**IPageInfo** - Interface (Object modal) for the Home template (/sitecore/templates/Person/Home) in sitecore
	*	**IPetsResult** - Interface for actual results, which contains a method (GetPets) to get the Pets for provided Gendar, PetType from the list of Persons.
	*	**PersonModel** - Is the Object Model for json content of provided api (http://agl-developer-test.azurewebsites.net/people.json).
	*	**PetsResultModel** - Is the model class which implements the IPetsResult interface and implements the business logic to filter the Pets based on the input parametrs and sort by the Pet Owner Name. Also it contains the properties to store the Pets information.
*  **PersonInfoController** - is the MVC Controller having the two action methods
	* For Male Owner Pets
	* For Female Owner Pets
*	Each of the above action methods retrive the people information from api (which reads from Sitecore Item field APIUrl), and uses te PetsResultModel to get the respective Pets information and passes to the view.
*	**RESTClient** - is the Generic class which has been developed for send and receive the Web Service requests and transform the JSON respons to the Generic Object. Provided the capability to perform all the HTTP method request types such as GET, POST, PUT and DELETE.

# Serialization Project - Sitecore.AglInterviewTest.Serialization
*	This project is for Serializing the Sitecore (Templates/Layouts and Renderings/Content) items.
*	This is useful when you try to move the application from one environment to other. even for testing in your local machine.

# Unit Tests Project - AglInterviewTest.UnitTests
*	This Project is for all the Unit tests that are part of the solution.
*	Created Unit Tests for validating the PetsResults against the Male, Female and Pet Type.
*	Created Unit Test for validating the Sitecore item null validity.

# Sitecore Items
*	**Templates:**
	*	/sitecore/templates/person/home
*	**Layouts:** 
	*	/sitecore/layout/layouts/person/basicpersonlayout
*	**Renderings:** 
	*	/sitecore/layout/rendering/person/pageblocks/2Columns
	*	/sitecore/layout/rendering/person/maleownercats
	*	/sitecore/layout/rendering/person/femaleownercats
*	**Content:**
	*	/sitecore/content/Home/PetsByOwnerGender
   
 
