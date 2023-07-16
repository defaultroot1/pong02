using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong02
{
    internal class AudioManager
    {

        private SoundEffect _clickSound;
        private SoundEffect _goalSound;
        private Song _song;

        public AudioManager(ContentManager contentManager)
        {
            _clickSound = contentManager.Load<SoundEffect>("Audio/click");
            _goalSound = contentManager.Load<SoundEffect>("Audio/powerUp2");
            _song = contentManager.Load<Song>("Audio/bgSong");
        }


        public void PlayClickSound()
        {
            _clickSound.Play(1, -1, 0);
        }

        public void PlayGoalSound()
        {
            _goalSound.Play(1, -1, 0);
        }

        public void PlaySong()
        {
            MediaPlayer.Play(_song);
            MediaPlayer.IsRepeating = true;
        }
    }
}
