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

    public static IEnumerable<Customer> GetTop3Customers(IEnumerable<Customer> r)
    {
      return r.OrderByDescending(x => x.Orders.Sum(y => y.Total)).Take(3);
    }
    public static IEnumerable<Model.Customer> GetCustomersFromBerlin(IEnumerable<Model.Customer> r) 
      => r.Where(x => x.City == "Berlin");
    
    static void Main(string[] args)
    {
      ICustomerRepository repo = new XMLCustomerRepository();

      var customers = repo.GetAll()
        .OrderBy(x=> x.Name);

      var top3customers = GetTop3Customers(customers);

      foreach (var item in top3customers)
      {
        Console.WriteLine($"{item.Name} : {item.Orders.Sum(y => y.Total)}");
      }
    }
  }
}
