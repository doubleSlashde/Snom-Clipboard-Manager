using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCliM.Utils.Constants {
   public enum NumberStringType {
      //clipboard content is syntactical not a number
      NOT_POSSIBLE = 0,
      //clipboard content has the syntax of a phone number but is not valid in the country
      NOT_VALID = 1,
      //clipboard content is an internal number
      INTERNAL = 2,
      //clipboard content is an external number
      EXTERNAL = 3
   }
}
