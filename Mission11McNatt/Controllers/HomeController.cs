using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission11McNatt.Models;
using Mission11McNatt.Models.ViewModels;

namespace Mission11McNatt.Controllers;

public class HomeController : Controller
{
  private IBookRepository _repo;

  public HomeController(IBookRepository repo)
  {
    _repo = repo;
  }

  public IActionResult Index(int pageNum)
  {
    int pageSize = 10;

    var blvm = new BooksListViewModel
    {
      Books = _repo.Books
        .OrderBy(x => x.Title)
        .Skip((pageNum - 1) * pageSize)
        .Take(pageSize),

      PaginationInfo = new PaginationInfo
      {
        CurrentPage = pageNum,
        ItemsPerPage = pageSize,
        TotalItems = _repo.Books.Count()
      }
    };

    return View();
  }
}
