using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labki2811
{
  class Bisekcja
  {
    private double A { get; set; }
    private double B { get; set; }
    private double eps { get; set; }

    public Func<double,double> F { get; set; }

    public Bisekcja(double a, double b, DelegatFuncj f , double e = 1e-9)
    {
      A = a;
      B = b;
      F = f;
      eps = e;
    }
  }

  class Program
  {

    
    static void Main(string[] args)
    {
      Bisekcja kont = new Bisekcja();
      double x0 = 0;
      kont.F = x => x * x;
      do
      {
        
      } while (Math.Abs(kont.F(x0))<kont.eps|| );

    }
  }
}
