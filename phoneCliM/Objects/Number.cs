using System;
using PhoneCliM.Utils.Constants;

namespace PhoneCliM.Objects {

   /// <summary>
   /// Class containing the properties of a number
   /// </summary>
   public class Number {

      #region Members

      #endregion

      #region Properties

      public string NumberString
      {
         get; private set;
      }

      public NumberStringType Type
      {
         get; private set;
      }

      #endregion

      #region Constructors/Destructors

      public Number(string numberString, NumberStringType type) {
         NumberString = numberString;
         Type = type;
      }

      #endregion

      #region Eventhandlers

      #endregion

      #region Public Methods

      public override string ToString() {
         return NumberString;
      }

      #endregion

      #region Internal Methods

      #endregion

      #region Protected Methods

      #endregion

      #region Private Methods

      #endregion

   }
}
