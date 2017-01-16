using System;
using System.Text.RegularExpressions;
using NLog;
using PhoneCliM.Objects.Configuration;
using PhoneCliM.Resources;
using PhoneCliM.Utils.Constants;
using PhoneNumbers;

namespace PhoneCliM.Utils {

   /// <summary>
   /// Utils class containing methods to manage NumberStrings
   /// </summary>
   public static class NumberStringUtils {

      #region Members

      private static readonly Logger ClassLogger = LogManager.GetCurrentClassLogger();

      /// <summary>
      /// Regex to filter out possible Syntax for a phonenumber
      /// Allows the number to start with "+" or "00" and the countrycode which can also be writen in brackets.
      /// It can also start with "0"
      /// After the start a number not zero must follow
      /// the following symbols are allowed inside the rest of the number and will be filtered out later: "/","-"," ","(",")"
      /// </summary>
      static readonly private Regex PHONE_NUMBER_EX = new Regex("(\\(?(\\+|00)[1-9]\\d{0,3}\\)?|0 ?[1-9]|\\(00? ?[1-9][\\d ]*\\))[\\(\\)\\d\\-\\/ ]*");

      /// <summary>
      /// Regex to filter out possible internal numbers
      /// Number must start with "1" or "2" and has three digits
      /// A "-" can be in front of the number.
      /// </summary>
      static readonly private Regex INTERNAL_NUMBER_EX = new Regex("\\-?[1-2]\\d{2}");

      static readonly private String[] CHARS_TO_REMOVE= {"/","-"," ","(",")"};
      private const string PLUS = "+";
      private const string DOUBLE_ZERO ="00";

      #endregion

      #region Properties

      #endregion

      #region Constructors/Destructors

      #endregion

      #region Eventhandlers

      #endregion

      #region Public Methods

      /// <summary>
      /// Checks if the input is an internal number.
      /// If not calls a check if input is an external number.
      /// </summary>
      /// <param name="input"></param>
      /// <returns>Information about the type of number the input is</returns>
      public static NumberStringType IsValidPhoneNumber(string input) {
         NumberStringType result = NumberStringType.NOT_POSSIBLE;

         if (!string.IsNullOrEmpty(input)) {
            result = INTERNAL_NUMBER_EX.Match(input).ToString() == input ? NumberStringType.INTERNAL : IsValidExternalNumber(input);
         }

         return result;

      }

      public static string FormatNumberString(string number) {
         string result;
         result = number.Replace(PLUS, DOUBLE_ZERO);
         foreach (string charToRemove in CHARS_TO_REMOVE) {
            result = result.Replace(charToRemove, Constant.EMPTY);
         }

         //Remove countrycode when in this country
         if (result.StartsWith(DOUBLE_ZERO + PhoneNumberUtil.GetInstance().GetCountryCodeForRegion(Config.Instance.DefaultRegion).ToString())) {
            result = result.Remove(1, 3);
         }
         return result;
      }



      #endregion

      #region Internal Methods

      #endregion

      #region Protected Methods

      #endregion

      #region Private Methods

      /// <summary>
      /// Checks if the input is an external number.
      /// </summary>
      /// <param name="input"></param>
      /// <returns>Information about the type of number the input is</returns>
      private static NumberStringType IsValidExternalNumber(string input) {

         PhoneNumberUtil util = PhoneNumberUtil.GetInstance();
         NumberStringType result = NumberStringType.NOT_POSSIBLE;

         if (PHONE_NUMBER_EX.Match(input).ToString() == input) {
            string numberString = FormatNumberString(input);
            try {
               PhoneNumber numberProto = util.Parse(numberString, Config.Instance.DefaultRegion);
               if (util.IsPossibleNumber(numberProto)) {
                  if (util.IsValidNumber(numberProto)) {
                     result = NumberStringType.EXTERNAL;
                  } else {
                     result = NumberStringType.NOT_VALID;
                  }
               }
            } catch (Exception e) {
               ClassLogger.Error(LogMessages.ErrorPhoneNumberValid, e.ToString());
               result = NumberStringType.NOT_POSSIBLE;
            }
         }

         return result;
      }

      #endregion

   }
}
