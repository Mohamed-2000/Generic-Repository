using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositryPattern.Core;
using RepositryPattern.Core.Consts;
using RepositryPattern.Core.Interfaces;
using RepositryPattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetTheWhole")]
        public IActionResult GetTheWhole()
        {
            return Ok(_unitOfWork.Books.GetTheWhole(new[] { "Author" }));
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "New Book", new[] { "Author" }));
        }

        //[HttpGet("GetByName")]
        //public IActionResult GetByName(string n)
        //{
        //    return Ok(_unitOfWork.Books.Find(b => b.Title == n));
        //}

        [HttpGet("GetAllWuthAuthors")]
        public IActionResult GetAllWuthAuthors()
        {
            //return Ok(_booksRepository.FindALL(b => b.Title == "New Book", new[] { "Author" }));
            return Ok(_unitOfWork.Books.FindALL(b => b.Title.Contains("New Book"), new[] { "Author" }));
        }

        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            //return Ok(_booksRepository.FindALL(b => b.Title == "New Book", new[] { "Author" }));
            return Ok(_unitOfWork.Books.FindALL(b => b.Title.Contains("New Book"), null, null, b => b.Id, OrderBy.Descending));
        }

        //[HttpPost("AddOne")]
        //public IActionResult AddOne(Book b)
        //{
        //    //return Ok(_booksRepository.FindALL(b => b.Title == "New Book", new[] { "Author" }));
        //    return Ok(_unitOfWork.Books.Add(b));
        //}

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            //return Ok(_booksRepository.FindALL(b => b.Title == "New Book", new[] { "Author" }));
            var book = _unitOfWork.Books.Add(new Book { Title = "DevOPs", AuthorId = 1 });
            _unitOfWork.Complete();
            return Ok(book);
        }
    }
}
