using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces.Services;
using CustomerManagement.Web.Clients.ViaCep;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CustomerManagement.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IViaCepClient _viaCepClient;

        public CustomerController(ICustomerService customerService,
                                                    IViaCepClient viaCepClient)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _viaCepClient = viaCepClient ?? throw new ArgumentNullException(nameof(viaCepClient));
        }
        public async Task<ActionResult> Index(string name,
                                                                       string email)
        {
            ViewData["NameFilter"] = name;
            ViewData["EmailFilter"] = email;

            var result = await _customerService.GetAllAsync(name, email);
            //var result = await _customerService.GetAllAsync(x => (string.IsNullOrWhiteSpace(name) || x.Name.Contains(name)) || (string.IsNullOrWhiteSpace(email) || x.Email.Contains(email)));
            return View(result);
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _customerService.GetByIdAsync(id);
            return View(result);
        }

        public ActionResult Create()
        {
            //var categories = await _productClient.GetAllCategoriesAsync();
            //ViewBag.Categories = categories.Select(_ => new SelectListItem() { Text = _.Name, Value = _.Id.ToString() });
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
                await _customerService.AddAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            // await CreateViewBagCategoriesAsync();
            var result = await _customerService.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Customer customer)
        {
            try
            {
                await _customerService.UpdateAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var result = await _customerService.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _customerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult<ViaCepResponse>> ValidateCep(string cep)
        {
            var result = await _viaCepClient.GetAsync(cep);

            return Ok(result);
        }
    }
}
