using SelfImplement_Libraries;
using System;
using System.Reflection;


namespace ExerciseApp
{
    public partial class ExerciseApp : Form 
    {
        private bool stateLocked = false;
        private bool started = false;
        private bool stopped = false;
        private bool firstRun = true;
        private bool counting = false;
        private decimal currentMinute = 0;
        private decimal currentSecond = 0;
        private decimal currentHour = 0;
        private DateTime wakeDateTime;
        private System.Timers.Timer sleepTimer;
        private AppConfiguration currentConfigs;
        private string processName;

        public List<string> vidPath = [""];
        public List<int> corrupted_VidPath_Index = [-1];
        public string processPath = new(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        public int num_videos = 1;
        public bool play_random = false;
        public bool continuePlay = false;
        public int current_video = 0;
        public decimal currentHourConfig = 0;
        public decimal currentMinuteConfig = 0;
        public decimal currentSecondConfig = 0;
        public decimal currentStopHourConfig = 0;
        public decimal currentStopMinuteConfig = 0;
        public decimal currentStopSecondConfig = 0;
        public bool startWithSystem = false;
        public bool useSleepPicker = false;
        public bool sleepState = false;
        public DateTime currentSleepDateTimeConfig;
        public decimal currentSleepHourConfig = 0;
        public decimal currentSleepMinConfig = 0;
        public decimal currentSleepSecConfig = 0;
        public bool multiple_videos = false;
        public Size currentSize;
        public Point centerScreenPos;
        public Rectangle screenResolution;



        // Constants -------------------------------------------------------
        private const string assetPath = @"Asset\";
        private const string defaultVideo = @"Asset\Default\default_video.mp4";
        public const string configPath = "current_config.conf";
        public const string helpMsgPath = @"Asset\help.txt";
        public const string supportedFileType = "*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp4";
        public readonly string[] countState = ["ĐANG DỪNG", "ĐANG CHẠY"];


        public readonly string[] configNames = [
            "video_path",
            "num_videos",
            "play_random",
            "play_all_videos",
            "continue_play_when_end_of_video",
            "start_with_system",
            "current_hour_cfg",
            "current_min_cfg",
            "current_sec_cfg",
            "current_shour_cfg",
            "current_smin_cfg",
            "current_ssec_cfg",
            "use_sleep_picker",
            "current_sleep_datetime",
            "current_sleep_hour_cfg",
            "current_sleep_min_cfg",
            "current_sleep_sec_cfg"
        ];
    }
}