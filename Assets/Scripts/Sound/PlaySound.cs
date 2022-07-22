using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astroboy.Sound
{
    public class PlaySound : MonoBehaviour
    {
        public void PlaySomeSound(string name) => SoundManager.Play(name);
    }
}