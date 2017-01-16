namespace PhoneCliM.Objects.ClipboardMonitoring {

   /// <summary>
   /// This class is from http://stackoverflow.com/questions/6458030/clipboard-change-notification
   /// </summary>
   public static class ClipboardMonitor {
      public delegate void OnClipboardChangeEventHandler(ClipboardFormat format, object data);
      public static event OnClipboardChangeEventHandler OnClipboardChange;

      public static void Start() {
         ClipboardWatcher.Start();
         ClipboardWatcher.OnClipboardChange += (ClipboardFormat format, object data) => {
            if (OnClipboardChange != null)
               OnClipboardChange(format, data);
         };
      }

      public static void Stop() {
         OnClipboardChange = null;
         ClipboardWatcher.Stop();
      }
   }
}
