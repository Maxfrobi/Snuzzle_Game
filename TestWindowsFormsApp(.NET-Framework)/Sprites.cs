using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestWindowsFormsApp_.NET_Framework_.Properties;
using System.Threading;

namespace TestWindowsFormsApp_.NET_Framework_
{
    public static class Data 
    {
        public static bool Initialized = false;
        public static Image HeadImage = Resources.SnuzzleHead1;
        public static Image BodyImage = Resources.SnuzzleBody;
        public static Image FoodImage = Resources.SnuzzleFood;
        public static Image UnMuncherImage = Resources.SnuzzlePush;
        public static Image MuncherImage = Resources.SnuzzleMunch;
        public static Image UnVicImage = Resources.SnuzzleUnVic_3;
        public static Image YesVicImage = Resources.SnuzzleYesVic_3;
        public static Image EmptyImage = Resources.SnuzzleEmpty;
        public static Image WallImage = Resources.SnuzzleWall;
        public static Image TutorialImage = Resources.TutorialSmall;
        public static Image GoalImage = Resources.GoalScreen;
        public static Image WidthImage = Resources.Width;
        public static Image HeightImage = Resources.Height;
        public static Image BuildImage = Resources.Build;
        public static Image ImportImage = Resources.ImportButton;
        public static Image ImportTextImage = Resources.ImportText;
        public static Image ImportExplanation = Resources.ImportExplanation;
        public static Image ExportExplanation = Resources.ExportExplanation;
        public static Image DesignExplanation = Resources.DesignExplanation;
        public static Image EditorExplanation = Resources.BuildLevelExplanation;
        public static Image EditorButtonImage = Resources.EditorButton;
        public static Image BlueButtonImage = Resources.BlueButton;
        public static Image GreenButtonImage = Resources.DefaultButton;
        public static Image GrayButtonImage = Resources.GrayButton;
        public static Image VictoryScreenBackGround = Resources.VictoryBackground;
        public static Image ContinueButtonBackGround = Resources.ContinueButton;
        public static WaveOutEvent SoundPlayer = new WaveOutEvent() { DesiredLatency = 50 };
        public static MixingSampleProvider Mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2)) { ReadFully = true };
        public static Dictionary<SoundType, (Mp3FileReader, VolumeSampleProvider)> PlayingSounds = new Dictionary<SoundType, (Mp3FileReader, VolumeSampleProvider)>();
        public static byte[] ReverseSound = Resources.Wvhiit;
        public static byte[] ButtonClickSound = Resources.Button_Click;
        public static byte[] VictoryTileActivation = Resources.VictoryTileActivation;
        public static byte[] VictorySound = Resources.VictorySound;
        public static byte[][] ShuffleSounds = new byte[][] { Resources.Move1, Resources.Move2, Resources.Move3, Resources.Move4, Resources.Move5};
        public static byte[] WallHitSound = Resources.Wall2;
        public static byte[] BackGroundMusic = Resources.BackGroundMusic1;
        public static void PlaySound(byte[] soundarray, SoundType soundType, float Volume)
        {
            Mp3FileReader sound = new Mp3FileReader(new MemoryStream(soundarray));
            if (PlayingSounds.ContainsKey(soundType))
            {
                if (PlayingSounds[soundType].Item1 != null)
                {
                    Thread StopThread = new Thread(StopSound);
                    StopThread.Start(PlayingSounds[soundType]);
                }
            }
            VolumeSampleProvider soundcontrolled = new VolumeSampleProvider(sound.ToSampleProvider()) { Volume = Volume };
            PlayingSounds[soundType] = (sound, soundcontrolled);
            Mixer.AddMixerInput(soundcontrolled);
            if(!Initialized)
            {
                SoundPlayer.Init(Mixer);
                SoundPlayer.Play();
                Initialized = true;
            }
        }
        
        private static void StopSound(object playerobj)
        {
            (Mp3FileReader, VolumeSampleProvider) players = ((Mp3FileReader, VolumeSampleProvider))playerobj;
            VolumeSampleProvider player = players.Item2;
            Mp3FileReader source = players.Item1;
            while (player.Volume > 0.000001)
            {
                player.Volume /= 1.01f;
                Thread.Sleep(1);
            }
            Mixer.RemoveMixerInput(player);
            source.Dispose();
            player.Volume = 1;
        }
        public static void PlayMoveSound()
        {
            Random r = new Random();
            PlaySound(ShuffleSounds[r.Next(ShuffleSounds.Length)], SoundType.GameSFX, 0.8f);
        }
        public enum SoundType { BGMusic, GameSFX, MenuSFX, Persistent}
    }
}
