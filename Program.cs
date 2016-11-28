using labki2811.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labki2811
{

  class Program
  {

    
    static void Main(string[] args)
    {
      ICustomerRepository repo = new XMLCustomerRepository();

      var customers = repo.GetAll();

      foreach (var item in customers)
      {
        Console.WriteLine($"{item.Name}:{item.Orders.Count()}");
      }
    }
  }
}
