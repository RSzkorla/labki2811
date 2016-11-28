using labki2811.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labki2811.DAL
{
  interface ICustomerRepository
  {
    IEnumerable<Customer> GetAll();
  }
}
