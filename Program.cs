using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labki2811
{
  class Bisekcja
  {
    private double _a { get; set; }
    private double _b { get; set; }
    private double eps { get; set; }

    public Func<double,double> F { get; set; }

    public Bisekcja(double a, double b , double e = 1e-9)
    {
      _a = a;
      _b = b;
      eps = e;
    }
    public double Solve()
    {
      if (F==null)
      {
        throw new ArgumentException();
      }
      if (F(_a)*F(_b) >0 )
      {
        throw new ArgumentOutOfRangeException();
      }
      double x0;
      do
      {
        double mid = (_a + _b) / 2;

        x0 = mid;

        if (Math.Abs(F(mid)) < eps)
        {
          x0 = mid;
          break;
        }

        if (F(_a)*F(mid)<0)
        {
          _b = mid;
        }
        else
        {
          _a = mid;
        }
      } while (Math.Abs(_a- _b)> eps);
      return x0;
    }


  }

  class Program
  {

    
    static void Main(string[] args)
    {
      Bisekcja kont = new Bisekcja((2/3f)*Math.PI, (3/2f)*Math.PI,1e-10);
      kont.F = Math.Sin;
      Console.WriteLine(kont.Solve());
    }
  }
}
