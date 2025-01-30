using GAITask.Debugging;

namespace GAITask
{
    public class GAITaskConsts
    {
        public const string LocalizationSourceName = "GAITask";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "a2044f5f2c4c455382cb97f54fd3e597";
    }
}
