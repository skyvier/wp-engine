using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using FarseerPhysics.Factories;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;

namespace wp_engine
{
    enum Layer
    {
        BOTTOM, MIDDLE, TOP
    };

    /**
     * A class for graphical 2D objects.
     * Part of the object partition.
     * 
     * The base class for all of the objects.
     */
    class Object
    {
        #region parameters

        protected const float pixelsToMeters = 10 / 800;
        protected const float metersToPixels = 80;

        protected Vector2 location;
        protected Fixture fixture;

        protected bool active;
        protected bool loaded;

        protected string assetName;

        protected Texture2D texture; /**< The texture of the object. */

        protected Layer layer;

        #endregion

        #region properties

        /**
         * A boolean variable that indicates whether or not the
         * object should be updated and drawn.
         */
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        public Layer DrawLayer
        {
            get
            {
                return layer;
            }
            set
            {
                layer = value;
            }
        }

        /**
         * Vector2 variable that stores the location of the object.
         */
        public Vector2 Location
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

        public Vector2 TextureSize
        {
            get
            {
                return new Vector2(texture.Width, texture.Height);
            }
        }

        #endregion

        #region construction

        /**
         * A constructor.
         * @param x object location (x-coordinate)
         * @param y object location (y-coordinate)
         * @param texture the picture which the object represents
         */
        public Object(float x, float y, Texture2D texture, Layer layer)
        {
            location = new Vector2(x, y);
            this.texture = texture;
            this.layer = layer;

            active = true;
            loaded = true;
        }

        /**
         * A constructor.
         * Sets the object location to (0, 0).
         * @param texture the picture which the object represents
         */
        public Object(Texture2D texture, Layer layer)
        {
            location = new Vector2(0, 0);
            this.texture = texture;
            this.layer = layer;

            active = true;
            loaded = true;
        }

        /**
         * A constructor.
         * Creates an object without without having to load the texture (yet).
         * @param x object location (x-coordinate)
         * @param y object location (y-coordinate)
         * @param textureName the name of the picture which the object represents
         */
        public Object(float x, float y, string textureName, Layer layer)
        {
            location = new Vector2(x, y);
            assetName = textureName;
            this.layer = layer;

            active = true;
            loaded = false;
        }

        /**
         * Loads any unloaded assets.
         * 
         * @param content the ContentManager of the game
         */
        public void loadAssets(ContentManager content)
        {
            if (!loaded)
            {
                this.texture = content.Load<Texture2D>(assetName);
                loaded = true;
            }
        }

        /**
         * Returns a silent object. It won't be updated or 
         * drawn unless specified otherwise.
         * 
         * @param x object location (x-coordinate)
         * @param y object location (y-coordinate)
         * @param texture the picture which the object represents
         */
        public static Object createSilentObject(float x, float y, Texture2D texture, Layer layer)
        {
            Object temp = new Object(x, y, texture, layer);
            temp.Active = false;
            return temp;
        }

        /**
         * Returns a silent object. It won't be updated or 
         * drawn unless specified otherwise.
         * 
         * @param x object location (x-coordinate)
         * @param y object location (y-coordinate)
         * @param textureName the name of the picture which the object represents
         */
        public static Object createSilentObject(float x, float y, string textureName, Layer layer)
        {
            Object temp = new Object(x, y, textureName, layer);
            temp.Active = false;
            return temp;
        }

        #endregion

        #region utilities
        /**
         * Returns the location of the center of the object on the screen.
         * @return the coordinates of the object's center (Vector2)
         */
        public Vector2 getCenter()
        {
            return new Vector2(location.X + texture.Width / 2, location.Y + texture.Height / 2);
        }

        /**
         * Used to set the location of the object.
         * @param x x-coordinate
         * @param y y-coordinate
         */
        public void setLocation(float x, float y)
        {
            location = new Vector2(x, y);
        }

        /**
         * Draws the object.
         * @param sb the spritebatch of the game
         */
        public void draw(SpriteBatch sb)
        {
            if (loaded && active)
                sb.Draw(texture, location, Color.White);
            else if(!loaded)
                Console.WriteLine("The content of the object hasn't been loaded. Cannot draw!");
        }

        #endregion
    }
}
