using Astroboy.Utils;
using UnityEngine;

namespace Astroboy.Sound
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] Sound[] sounds;
        // Start is called before the first frame update
        protected override void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }

            InitializeSounds();
        }

        private void InitializeSounds()
        {
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.outputAudioMixerGroup = s.output;
            }
        }

        public static void Play(string name)
        {
            Sound s = System.Array.Find(Instance.sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("The:{" + name + "} sound could not be found.");
                return;
            }
            s.source.Play();
        }
    }
}
