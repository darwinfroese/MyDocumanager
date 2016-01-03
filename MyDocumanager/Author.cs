using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumanager
{
  public class Author
  {
    private int _id;
    private string _name;

    public int ID { get { return _id; } }
    public string Name { get { return _name; } }

    public Author(int i, string n)
    {
      _id = i;
      _name = n;
    }
  }
}
