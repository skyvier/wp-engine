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
     * A class for multiple animation: a slideshow.
     * The idea is that a slideshow contains multiple animations
     * and the animation that is displayed can be changed by an event.
     * 
     * Part of the animation partition.
     */
    class SlideShow
    {
        private List<AnimatedObject> animatedObjects; /**< List of the animated objects */
        private int animationNo; /**< The index of the current animation */
        private float runTime; /**< The runtime of the current animation */
        private float elapsedTime; /**< The elapsed time since the beginning of the animation*/
        private bool stopped; /**< True if the slideshow has been stopped */

        /**
         * A constructor.
         * Sets the variables to default values.
         */
        public SlideShow()
        {
            stopped = false;
            animationNo = 0;
            runTime = 0;
            elapsedTime = 0;
            animatedObjects = new List<AnimatedObject>();
        }

        /**
         * Adds an animated object (animation).
         * @param animatedObject the AnimatedObject containing the animation you wish to add
         */
        public void addAnimatedObject(AnimatedObject animatedObject)
        {
            animatedObjects.Add(animatedObject);
        }

        /**
         * Updates the current animation.
         * @param elapsed elapsed time
         */
        public void update(float elapsed)
        {
            animatedObjects.ElementAt(animationNo).update(elapsed);
        }

        /**
         * Activates the next animation in the slideshow.
         */
        public void next()
        {
            if (!stopped)
            {
                if (animationNo < animatedObjects.Count)
                    animationNo++;
                else
                    animationNo = 0;
            }
        }

        /**
         * Updates the slideshow and changes the animation automatically
         * once the animation has been shown completely.
         * @param elapsed elapsed time
         */
        public void autoUpdate(float elapsed)
        {
            if (!stopped)
            {
                elapsedTime += elapsed;
                runTime = animatedObjects.ElementAt(animationNo).getAnimationLength();
                if (elapsedTime > runTime)
                {
                    if (animationNo < animatedObjects.Count)
                        animationNo++;
                    else
                        animationNo = 0;
                    elapsedTime = 0;
                }
            }
            
            animatedObjects.ElementAt(animationNo).update(elapsed);
        }

        /**
         * Draws the current frame of the current animation.
         * @param sb the spritebatch of the game
         */
        public void draw(SpriteBatch sb)
        {
            animatedObjects.ElementAt(animationNo).draw(sb);
        }

        /**
         * Stops the slideshow.
         * Stops autoUpdate(), and the current animation.
         * Disables next() function.
         */
        public void stop()
        {
            stopped = true;
            animatedObjects.ElementAt(animationNo).stopAnimation();
        }

        /**
         * Resumes the slideshow.
         * Resumes autoUpdate(), and the current animation.
         * Enables next() function.
         */
        public void resume()
        {
            stopped = false;
            animatedObjects.ElementAt(animationNo).startAnimation();
        }
    }
}
