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
     * The inteface for game states.
     * An advisory inteface.
     * 
     * Part of the state partition.
     */
    interface StateInterface
    {
        void init();
        void update(float elapsedTime);
        void loadContent(ContentManager contentManager);
        void draw(SpriteBatch sb);
    }
}
