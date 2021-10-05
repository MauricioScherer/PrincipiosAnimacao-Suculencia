using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer_Drums : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _sample = new float[512];
    public static float[] _freqBand = new float[8];

    //44100Hz / 512 = 86Hz
    //0 -> 2 = 172 Hz
    //1 -> 4 = 344 Hz
    //2 -> 8 = 688 Hz
    //3 -> 16 = 1376 Hz
    //4 -> 32 = 2752 Hz
    //5 -> 64 = 5504 Hz
    //6 -> 128 = 11008 Hz
    //7 -> 256 = 22016 Hz

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrimAudioSource();
        MakeFrequencyBands();
    }

    void GetSpectrimAudioSource()
    {
        _audioSource.GetSpectrumData(_sample, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _sample[count] * (count + 1);
                count++;
            }

            average /= count;
            _freqBand[i] = average * 10;
        }
    }
}
