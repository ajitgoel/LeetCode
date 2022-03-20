using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace WebApi.Tests
{
  public class ApiController : Controller
  {
    public const string CountryCodeHeaderName = "x-test-country-code";
    private readonly IRepository _repository;
    private StringValues headervalues;
    public ApiController(IRepository repository)
    {
      _repository = repository;
    }
    // Return UnauthorizedResult() or OkObjectResult(ICollection<Store>)
    public IActionResult GetStores()
    {
      Request.Headers.TryGetValue(CountryCodeHeaderName, out headervalues);
      if (headervalues.Count > 0 || string.IsNullOrWhiteSpace(headervalues.FirstOrDefault()))
      {
        return new UnauthorizedResult();
      }
      Func<Store, bool> filter = it => null;//Dzmitry, how will I pass a Func to the GetStores repository call?
      var stores = _repository.GetStores(filter);
      return new OkObjectResult(stores);
    }
    // Return UnauthorizedResult(), NotFoundResult(), ForbidResult() or OkObjectResult(Store)
    public IActionResult GetStore(int storeId, bool includeCustomers = false)
    {
      Request.Headers.TryGetValue(CountryCodeHeaderName, out headervalues);
      var countryCode = headervalues.FirstOrDefault();
      if (headervalues.Count > 0 || string.IsNullOrWhiteSpace(countryCode))
      {
        return new UnauthorizedResult();
      }
      Func<Store, bool> filter = it => it.StoreId= storeId;//Dzmitry, how will I pass a Func to the GetStores repository call?
      var stores = _repository.GetStores(filter, includeCustomers);
      if (!stores.All(x => x.CountryCode == countryCode))
      {
        return new ForbidResult();
      }
      var store = stores.Where(x => x.StoreId == storeId).FirstOrDefault();
      if (stores?.Count() == 0 || store == null)
      {
        return new NotFoundResult();
      }
      return new OkObjectResult(store);
    }
    // Return UnauthorizedResult(), BadRequestResult() or OkObjectResult(Customer)
    public IActionResult CreateCustomer(Customer customer)
    {
      Request.Headers.TryGetValue(CountryCodeHeaderName, out headervalues);
      if (headervalues.Count > 0 || string.IsNullOrWhiteSpace(headervalues.FirstOrDefault()))
      {
        return new UnauthorizedResult();
      }
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      var result = _repository.AddCustomer(customer);
      return new OkObjectResult(result);
    }
  }
  public interface IRepository
  {
    ICollection<Store> GetStores(Func<Store, bool> filter, bool includeCustomers = false);
    ICollection<Customer> GetCustomers(int storeId);
    Customer AddCustomer(Customer customer);
  }
  public class Store
  {
    public int StoreId { get; set; }
    public string CountryCode { get; set; }
    public ICollection<Customer> Customers { get; set; }
  }
  public class Customer
  {
    [Required]
    public int CustomerId { get; set; }
    public int StoreId { get; set; }
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }
  }
}