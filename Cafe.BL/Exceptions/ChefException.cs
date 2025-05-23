using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Exceptions;

public class ChefException:Exception
{
    public ChefException(string message):base(message)
    {
        
    }
}
