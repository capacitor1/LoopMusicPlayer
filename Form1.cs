using NAudio.Wave;
using NAudio.Extras;
using NAudio.Wave.SampleProviders;
using System.Text.RegularExpressions;
using System.Timers;
namespace LoopMusicPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public WaveOutEvent Intro,Loop;
        public VolumeSampleProvider IvolumeProvider,LvolumeProvider;
        public AudioFileReader Intro1,Loop1;
        public System.Timers.Timer t;

        private async void Play_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(I.Text) || !File.Exists(L.Text))
                {
                    Indicator.Text = "空闲...";
                    return;
                }
                Indicator.Text = "准备播放...";
                Application.DoEvents();
                if (Intro != null) Intro.Dispose();
                if (Loop != null) Loop.Dispose();
                if (t != null) t.Dispose();
                Time.Text = Len.Text = "0";
                Indicator.Text = "正在读取音频文件...";
                Application.DoEvents();
                Intro1 = new AudioFileReader(I.Text);
                Loop1 = new AudioFileReader(L.Text);
                Indicator.Text = "初始化播放器...";
                Application.DoEvents();
                var Loop2 = new LoopStream(Loop1);
                IvolumeProvider = new VolumeSampleProvider(Intro1.ToSampleProvider());
                LvolumeProvider = new VolumeSampleProvider(Loop2.ToSampleProvider());
                Intro = new WaveOutEvent();
                Loop = new WaveOutEvent();
                Intro.Init(IvolumeProvider);
                Loop.Init(LvolumeProvider);
                long Introlen = Intro1.Length;
                IvolumeProvider.Volume = LvolumeProvider.Volume = (float)(Vol.Value / 10);
                Indicator.Text = "正在播放...";
                Application.DoEvents();
                Len.Text = Introlen.ToString("N0");
                Playing.Text = "正在播放：Intro";
                Intro.Play(); // 异步执行
                await Task.Run(() =>
                {
                    t = new System.Timers.Timer(500);
                    t.Elapsed += new ElapsedEventHandler(OnTimerElapsed);//到达时间的时候执行事件
                    t.AutoReset = true; //设置是执行一次（false）还是一直执行(true)
                    t.Enabled = true; //是否执行System.Timers.Timer.Elapsed事件
                    t.Start();
                });
                while (Intro.PlaybackState == PlaybackState.Playing)
                {
                    Application.DoEvents();
                    if (Intro1.Position == Introlen)
                    {
                        Loop.Play(); // 异步执行
                    }
                }
                Len.Text = Loop1.Length.ToString("N0");
                Playing.Text = "正在播放：Loop";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (Intro.PlaybackState == PlaybackState.Playing)
            {
                Time.Text = Intro1.Position.ToString("N0");
                Application.DoEvents();
            }
            else if (Intro.PlaybackState != PlaybackState.Playing && Loop.PlaybackState == PlaybackState.Playing)
            {
                Time.Text = Loop1.Position.ToString("N0");
                Application.DoEvents();
            }
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            if (Intro != null) Intro.Stop();
            if (Loop != null) Loop.Stop();
            if (t != null) t.Dispose();
            Playing.Text = "正在播放：None";
            Indicator.Text = "空闲";
            Time.Text = Len.Text = "0";
            Application.DoEvents();
        }

        private void Vol_ValueChanged(object sender, EventArgs e)
        {
            if (IvolumeProvider != null && LvolumeProvider != null)
                IvolumeProvider.Volume = LvolumeProvider.Volume = (float)(Vol.Value / 10);
        }
        public string OpenFile(string title)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = title;
            dialog.Filter = "音频(*.mp3;*.wav;*.ogg;*.m4a;*.aac;*.flac)|*.mp3;*.wav;*.ogg;*.m4a;*.aac;*.flac";
            return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ? dialog.FileName : String.Empty;
        }
        private void SI_Click(object sender, EventArgs e)
        {
            I.Text = OpenFile("请选择Intro");
            string f = Regex.Replace(I.Text, "intro", "loop", RegexOptions.IgnoreCase);
            L.Text = File.Exists(f) ? f : String.Empty;
        }

        private void SL_Click(object sender, EventArgs e)
        {
            L.Text = OpenFile("请选择Loop");
        }
    }
}
