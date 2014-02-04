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
    class Character : LiveObject
    {
        protected Animation animation;

        public Character(float x, float y, float framelength)
            : base(x, y, (Texture2D)null)
        {
            animation = new Animation(framelength);
        }

        public override void update(float elapsed)
        {
            animation.update(elapsed);
            texture = animation.getTexture();
            base.update(elapsed);
        }

        public void loadTextures(ContentManager contentManager, string folderName, string fileStructure, int framecount)
        {
            animation.loadContent(contentManager, folderName, fileStructure, framecount);
        }

    }
}
