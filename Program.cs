using labki2811.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labki2811.Model;

namespace labki2811
{

  class Program
  {

    public static IEnumerable<dynamic> GetGroupedCustomers(IEnumerable<Customer> r) 
      => r
      .GroupBy(x => x.Country)
      .Select(x => new
        {
        Country = x.Key,
        Customers = x
          .Select(y => y)
          .OrderBy(y => y.Name)
        })
      .OrderBy(x=>x.Country);
    
    public static IEnumerable<string> GetCountries(IEnumerable<Customer> r)
      => r.Select(x => x.Country).Distinct();

    public static IEnumerable<Customer> GetTop3Customers(IEnumerable<Customer> r)
      => r.OrderByDescending(x => x.Orders.Sum(y => y.Total)).Take(3);

    public static IEnumerable<Model.Customer> GetCustomersFromBerlin(IEnumerable<Model.Customer> r) 
      => r.Where(x => x.City == "Berlin");
    
    static void Main(string[] args)
    {
      ICustomerRepository repo = new XMLCustomerRepository();

      var customers = repo.GetAll()
        .OrderBy(x=> x.Name);

      var top3customers = GetTop3Customers(customers);

      var coutries = GetCountries(customers).OrderBy(x=> x);

      var customersColection = GetGroupedCustomers(customers);

      var cus = GetGroupedCustomers(customers);
    
      
      foreach (var item in cus)
      {
        Console.WriteLine(item.Country);
        foreach (var customer in item.Customers)
        {
          Console.WriteLine($"  -{customer.Name}");
        }
      }
    }
  }
}
