using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyDocumanager
{
  class DocumentComparer : IEqualityComparer<Document>
  {
    public bool Equals(Document x, Document y)
    {
      bool isEqual = x.Equals(y);

      return isEqual;
    }

    public int GetHashCode(Document obj)
    {
      return obj.GenerateHashCode();
    }
  }
}
