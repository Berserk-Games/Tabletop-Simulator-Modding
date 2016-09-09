using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TTSAssetbundle : MonoBehaviour
{
    [Serializable]
    public class TTSAnimation
    {
        public AnimationClip Animation;
    }

    [Serializable]
    public class TTSSound
    {
        public AudioClip Audio;
        public bool Positional3D = false;
    }

    [Serializable]
    public class TTSParticle
    {
        public ParticleSystem Particle;
    }

    [Serializable]
    public class TTSEffect
    {
        public string Name;
        public TTSAnimation Animation;
        public TTSSound Sound;
        public TTSParticle Particle;
    }

    [Serializable]
    public class TTSImpactSound
    {
        public List<AudioClip> Pickup;
        public List<AudioClip> Drop;
        public List<AudioClip> Shake;

        public List<AudioClip> ImpactGeneric;
        public List<AudioClip> ImpactWood;
        public List<AudioClip> ImpactMetal;
        public List<AudioClip> ImpactPlastic;
        public List<AudioClip> ImpactCardBoard;
        public List<AudioClip> ImpactGlass;
    }
    
    [Tooltip("Looping effects are great for idle animations, looping sounds, or continous particle effects. Looping effects are swappable using the contextual menu on the object.")]
    public List<TTSEffect> LoopingEffects;
    [Tooltip("Trigger effects are great for attack animations, sound effects, or spell effects. Trigger effects are executed using the contextual menu on the object.")]
    public List<TTSEffect> TriggerEffects;
    [Tooltip("Impact sounds are the sounds that occur when objects collide. If you don't want to have to provide unique sounds for each material type just supply the generic impact sound.")]
    public TTSImpactSound ImpactSounds;
}
