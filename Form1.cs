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
                    Indicator.Text = "����...";
                    return;
                }
                Indicator.Text = "׼������...";
                Application.DoEvents();
                if (Intro != null) Intro.Dispose();
                if (Loop != null) Loop.Dispose();
                if (t != null) t.Dispose();
                Time.Text = Len.Text = "0";
                Indicator.Text = "���ڶ�ȡ��Ƶ�ļ�...";
                Application.DoEvents();
                Intro1 = new AudioFileReader(I.Text);
                Loop1 = new AudioFileReader(L.Text);
                Indicator.Text = "��ʼ��������...";
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
                Indicator.Text = "���ڲ���...";
                Application.DoEvents();
                Len.Text = Introlen.ToString("N0");
                Playing.Text = "���ڲ��ţ�Intro";
                Intro.Play(); // �첽ִ��
                await Task.Run(() =>
                {
                    t = new System.Timers.Timer(500);
                    t.Elapsed += new ElapsedEventHandler(OnTimerElapsed);//����ʱ���ʱ��ִ���¼�
                    t.AutoReset = true; //������ִ��һ�Σ�false������һֱִ��(true)
                    t.Enabled = true; //�Ƿ�ִ��System.Timers.Timer.Elapsed�¼�
                    t.Start();
                });
                while (Intro.PlaybackState == PlaybackState.Playing)
                {
                    Application.DoEvents();
                    if (Intro1.Position == Introlen)
                    {
                        Loop.Play(); // �첽ִ��
                    }
                }
                Len.Text = Loop1.Length.ToString("N0");
                Playing.Text = "���ڲ��ţ�Loop";
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
            Playing.Text = "���ڲ��ţ�None";
            Indicator.Text = "����";
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
            dialog.Multiselect = false;//��ֵȷ���Ƿ����ѡ�����ļ�
            dialog.Title = title;
            dialog.Filter = "��Ƶ(*.mp3;*.wav;*.ogg;*.m4a;*.aac;*.flac)|*.mp3;*.wav;*.ogg;*.m4a;*.aac;*.flac";
            return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ? dialog.FileName : String.Empty;
        }
        private void SI_Click(object sender, EventArgs e)
        {
            I.Text = OpenFile("��ѡ��Intro");
            string f = Regex.Replace(I.Text, "intro", "loop", RegexOptions.IgnoreCase);
            L.Text = File.Exists(f) ? f : String.Empty;
        }

        private void SL_Click(object sender, EventArgs e)
        {
            L.Text = OpenFile("��ѡ��Loop");
        }
    }
}
