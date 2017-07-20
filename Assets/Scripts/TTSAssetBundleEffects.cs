using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TTSAssetBundleEffects : MonoBehaviour
{
    [Serializable]
    public class TTSParticle
    {
        public ParticleSystem Particle;
    }

    [Serializable]
    public class TTSGameObject
    {
        public GameObject gameObject;
    }

    [Serializable]
    public class TTSSound
    {
        public AudioClip Audio;
        public bool Positional3D = true;

        public TTSSound()
        {
            Positional3D = true;
        }
    }

    [Serializable]
    public class TTSAnimation
    {
        public Animation AnimationComponent;
        public string AnimationName;
    }

    [Serializable]
    public class TTSAnimator
    {
        public Animator AnimatorComponent;
        public string StateName;
    }

    [Serializable]
    public class TTSEffect
    {
        public string Name;
        public List<TTSGameObject> GameObjects;
        public List<TTSParticle> Particles;
        public TTSSound Sound;
        public TTSAnimation Animation;
        public TTSAnimator Animator;
    }

    [Serializable]
    public class TTSLoopingEffect : TTSEffect
    {
    }

    [Serializable]
    public class TTSTriggerEffect : TTSEffect
    {
        public float Duration = 1f;
    }

    [Tooltip("Looping effects are great for idle animations, looping sounds, or continous particle effects. Looping effects are swappable using the contextual menu on the object.")]
    public List<TTSLoopingEffect> LoopingEffects = new List<TTSLoopingEffect>() { new TTSLoopingEffect() };
    [Tooltip("Trigger effects are great for attack animations, sound effects, or spell effects. Trigger effects are executed using the contextual menu on the object.")]
    public List<TTSTriggerEffect> TriggerEffects = new List<TTSTriggerEffect>() { new TTSTriggerEffect() };   
}