using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace wp_engine
{
    class PlayState : State
    {
        Character panda;
        Player pandauser;

        public PlayState(int screenWidth, int screenHeight) 
            : base(screenWidth, screenHeight)
        { }

        public override void init() { }

        public override void update(float elapsed)
        {
            pandauser.update(elapsed);
        }

        public override void loadContent(ContentManager contentManager)
        {
            base.loadContent(contentManager);

            panda = new Character(100, 100, 900);
            panda.loadTextures(contentManager, "pandanimation", "", 14);
            pandauser = new Player(panda);
        }

        public override void handleEvent(Event recentEvent)
        {
            base.handleEvent(recentEvent);
            pandauser.handleEvent(recentEvent);
        }

        public override void draw(SpriteBatch sb)
        {
            pandauser.draw(sb);
            base.draw(sb);
        }
    }
}
