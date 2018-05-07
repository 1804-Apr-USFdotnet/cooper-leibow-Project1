using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary.CustomExceptions
{
    class ReviewerNotMatchException :Exception
    {

        ReviewerNotMatchException(string message) :base(message)
        {
            
        }
    }
}
