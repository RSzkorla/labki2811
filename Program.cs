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
    public static IEnumerable<Order> GetOrdersBetween(IEnumerable<Customer> r)
      => r
        .SelectMany(x => x.Orders
          .Where(y => y.Orderdate >= new DateTime(1996, 07, 01) && 
                      y.Orderdate <= new DateTime(1996, 08, 31)
                )
              )
        ;   
    public static IEnumerable<Order> GetOrdersAbove1000(IEnumerable<Customer> r)
      =>r
      .SelectMany(x => x.Orders.Where(y=>y.Total>1000))
      ;
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
      => r
        .Select(x => x.Country)
        .Distinct();

    public static IEnumerable<Customer> GetTop3Customers(IEnumerable<Customer> r)
      => r
        .OrderByDescending(x => x.Orders.Sum(y => y.Total))
        .Take(3);

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

      var ord = GetOrdersAbove1000(customers);

      var ord1 = GetOrdersBetween(customers);

      foreach (var item in ord1)
      {
        Console.WriteLine($"{item.Id}: {item.Orderdate}");
      }


    }
  }
}
