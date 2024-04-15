using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.GameMechanics
{
    public static class Tracer
    {
        private static TraceSource source = new TraceSource("tracefile.xml");

        /// <summary>
        /// åbner en forbindelse til tracefile og gør at man kan skrive til xml filen
        /// </summary>
        public static void Open()
        {
            source.Switch = new SourceSwitch("tracefile", "all");
            TraceListener Listener = new XmlWriterTraceListener(
            new StreamWriter("tracefile.xml") { AutoFlush = true });
            source.Listeners.Add(Listener);
        }

        /// <summary>
        /// lukker forbindelsen til xmlfilen tracefile.xml
        /// </summary>
        public static void Close()
        {
            source.Close();
        }

        /// <summary>
        /// skriver information i en string til tracefile.xml
        /// </summary>
        /// <param name="info"> den information som skrives til tracefile.xml</param>
        public static void traceinfo(string info)
        {
            source.TraceInformation(info);
        }



        /// <summary>
        /// bruges til at skrive til xmlfilen hvis der opstår en fjel
        /// </summary>
        /// <param name="error">den fejlbesked som traceerror får </param>
        /// <param name="id">det id fejlen får</param>
        public static void traceError(int id,string error=null)
        {
            if(error!=null)
                source.TraceEvent(TraceEventType.Error,id);
            source.TraceEvent(TraceEventType.Error, id, error);
        }
    }
}
