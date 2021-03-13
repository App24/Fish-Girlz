using System;
using System.IO;

namespace Fish_Girlz.Systems{
    public static class Logger {
        const string LOG_NAME="log_{0}.txt";

        const string LOG_FOLDER="logs";

        private static bool initiliased=false;

        static FileStream ostrm;
        static StreamWriter writer;
        static TextWriter oldOut;

        public enum LogLevel{
            Debug,
            Info,
            Warn,
            Error
        }

        public static void InitLogger(){
            if(initiliased) return;
            if(!Directory.Exists(LOG_FOLDER)){
                Directory.CreateDirectory(LOG_FOLDER);
            }
            string logName=string.Format(LOG_NAME, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            oldOut = Console.Out;
            try{
                ostrm=new FileStream(Path.Combine(LOG_FOLDER, logName), FileMode.OpenOrCreate, FileAccess.Write);
                writer=new StreamWriter(ostrm);
                writer.AutoFlush=true;
            }catch(Exception e){
                Console.WriteLine ($"Cannot open {logName} for writing");
                Console.WriteLine (e.Message);
                return;
            }
            Log("Logger Initialised!");
            initiliased=true;
        }

        public static void Log(object message, LogLevel logLevel=LogLevel.Info){
            #if !DEBUG
                if(logLevel==LogLevel.Debug) return;
            #endif
            string prefix=$"[{logLevel.ToString()}: {DateTime.Now.ToString("HH:mm:ss")}] ";
            string _message=$"{prefix}{message}";
            try{writer.Flush();}catch{return;}
            Console.SetOut (writer);
            Console.WriteLine(_message);
            Console.SetOut (oldOut);
            Console.WriteLine(_message);
        }

        public static void DisposeLogger(){
            if(!initiliased) return;
            Log("Logger Disposed!", LogLevel.Info);
            writer.Close();
            ostrm.Close();
            initiliased=false;
        }
    }
}