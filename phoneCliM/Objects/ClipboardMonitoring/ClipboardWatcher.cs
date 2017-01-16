using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace PhoneCliM.Objects.ClipboardMonitoring {

   /// <summary>
   /// This class is from http://stackoverflow.com/questions/6458030/clipboard-change-notification
   /// It has to inherit Form because of the clipboard-functionality being part of windows forms.
   /// </summary>
   public class ClipboardWatcher : Form {
      // static instance of this form
      private static ClipboardWatcher mInstance;

      // needed to dispose this form
      static IntPtr nextClipboardViewer;

      public delegate void OnClipboardChangeEventHandler(ClipboardFormat format, object data);
      public static event OnClipboardChangeEventHandler OnClipboardChange;

      // start listening
      public static void Start() {
         // we can only have one instance if this class
         if (mInstance != null)
            return;

         Thread t = new Thread(new ParameterizedThreadStart(x => {
            Application.Run(new ClipboardWatcher());
         }));
         t.SetApartmentState(ApartmentState.STA); // give the [STAThread] attribute
         t.Start();
      }

      // stop listening (dispose form)
      public static void Stop() {
         mInstance.Invoke(new MethodInvoker(() => {
            ChangeClipboardChain(mInstance.Handle, nextClipboardViewer);
         }));
         mInstance.Invoke(new MethodInvoker(mInstance.Close));

         mInstance.Dispose();

         mInstance = null;
      }

      // on load: (hide this window)
      protected override void SetVisibleCore(bool value) {
         CreateHandle();

         mInstance = this;

         nextClipboardViewer = SetClipboardViewer(mInstance.Handle);

         base.SetVisibleCore(false);
      }

      [DllImport("User32.dll", CharSet = CharSet.Auto)]
      public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

      [DllImport("User32.dll", CharSet = CharSet.Auto)]
      public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

      // defined in winuser.h
      const int WM_DRAWCLIPBOARD = 0x308;
      const int WM_CHANGECBCHAIN = 0x030D;

      protected override void WndProc(ref Message m) {
         switch (m.Msg) {
         case WM_DRAWCLIPBOARD:
            ClipChanged();
            SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
            break;

         case WM_CHANGECBCHAIN:
            if (m.WParam == nextClipboardViewer)
               nextClipboardViewer = m.LParam;
            else
               SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
            break;

         default:
            base.WndProc(ref m);
            break;
         }
         //Clipboard.Clear(); // Bugfix to stop randomly appearing balllon tipps
      }

      static readonly String[] formats = Enum.GetNames(typeof(ClipboardFormat));

      private void ClipChanged() {
         IDataObject iData = Clipboard.GetDataObject();

         ClipboardFormat? format = null;

         foreach (string f in formats) {
            if (iData.GetDataPresent(f)) {
               format = (ClipboardFormat) Enum.Parse(typeof(ClipboardFormat), f);
               break;
            }
         }

         object data = iData.GetData(format.ToString());

         if (data == null || format == null)
            return;

         if (OnClipboardChange != null)
            OnClipboardChange((ClipboardFormat) format, data);
      }
   }
}
