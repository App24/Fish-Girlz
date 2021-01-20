using System;
using System.IO;
using Fish_Girlz.Utils;
using System.Runtime.CompilerServices;

namespace Fish_Girlz.Systems{
    public static class Logger {
        private const string LOG_FOLDER="logs";
        private const string LOG_NAME="log_{0}.txt";

        private static string logFolder;

        public static bool Debug{get;set;}

        static FileStream ostrm;
        static StreamWriter writer;
        static TextWriter oldOut;

        static bool initialised=false;

        public enum LogLevel{
            Debug,
            Info,
            Warn,
            Error
        }

        public static void InitLogger(){
            if(initialised)
                return;
            logFolder=Path.Combine(Utilities.ExecutingFolder, LOG_FOLDER);
            if(!Directory.Exists(logFolder)){
                Directory.CreateDirectory(logFolder);
            }
            string logName=string.Format(LOG_NAME, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            oldOut = Console.Out;
            try{
                ostrm=new FileStream(Path.Combine(logFolder, logName), FileMode.OpenOrCreate, FileAccess.Write);
                writer=new StreamWriter(ostrm);
                writer.AutoFlush=true;
            }catch(Exception e){
                Console.WriteLine ($"Cannot open {logName} for writing");
                Console.WriteLine (e.Message);
                return;
            }
            Log("Logger Initialised!", LogLevel.Info);
            initialised=true;
        }
        
        public static string Log(object message, LogLevel logLevel=LogLevel.Info){
            if(logLevel==LogLevel.Debug&&!Debug) return "";
            string prefix=$"[{logLevel.ToString()}: {DateTime.Now.ToString("HH:mm:ss")}] ";
            string _message=$"{prefix}{message}";
            Log(_message);
            return _message;
        }

        static void Log(string message){
            Console.SetOut (writer);
            Console.WriteLine(message);
            Console.SetOut (oldOut);
            Console.WriteLine(message);
        }

        public static void CleanUp(){
            Logger.Log("Logger Disposed!", LogLevel.Info);
            Console.SetOut (oldOut);
            writer.Close();
            ostrm.Close();
            initialised=false;
        }
    }
}