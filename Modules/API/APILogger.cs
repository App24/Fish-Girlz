using Fish_Girlz.Systems;

namespace Fish_Girlz.API{
    public static class APILogger {
        public static void Log(APIPlugin plugin, object message, Logger.LogLevel logLevel=Logger.LogLevel.Info){
            Logger.Log($"[{plugin.Name}] {message}", logLevel);
        }
    }
}