using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WindowsDeclarationService
{
  class EventLogger
  {
    private static EventLog EL;
    static EventLogger()
    {
      if (!EventLog.SourceExists("ITS Declaration Service"))
        EventLog.CreateEventSource("ITS Declaration Service", "Application");

      EL = new EventLog();
      EL.Source = "ITS Declaration Service";
      EL.Log = "Application";
    }

    public static void AddEvent(string Message)
    {
      //Log a information to the eventLog
      EL.WriteEntry(Message, EventLogEntryType.Information);
    }

    public static void AddException(string Message)
    {
      //Log a exception to the eventLog
      EL.WriteEntry(Message, EventLogEntryType.Error);
    }
    public static void AddWarning(string Message)
    {
      //Log a warning to the eventLog
      EL.WriteEntry(Message, EventLogEntryType.Warning);
    }
  }
}
