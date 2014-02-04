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
     * A class for help screens in games.
     * Part of the state partition.
     * 
     * Inherits State.
     */
    class HelpState : State
    {
        /**
         * A constructor.
         * @param screenWidth the width of the screen resolution
         * @param screenHeight the height of the screen resolution
         */
        public HelpState(int screenWidth, int screenHeight)
            : base(screenWidth, screenHeight)
        { }

        public override void init() { }

        public override void update(float elapsed) { }

        /**
         * The function loads the contents of the help screen.
         * Change this to your requirements.
         * @param contentManager the content manager for the game
         */
        public override void loadContent(ContentManager contentManager)
        {
            base.loadContent(contentManager);
        }
    }
}
