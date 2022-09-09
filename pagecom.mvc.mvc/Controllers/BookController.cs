using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using pagecom.mvc.application.Dto;
using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Features.BookFeatures.Request.Command;
using pagecom.mvc.application.Features.BookFeatures.Request.Query;

namespace pagecom.mvc.mvc.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;


        public BookController(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        private async Task createToken()
        {
            //var value = await HttpContext.GetTokenAsync("access_token");
            var value =await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            ContextStatic.tokenInfo = value;
        }

        // GET: BookController
        public async Task<IActionResult> Index()
        {
            
            
            await LogTokenAndClaims();
            // delete this later bad code
            this.createToken();
            
            
            var access_token = await HttpContext.GetTokenAsync("access_token");
            var bookList = await _mediator.Send(new GetAllBooksRequest());
            return View(bookList);
        }


        public async Task LogTokenAndClaims()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            Console.WriteLine($"token {identityToken}");

            foreach (var claim in User.Claims)
            {
                Console.WriteLine($"claim types {claim.Type} - claim value: {claim.Value}" );
            }
        }

        // GET: BookController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var bookList = await _mediator.Send(new GetBookFromIdRequest(id));
            return View(bookList);
        }

        // GET: BookController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewDto bookObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._mediator.Send(new BookCreateCommand(bookObj));
                    if (response != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    
                }

                
            }
            catch
            {
                return View();
            }

            return View(bookObj);
        }

        // GET: BookController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var bookList = await _mediator.Send(new GetBookFromIdRequest(id));
            return View(bookList);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookViewDto bookobj)
        {
            try
            {
                var bookList = await _mediator.Send(new BookUpdateCommand(id,bookobj));
                return RedirectToAction("Details",new { id = id});
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        
        public async Task<IActionResult> Delete(int id)
        {
            var bookInfo = await _mediator.Send(new GetBookFromIdRequest(id));
            if (bookInfo != null)
            {
                // todo send not found    
            }
            return View(bookInfo);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMethod(int id)
        {
            try
            {
                bool value = await _mediator.Send(new BookDeleteCommand(id));
                if (value) return RedirectToAction(nameof(Index));
                // todo send not found or process error 
            }
            catch
            {
                throw new NotImplementedException();
                // return View();
            }

            return RedirectToAction("Index");
        }
    }
}
