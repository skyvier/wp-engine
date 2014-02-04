using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace wp_engine
{
    /**
     * A class designed to simplify animations.
     * Manages multiple textures. Before using this
     * take a look at the AnimatedObject class because you'd
     * probably rather use it!
     * 
     * Part of the animation partition.
     */
    class Animation
    {
        private List<Texture2D> frames; /**< List of animation frames as textures */
        private float frameLength; /**< Frame length in seconds */

        private float elapsedTime;

        private int frameNo; /**< The index of the current frame */
        private bool stopped; /**< The boolean specifies whether or not the animation has been stopped */

        /**
         * A constructor.
         * Loads all the files in a folder as animation frames and initializes the class.
         * @param contentManager the content manager for the game
         * @param folderName the name of the folder which contains the frames
         * @param frameLength the length of a single frame in seconds
         */
        public Animation(float frameLength)
        {
            elapsedTime = 0;
            frameNo = 0;
            stopped = false;
            frames = new List<Texture2D>();
            this.frameLength = frameLength;
        }

        /*
        public void loadContent(ContentManager contentManager, string folderName)
        {
            DirectoryInfo dir = new DirectoryInfo(contentManager.RootDirectory + "\\" + folderName);
            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                string filename = Path.GetFileNameWithoutExtension(file.Name);
                frames.Add(contentManager.Load<Texture2D>(folderName + "/" + filename));
            }
        }*/

        public void loadContent(ContentManager contentManager, string folderName, string fileStructure, int amount)
        {
            for (int i = 1; i <= amount; i++)
            {
                frames.Add(contentManager.Load<Texture2D>(folderName + "\\" + fileStructure + i.ToString()));
            }
        }

        /**
         * Updates the animation frame.
         * @param elapsed the elapsed time
         */
        public void update(float elapsed)
        {
            elapsedTime += elapsed;

            if (!stopped)
            {
                frameNo = (int)(elapsedTime / frameLength);
                if(elapsedTime > frameLength) 
                    frameNo = frameNo % frames.Count;
            }
        }

        /**
         * Returns the current texture of the animation.
         * @return current texture of the animation
         */
        public Texture2D getTexture()
        {
            return frames.ElementAt(frameNo);
        }

        /**
         * Returns amount of frames in the animation.
         * @return amount of frames in the animation
         */
        public int size()
        {
            return frames.Count;
        }

        /**
         * Return the length of a single frame in the animation.
         * @return length of a single frame in the animation
         */
        public float getFrameLength()
        {
            return frameLength;
        }

        /**
         * Stops the animation.
         */
        public void stop()
        {
            stopped = true;
        }

        /**
         * Starts the animation from the last frame.
         */
        public void start()
        {
            stopped = false;
        }

        /**
         * Resets the animation to the first frame.
         */
        public void reset()
        {
            frameNo = 0;
        }
    }
}
