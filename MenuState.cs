using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;

namespace wp_engine
{
    /**
     * A class for menu screen in a game.
     * Part of the state partition.
     * 
     * Inherits State.
     */
    class MenuState : State
    {
        AnimatedObject backgroundAnimation;

        /**
         * A constructor.
         * @param screenWidth the width of the screen resolution
         * @param screenHeight the height of the screen resolution
         */
        public MenuState(int screenWidth, int screenHeight) 
            : base(screenWidth, screenHeight)
        { }

        public override void init() { }

        public override void update(float elapsed) {
            backgroundAnimation.update(elapsed);
        }

        /**
         * The function loads the contents of the help screen.
         * Change this to your requirements.
         * @param contentManager the content manager for the game
         */
        public override void loadContent(ContentManager contentManager)
        {
            // Run the original loadContent function
            base.loadContent(contentManager);

            // Relocates the buttons so that they are 30 pixels apart from each other at the center of the screen
            if (stateButtons.Keys.Contains(stateIdentifier.GAME) && stateButtons.Keys.Contains(stateIdentifier.HELP))
            {
                Vector2 playsize = stateButtons[stateIdentifier.GAME].TextureSize;
                Vector2 aboutsize = stateButtons[stateIdentifier.HELP].TextureSize;

                int a = (int)(resolution.Y - 30 - playsize.Y - aboutsize.Y) / 2;

                stateButtons[stateIdentifier.GAME].setLocation(resolution.X / 2 - playsize.X / 2, a);
                stateButtons[stateIdentifier.HELP].setLocation(resolution.X / 2 - aboutsize.X / 2, resolution.Y - a - playsize.Y);
            }

            // Creates and loads an animation background
            backgroundAnimation = new AnimatedObject(0, 0, Layer.BOTTOM);
            backgroundAnimation.loadTextures(contentManager, "menuanimation");
        }

        // DEPRECATED: most states should now use the underlying draw-function
        // in State.cs. 

        /**
         * Draws the objects of the state.
         * @param sb the spritebatch of the game
         */
        public override void draw(SpriteBatch sb)
        {
            backgroundAnimation.draw(sb);
            base.draw(sb);
        }
    }
}
