using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCliM.Utils.Constants {
   public enum ConnectionType {
      VALID = 0,
      WRONG_CREDENTIALS = 1,
      NO_CONNECTION = 2,
      LOGIN_BLOCKED = 3
   }
}
