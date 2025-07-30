using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsFormsApp_.NET_Framework_
{
    //public class AudioPlaybackEngine : IDisposable
    //{
    //    private readonly IWavePlayer outputDevice;
    //    private readonly MixingSampleProvider mixer;
    //
    //    public AudioPlaybackEngine(int sampleRate = 44100, int channelCount = 2)
    //    {
    //        outputDevice = new WaveOutEvent() { Volume = 1 };
    //        mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
    //        mixer.ReadFully = true;
    //        outputDevice.Init(mixer);
    //        outputDevice.Play();
    //    }
    //
    //    public void PlaySound(Mp3FileReader file)
    //    {
    //        AddMixerInput(file.ToSampleProvider());
    //    }
    //
    //    private ISampleProvider ConvertToRightChannelCount(ISampleProvider input)
    //    {
    //        if (input.WaveFormat.Channels == mixer.WaveFormat.Channels)
    //        {
    //            return input;
    //        }
    //        if (input.WaveFormat.Channels == 1 && mixer.WaveFormat.Channels == 2)
    //        {
    //            return new MonoToStereoSampleProvider(input);
    //        }
    //        throw new NotImplementedException("Not yet implemented this channel count conversion");
    //    }
    //
    //    private void AddMixerInput(ISampleProvider input)
    //    {
    //        mixer.AddMixerInput(ConvertToRightChannelCount(input));
    //    }
    //
    //    public void Dispose()
    //    {
    //        outputDevice.Dispose();
    //    }
    //
    //    public static readonly AudioPlaybackEngine Instance = new AudioPlaybackEngine(44100, 2);
    //}
}
