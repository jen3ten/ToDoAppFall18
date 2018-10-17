using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using ToDoAppFall18.Controllers;
using ToDoAppFall18.Models;
using Xunit;

namespace ToDoAppFall18.Tests
{
    public class HomeControllerTests
    {
        private IToDoRepository repo;
        private HomeController sut;

        public HomeControllerTests()
        {
            repo = Substitute.For<IToDoRepository>();
            sut = new HomeController(repo);
        }

        [Fact]
        public void Index_Returns_A_View()
        {
            //var expected = new List<ToDo>();

            var result = sut.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Passes_Todos_To_View()
        {
            //Testing that ToDo database records are passed to the View

            var expected = new List<ToDo>();
            repo.GetAll().Returns(expected); //NSubstitute allows us to return expected from repo.GetAll()
            //NSubstitute creates the Mock for us
            //repo never changes, but when GetAll() is called, we expect 'expected' to be returned
            //repo quietly holds on to the ToDo list
            //On our mock we implement a GetAll method

            var result = sut.Index();  //The method returns a result, which is the model
            var model = result.Model;  //The model information

            //Assert that all ToDos were passed into View
            Assert.Same(expected, model);
            //Same means same object, Equal means values are equal
        }

        [Fact]
        public void Details_Gets_Correct_ToDo()
        {
            //Test the Details action returns repo.GetById(id)
            //we care about what the id is, so we are testing for it

            var id = 1; //Assigned a magic number

            //var result = sut.Details(id);
            //we didn't use this
            sut.Details(id);

            repo.Received().GetById(id);
        }

        [Fact]
        public void Details_Passes_Id_To_View()
        {
            var id = 1;
            var result = sut.Details(id);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Details_Returns_Correct_View()
        {
            var id = 1;
            var expectedModel = new ToDo();
            repo.GetById(id).Returns(expectedModel); //This is the mock, or the NSubstitute
            //This needs to be before the Act, 
            //because the repo needs to get the expectedModel first and hold on to it
            //When somebody calls "GetById", hand them this (the expectedModel, which is ToDo)

            var result = sut.Details(id);
            var model = result.Model; //Get the ViewResult model

            Assert.Same(expectedModel, model);
        }

        [Fact]
        public void Create_Stuff_In_Database()
        {
            //We want user to be able to add an item to the list
            //We need to give them a form which allows them add information
            //We want to give them the Create view
            //do we want an id?  No, because and id will be automatically generated later
            var result = sut.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Saves_New_ToDo_Item()
        {
            var userToDoData = new ToDo()
            {
                Description = "Hi",
                DueDate = DateTime.Now
            };

            sut.Create(userToDoData);

            repo.Received().Create(userToDoData);
        }

        [Fact]
        public void Create_Redirects_To_Index()
        {
            var arbitraryToDo = new ToDo();

            var result = sut.Create(arbitraryToDo);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Delete_Returns_A_View()
        {
            var idToDelete = 42;

            var result = sut.Delete(idToDelete);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Delete_Gets_the_Details()
        {
            var idToDelete = 42;
            var ToDoToDelete = new ToDo();
            repo.GetById(idToDelete).Returns(ToDoToDelete);

            var result = sut.Delete(idToDelete);
            var model = result.Model;

            Assert.Same(ToDoToDelete, model);
        }

        [Fact]
        public void Delete_Deletes_the_ToDo_Item()
        {
            var id = 42;  //Abstract the id value
            var toDelete = new ToDo();
            repo.GetById(id).Returns(toDelete); //Because we need to get the model by the Id

            var result = sut.Delete(42);

            //Delete is the method on the generic repo, called Repository
            repo.Received().Delete(toDelete);
        }

    }
}
