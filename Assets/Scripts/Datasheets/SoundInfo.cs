﻿using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundInfo
{
    public static List<SoundInfo> sheet = Datasheet.Load<SoundInfo>("data/global/excel/Sounds.txt");
    static Dictionary<string, SoundInfo> map = new Dictionary<string, SoundInfo>();

    public static SoundInfo itemPickup;
    public static SoundInfo itemFlippy;

    public static SoundInfo Find(string soundCode)
    {
        if (soundCode == null)
            return null;

        return map.GetValueOrDefault(soundCode);
    }

    static SoundInfo()
    {
        foreach(var sound in sheet)
        {
            if (sound.sound == null)
                continue;

            sound.volume = sound._volume / 255f;
            map.Add(sound.sound, sound);
        }

        itemPickup = Find("item_pickup");
        itemFlippy = Find("item_flippy");
    }

    public AudioClip clip
    {
        get {
            if (audioClip != null)
                return audioClip;

            var filename = @"data\global\sfx\" + _filename;
            var file = Mpq.fs.FindFile(filename);
            if (file == null)
                return null;

            var bytes = Mpq.ReadAllBytes(file);
            audioClip = Wav.Load(sound, bytes);
            return audioClip;
        }
    }
    
    public string sound;
    public int index;
    public string _filename;
    public int _volume;
    public int groupSize;
    public bool loop;
    public int fadeIn;
    public int fadeOut;
    public bool deferInst;
    public bool stopInst;
    public int duration;
    public int compound;
    public int reverb;
    public int falloff;
    public bool cache;
    public bool asyncOnly;
    public int priority;
    public int stream;
    public int stereo;
    public int tracking;
    public int solo;
    public int musicVol;
    public int block1;
    public int block2;
    public int block3;

    [System.NonSerialized]
    AudioClip audioClip;

    [System.NonSerialized]
    public float volume;
}
