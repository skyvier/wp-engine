using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace wp_engine
{
    /**
     * A class for handling the audio elements of the game.
     * Part of the utilities partition.
     * 
     * The windows phone platform has a limit of 16 simultaneous playing sounds.
     */
    class AudioHandler
    {
        protected Dictionary<string, SoundEffectInstance> soundEffects; /**< A dictionary of sound effects */

        /**
         * A constructor.
         * Initializes variables.
         */
        public AudioHandler() {
            soundEffects = new Dictionary<string, SoundEffectInstance>();
        }

        // C# 3.0 doesn't support default function arguments -.-
        /**
         * The function adds a sound effect to the AudioHandler resources.
         * @param contentManager the ContentManager of the game
         * @param soundName the name of the sound resource and the identifier for the sound
         * @param repeat true for looped effects
         */
        public void addSoundEffect(ContentManager contentManager, 
            string soundName, bool repeat)
        {
            if (!soundEffects.ContainsKey(soundName))
            {
                soundEffects.Add(soundName, contentManager.Load<SoundEffect>(soundName).CreateInstance());
                if (repeat)
                {
                    SoundEffectInstance instance = soundEffects[soundName];
                    instance.IsLooped = true;
                }
            }
        }

        /**
         * The function adds a sound effect to the AudioHandler resources.
         * @param contentManager the ContentManager of the game
         * @param soundName the name of the sound resource and the identifier for the sound
         */
        public void addSoundEffect(ContentManager contentManager, string soundName)
        {
            if (!soundEffects.ContainsKey(soundName))
                soundEffects.Add(soundName, contentManager.Load<SoundEffect>(soundName).CreateInstance());
        }

        /**
         * Changes settings for loaded sound effects in the AudioHandler resources.
         * @param identifier the name of the sound effect specified in addSoundEffect()
         * @param parameter the parameter identifier (volume, pitch and repeat are supported)
         * @param value the parameter value (int)
         */
        public void setEffectParameter(string identifier, string parameter, int value)
        {
            switch (parameter)
            {
                case "volume":
                    soundEffects[identifier].Volume = value;
                    break;
                case "pitch":
                    soundEffects[identifier].Pitch = value;
                    break;
                case "repeat":
                    if (value == 0)
                        soundEffects[identifier].IsLooped = false;
                    else
                        soundEffects[identifier].IsLooped = true;
                    break;
            }
        }

        /**
         * Plays a loaded sound effect.
         * @param identifier the sound effect identifier in the AudioHandler resources
         */
        public void playEffect(string identifier)
        {
            soundEffects[identifier].Play();
        }

        /**
         * Stops a loaded sound effect.
         * @param identifier the sound effect identifier in the AudioHandler resources
         */
        public void stopEffect(string identifier)
        {
            soundEffects[identifier].Stop();
        }
    }
}
