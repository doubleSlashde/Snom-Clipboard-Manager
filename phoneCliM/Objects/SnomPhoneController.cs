namespace PhoneCliM.Objects
{
   using System;
   using System.IO;
   using System.Net;
   using System.Net.NetworkInformation;

   using dsDotNetUtils.Constants.Messages;

   using NLog;

   using PhoneCliM.Objects.Configuration;
   using PhoneCliM.Resources;
   using PhoneCliM.Utils;
   using PhoneCliM.Utils.Constants;

   /// <summary>
   /// Class to controll the SNOM telephone
   /// </summary>
   internal class SnomPhoneController
   {
      private const string CALL_COMMAND = "number";

      private const string COMMAND_TO_CHECK_ACCESS = "key=CANCEL";

      private const string HTTP_SNOM_CALL_COMMAND = "{0}command.htm?{1}={2}&outgoing_uri={3}";

      private const string HTTP_SNOM_COMMAND = "{0}command.htm?{1}={2}";

      private const string ZERO = "0";

      private static readonly Logger ClassLogger = LogManager.GetCurrentClassLogger();

      private static SnomPhoneController _instance;

      private SnomPhoneController()
      {
      }

      public static SnomPhoneController Instance => _instance ?? (_instance = new SnomPhoneController());

      public void CallCurrentNumber()
      {
         string number = string.Empty;
         if (NumberController.Instance.CurrentNumber.Type == NumberStringType.EXTERNAL)
         {
            number = ZERO;
         }

         number += NumberController.Instance.CurrentNumber;

         string httpCallCommand = string.Format(
            HTTP_SNOM_CALL_COMMAND,
            Credentials.Instance.PhoneUri.ToString(),
            CALL_COMMAND,
            number,
            Credentials.Instance.OwnNumber);

         HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpCallCommand);

         request.Credentials = new NetworkCredential(Credentials.Instance.User, Credentials.Instance.Password);

         try
         {
            request.GetResponse();
         }
         catch (Exception e)
         {
            if (((WebException)e).Status == WebExceptionStatus.ConnectionClosed)
            {
               // Do nothing because it's normal for the Snom telephone to not answer on this request.
            }
            else if (e.Message.Contains("401"))
            {
               Ping p = new Ping();
               PingReply reply = p.Send(Credentials.Instance.PhoneUri.Host);
               if (reply.Status != IPStatus.Success)
               {
                  MessageHelper.MessageBoxService.ShowOnTop(
                     MessageType.Error,
                     MessageHelper.WrongSettingsMessage(true, true, true, true, ConnectionType.WRONG_CREDENTIALS));
                  ClassLogger.Info(LogMessages.WrongCredentials, e.ToString());
               }
            }
            else
            {
               MessageHelper.MessageBoxService.ShowOnTop(
                  MessageType.Error,
                  MessageHelper.WrongSettingsMessage(true, true, true, true, ConnectionType.NO_CONNECTION));
               ClassLogger.Info(LogMessages.NoConnection, e.ToString());
            }
         }
      }

      public ConnectionType CheckConnection(Uri phoneUri, string user, string password)
      {
         ConnectionType result = ConnectionType.VALID;
         HttpWebResponse response = null;

         Ping p = new Ping();
         PingReply reply = p.Send(phoneUri.Host);

         if (reply.Status == IPStatus.Success)
         {
            string httpCallCommand = string.Format(
               HTTP_SNOM_COMMAND,
               phoneUri.ToString(),
               COMMAND_TO_CHECK_ACCESS,
               Constant.EMPTY);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpCallCommand);
            request.Credentials = new NetworkCredential(user, password);
            try
            {
               response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception e)
            {
               if (e.Message.Contains("401"))
               {
                  Console.WriteLine(e.Message);
                  result = ConnectionType.WRONG_CREDENTIALS;
                  ClassLogger.Info(LogMessages.WrongCredentials, e.ToString());
               }
               else
               {
                  result = ConnectionType.NO_CONNECTION;
                  ClassLogger.Info(LogMessages.NoConnection, e.ToString());
               }
            }

            if (response != null)
            {
               string respsoneText = new StreamReader(response.GetResponseStream()).ReadToEnd();
               if (respsoneText.Contains("blocked"))
               {
                  result = ConnectionType.LOGIN_BLOCKED;
                  ClassLogger.Info(LogMessages.LoginBlocked);
               }
            }
         }
         else
         {
            result = ConnectionType.NO_CONNECTION;
            ClassLogger.Info(LogMessages.PingImpossible);
         }

         return result;
      }
   }
}