using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labki2811.Model;
using System.Xml.Linq;

namespace labki2811.DAL
{
  public class XMLCustomerRepository : ICustomerRepository
  {
    private string _filename = "Customers.xml";

    public IEnumerable<Customer> GetAll()
    {
      return XDocument.Load(_filename)
        .Root.Elements("customer")
        .Select(nodeXML => new Customer
        {
          Id = (string)nodeXML.Element("id"),
          Name = (string)nodeXML.Element("name"),
          Address = (string)nodeXML.Element("addres"),
          City = (string)nodeXML.Element("city"),
          Postalcode = (string)nodeXML.Element("postalcode"),
          Country = (string)nodeXML.Element("country"),
          Phone = (string)nodeXML.Element("phone"),
          Fax = (string)nodeXML.Element("fax"),
          Orders = nodeXML.Element("orders").Elements("order")
          .Select(orderXMLNode => new Order
          {
            Id = (int)orderXMLNode.Element("id"),
            Orderdate = (DateTime)orderXMLNode.Element("orderdate"),
            Total = (decimal)orderXMLNode.Element("total")
          })
        }
        );
    }
  }
}
