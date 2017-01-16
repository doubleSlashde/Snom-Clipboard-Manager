namespace PhoneCliM.Utils
{
   using dsDotNetUtils.Utils.Message;

   using libphonenumber;

   using PhoneCliM.Objects;
   using PhoneCliM.Objects.Configuration;
   using PhoneCliM.Resources;
   using PhoneCliM.Utils.Constants;

   /// <summary>
   /// Helper class giving back the correct text for a messagebox or label in the current situation
   /// </summary>
   public static class MessageHelper
   {
      private static MessageBoxService _messageboxService;

      /// <summary>
      /// Message shown in the MessageBox to call a number
      /// </summary>
      public static string AskIfCallMessage
      {
         get
         {
            Number currentNumber = NumberController.Instance.CurrentNumber;
            return string.Format(MessageBoxMessages.AskIfCall, currentNumber);
         }
      }

      /// <summary>
      /// Text used in the label to call a number
      /// </summary>
      public static string CallCurrentNumberText
      {
         get
         {
            Number currentNumber = NumberController.Instance.CurrentNumber;
            string message = Constant.EMPTY;

            if (currentNumber != null)
            {
               if (currentNumber.Type == NumberStringType.EXTERNAL)
               {
                  message = string.Format(
                     UILabels.CallCurrentNumber,
                     NumberController.Instance.CurrentNumber + Constant.SPACE + GetLocation(currentNumber.NumberString));
               }
               else if (currentNumber.Type == NumberStringType.INTERNAL)
               {
                  message = string.Format(UILabels.CallCurrentNumber, NumberController.Instance.CurrentNumber);
               }
            }

            return message;
         }
      }

      public static MessageBoxService MessageBoxService
         => _messageboxService ?? (_messageboxService = new MessageBoxService());

      /// <summary>
      /// Message shown in the BalloonTip after changes in the clipboard
      /// </summary>
      public static string NumberToClipboardMessage
      {
         get
         {
            Number currentNumber = NumberController.Instance.CurrentNumber;
            string result = string.Empty;
            if (currentNumber.Type == NumberStringType.EXTERNAL)
            {
               result = string.Format(
                  UILabels.ExternalNumberToClipboard,
                  currentNumber,
                  GetLocation(currentNumber.NumberString));
            }
            else if (currentNumber.Type == NumberStringType.INTERNAL)
            {
               result = string.Format(UILabels.InternalNumberToClipboard, currentNumber);
            }

            return result;
         }
      }

      /// <summary>
      /// Message shown in the MessageBox after user tried to safe wrong settings
      /// </summary>
      public static string WrongSettingsMessage(
         bool ipAddressValid,
         bool userValid,
         bool passwordValid, bool ownnumberValid,
         ConnectionType connectionValid)
      {
         string result = MessageBoxMessages.WrongIpAddress;

         if (connectionValid == ConnectionType.WRONG_CREDENTIALS)
         {
            result = MessageBoxMessages.WrongCredentials;
         }

         if (ipAddressValid)
         {
            if (passwordValid && !userValid)
            {
               result = MessageBoxMessages.NoName;
            }
         }
         else
         {
            result = MessageBoxMessages.NotAnIpAddress;
         }

         if (connectionValid == ConnectionType.LOGIN_BLOCKED)
         {
            result = MessageBoxMessages.LoginBlocked;
         }

         if (!ownnumberValid) {
            result = MessageBoxMessages.WrongOwnNumber;
         }

         return result;
      }

      private static string GetLocation(string number)
      {
         PhoneNumber phoneNumber = PhoneNumberUtil.Instance.Parse(number, Config.Instance.DefaultRegion);
         return string.Format(UILabels.Location, phoneNumber.GetDescriptionForNumber(Locale.GERMAN));
      }
   }
}