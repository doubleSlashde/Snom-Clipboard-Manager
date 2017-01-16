using System;
using System.Threading;
using NLog;
using PhoneCliM.Objects.ClipboardMonitoring;
using PhoneCliM.Utils;
using PhoneCliM.Utils.Constants;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PhoneCliM.Objects {

   /// <summary>
   /// Managing the processes which contain the phonenumbers.
   /// Containing the current number.
   /// </summary>
   public class NumberController : Form {

      #region Members

      static NumberController _instance;

      private static readonly Logger ClassLogger = LogManager.GetCurrentClassLogger();

      private string _currentClipboardContent;
      private Number _currentNumber;
      private Number _tmpNumber;
      public event EventHandler<EventArgs> CurrentNumberChanged;

      #endregion

      #region Properties

      /// <summary>
      /// Returning the instance of the NumberController. Creating a new one, if none exists yet.
      /// </summary>
      public static NumberController Instance => _instance ?? (_instance = new NumberController());

      public Number CurrentNumber
      {
         get
         {
            return _currentNumber;
         }
         private set
         {
            _currentNumber = value;
            OnCurrentNumberChanged(new EventArgs());
         }
      }

      #endregion

      #region Constructors/Destructors

      public NumberController() {

         //Add Listener to ClipboardMonitor
         ClipboardMonitor.OnClipboardChange += ClipboardMonitor_OnClipboardChange;

      }

      #endregion

      #region Eventhandlers

      private void ClipboardMonitor_OnClipboardChange(ClipboardFormat format, object data) {
         _currentClipboardContent = data.ToString();

         //Process the changed clipboard content in a new thread to prevent new windows signals captured in the ClipboardWatcherfrom interrupting the processing
         Thread processclipboardContentThread = new Thread(ProcessClipboardContent);
         processclipboardContentThread.SetApartmentState(ApartmentState.STA); // give the [STAThread] attribute
         processclipboardContentThread.Start();
      }

      #endregion

      #region Public Methods

      /// <summary>
      /// Initializing the controller before it is used first to add the clipboard listener in the constructor.
      /// </summary>
      public static void Initialize() {
         _instance = new NumberController();
      }

      #endregion

      #region Internal Methods

      #endregion

      #region Protected Methods

      #endregion

      #region Private Methods

      private void OnCurrentNumberChanged(EventArgs e) {
         CurrentNumberChanged?.Invoke(this, e);
      }

      /// <summary>
      /// Checks if the content of the clipboard can be used as a number and sets the current number if so.
      /// </summary>
      private void ProcessClipboardContent() {
         NumberStringType type = NumberStringUtils.IsValidPhoneNumber(_currentClipboardContent);
         switch (type) {
         case NumberStringType.NOT_POSSIBLE:
            // Do nothing because the clipboard does not contain a number
            break;
         case NumberStringType.NOT_VALID:
            // Do nothing because the content of the clipboard is not a valid number
            // Here the option could be implementet, to inform the user about the fact he has copied a possible but not valid number.
            // It could be a valid number in another country. This could be checked.
            break;
         default:
            CurrentNumber = new Number(NumberStringUtils.FormatNumberString(_currentClipboardContent), type);
            Clipboard.Clear(); // Bugfix to stop randomly appearing balllon tipps if you copy a valid external/internal number
            break;
         }
      }

      #endregion

   }
}
