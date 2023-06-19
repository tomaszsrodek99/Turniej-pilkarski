using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models
{
   public class ModelStateError
    {
        public string ErrorMessage { get; set; }

        public ModelStateError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

}
