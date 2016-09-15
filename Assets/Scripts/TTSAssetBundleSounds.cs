using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TTSAssetBundleSounds : MonoBehaviour {

    [Serializable]
    public class TTSTriggerSounds
    {
        public List<AudioClip> Pickup;
        public List<AudioClip> Drop;
        public List<AudioClip> Shake;
    }

    [Serializable]
    public class TTSImpactSounds
    {
        public List<AudioClip> Generic;
        public List<AudioClip> Wood;
        public List<AudioClip> Metal;
        public List<AudioClip> Plastic;
        public List<AudioClip> CardBoard;
        public List<AudioClip> Glass;
        public List<AudioClip> Felt;
    }

    [Tooltip("Trigger sounds are the sounds that occur when the specified action happens.")]
    public TTSTriggerSounds TriggerSounds;

    [Tooltip("Impact sounds are the sounds that occur when objects collide. If you don't want to have to provide unique sounds for each material type just supply the generic impact sound.")]
    public TTSImpactSounds ImpactSounds;
}
