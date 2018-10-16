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
        [Fact]
        public void Index_Returns_A_View()
        {
            var expected = new List<ToDo>();
            var repo = Substitute.For<IToDoRepository>();
            var sut = new HomeController(repo);

            var result = sut.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Passes_Todos_To_View()
        {
            //Testing that ToDo database records are passed to the View

            var expected = new List<ToDo>();
            var repo = Substitute.For<IToDoRepository>();
            repo.GetAll().Returns(expected); //NSubstitute allows us to return expected from repo.GetAll()
            //NSubstitute creates the Mock for us
            //repo never changes, but when GetAll() is called, we expect 'expected' to be returned
            //repo quietly holds on to the ToDo list
            //On our mock we implement a GetAll method

            var sut = new HomeController(repo);

            var result = sut.Index();  //The method returns a result, which is the model
            var model = result.Model;  //The model information

            //Assert that all ToDos were passed into View
            Assert.Same(expected, model);
            //Same means same object, Equal means values are equal
        }
            
    }
}
