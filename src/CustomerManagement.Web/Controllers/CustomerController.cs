using AutoMapper;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces.Services;
using CustomerManagement.Web.Clients.ViaCep;
using CustomerManagement.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CustomerManagement.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IViaCepClient _viaCepClient;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService,
                                                    IViaCepClient viaCepClient,
                                                    IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _viaCepClient = viaCepClient ?? throw new ArgumentNullException(nameof(viaCepClient));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ActionResult> Index(string name,
                                                                       string email)
        {
            ViewData["NameFilter"] = name;
            ViewData["EmailFilter"] = email;

            var result = await _customerService.GetAllAsync(name, email);
            return View(_mapper.Map<IEnumerable<CustomerDTO>>(result));
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _customerService.GetByIdAsync(id);
            return View(_mapper.Map<CustomerDTO>(result));
        }

        public ActionResult Create()
        {
            return View(new CustomerDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerDTO customer)
        {
            try
            {
                await _customerService.AddAsync(_mapper.Map<Customer>(customer));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var result = await _customerService.GetByIdAsync(id);
            return View(_mapper.Map<CustomerDTO>(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomerDTO customer)
        {
            try
            {
                await _customerService.UpdateAsync(_mapper.Map<Customer>(customer));
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
            return View(_mapper.Map<CustomerDTO>(result));
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
