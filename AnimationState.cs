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
     * A base class for displaying animations.
     * Part of the state partition.
     * 
     * Inherits State.
     */
    class AnimationState : State
    {
        private List<SlideShow> slideShows;
        private int currentShow;

        /**
         * A constructor.
         * @param screenWidth the width of the screen resolution
         * @param screenHeight the height of the screen resolution
         */
        public AnimationState(int screenWidth, int screenHeight)
            : base(screenWidth, screenHeight)
        {
            slideShows = new List<SlideShow>();        
        }

        /**
         * Adds a slide show to the available slide shows of
         * the AnimationState.
         * 
         * @param show the slide show to be added
         */
        public void addSlideShow(SlideShow show)
        {
            if (show == null)
            {
                Console.WriteLine("Error! The slideshow is empty!");
            }

            foreach (SlideShow temp in slideShows)
            {
                if (show.Equals(temp))
                {
                    Console.WriteLine("Error! The slideshow called " +
                        show.getIdentifier() + " already exists!");
                    return;
                }
            }

            slideShows.Add(show);
        }

        /**
         * Sets the current slide show of the state.
         * The show in question will be played when
         * the state is activated.
         * The slideshow must be added to the state before calling this method.
         * 
         * @param identifier the identifier string (name) of the slide show
         */
        public bool setShow(string identifier)
        {
            // reset the previous animation
            slideShows.ElementAt(currentShow).reset();

            // find the correct slideshow
            foreach (SlideShow show in slideShows) {
                if (show.getIdentifier() == identifier) {
                    currentShow = slideShows.IndexOf(show);
                    if(currentShow != -1)
                        return true;
                }
            }

            return false;
        }

        /**
         * An override of the update function in State.
         * See State.update().
         * Updates the current slideshow.
         */
        public override void update(float elapsedTime)
        {
            if (slideShows.ElementAt(currentShow).isComplete())
                slideShows.ElementAt(currentShow).stop();
            slideShows.ElementAt(currentShow).autoUpdate(elapsedTime);
        }

        /**
         * An override of draw in State.
         */
        public override void draw(SpriteBatch sb)
        {
            slideShows.ElementAt(currentShow).draw(sb);
        }

        /**
         * An override of the state requests-function.
         * Requests a transition to the home state when
         * the animation ends.
         * 
         * @param recentEvent the latest event
         */
        public override stateIdentifier requests(Event recentEvent)
        {
            if (slideShows.ElementAt(currentShow).isComplete())
                return slideShows.ElementAt(currentShow).homeState;
            return base.requests(recentEvent);
        }

    }
}
