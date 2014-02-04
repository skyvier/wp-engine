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
     * A class for text elements.
     * Part of the object partition.
     */
    class Text
    {
        protected SpriteFont font; /**< The font of the text */
        protected string content; /**< The contents of the text */

        /**
         * A constructor.
         * @param x the location of the text (x-coordinate)
         * @param y the location of the text (y-coordinate)
         * @param font the font of the text
         * @param content the content of the text
         */
        public Text(float x, float y, SpriteFont font, string content)
        {
            location = new Vector2(x, y);
            this.font = font;
            this.content = content;
        }

        /**
         * A constructor.
         * @param target the object on which the text will be located
         * @param font the font of the text
         * @param content the content of the text
         */
        public Text(Object target, SpriteFont font, string content)
        {
            location = target.getCenter();
            this.font = font;
            this.content = content;
        }

        /**
         * Vector2 variable that stores the location of the object.
         */
        protected Vector2 location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        /**
         * Draws the text.
         * @param sb the spritebatch of the game
         */
        public void draw(SpriteBatch sb)
        {
            sb.DrawString(font, content, location, Color.White);
        }
    }
}
