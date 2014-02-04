using System;
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
     * A class for animated objects.
     * Part of the animation partition.
     * 
     * Inherits Object.
     */
    class AnimatedObject : Object
    {
        /**
         * A constructor.
         * @param x object location (x-coordinate)
         * @param y object location (y-coordinate)
         */ 
        public AnimatedObject(float x, float y, Layer layer)
            : base(x, y, (Texture2D)null, layer)
        {
            animation = new Animation(900);
        }

        /**
         * Loads the animation textures. Do this before using the animatedObject!
         * @param contentManager the content manager for the game
         * @param folderName specifies the folder where the animation frames can be found
         * @param frameLength the length of a single frame in the animation
         */
        public void loadTextures(ContentManager contentManager, string folderName)
        {
            animation.loadContent(contentManager, folderName, "testi", 4);
        }

        /**
         * The animation class for the object.
         * @see Animation
         */
        private Animation animation;

        /**
         * Update function.
         * Updates the animation and changes the texture to the right texture.
         * @param elapsed the elapsed time
         */
        public void update(float elapsed)
        {
            animation.update(elapsed);
            texture = animation.getTexture();
        }

        /**
         * Stops the animation of the object.
         * @see Animation
         */
        public void stopAnimation()
        {
            animation.stop();
        }

        /**
         * Starts the animation from the texture it was displaying previously.
         * @see Animation
         */
        public void startAnimation()
        {
            animation.start();
        }

        /**
         * Starts the animation from the beginning.
         * @see Animation
         */
        public void resetAnimation()
        {
            animation.reset();
        }

        /**
         * Return the length of the animation in seconds.
         * @return the length of the animation as float number
         */
        public float getAnimationLength()
        {
            return animation.size()*animation.getFrameLength();
        }
    }
}
