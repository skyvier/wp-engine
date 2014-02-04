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
     * A class for moving objects.
     * Part of the object partition.
     * 
     * Inherits Object.
     */
    class LiveObject : Object
    {
        protected Vector2 acceleration;
        protected Vector2 speed;

        #region construction

        /**
         * A constructor.
         * Sets initial speed and acceleration to zero.
         * @param x x-coordinate
         * @param y y-coordinate
         * @param texture the texture of the object
         */
        public LiveObject(float x, float y, Texture2D texture)
            : base(x, y, texture, Layer.TOP)
        {
            initVariables(new Vector2(0, 0), new Vector2(0, 0));   
        }

        /**
         * A constructor.
         * Sets initial acceleration to zero.
         * @param x x-coordinate
         * @param y y-coordinate
         * @param texture the texture of the object
         * @param speed the initial speed of the object
         */
        public LiveObject(float x, float y, Texture2D texture, Vector2 speed)
            : base(x, y, texture, Layer.TOP)
        {
            initVariables(speed, new Vector2(0, 0));
        }

        /**
         * A constructor.
         * @param x x-coordinate
         * @param y y-coordinate
         * @param texture the texture of the object
         * @param speed the initial speed of the object
         * @param acceleration the initial acceleration of the object
         */
        public LiveObject(float x, float y, Texture2D texture, Vector2 speed, Vector2 acceleration)
            : base(x, y, texture, Layer.TOP)
        {
            initVariables(speed, acceleration);
        }

        public LiveObject(float x, float y, string assetName, Vector2 speed, Vector2 acceleration)
            : base(x, y, assetName, Layer.TOP)
        {
            initVariables(speed, acceleration);
        }

        // Sets speed and acceleration. Private function. Used in constructors.
        private void initVariables(Vector2 speed, Vector2 acceleration)
        {
            this.speed = speed;
            this.acceleration = acceleration;
        }

        #endregion

        /**
         * The speed of the object.
         */
        public Vector2 Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        /**
         * The acceleration of the object.
         */
        public Vector2 Acceleration
        {
            get
            {
                return acceleration;
            }
            set
            {
                acceleration = value;
            }
        }

        /**
         * Updates the speed and the location of the object. Protected function.
         */
        protected void move()
        {
            speed = new Vector2(speed.X + acceleration.X, speed.Y + acceleration.Y);
            setLocation(location.X + speed.X, location.Y + speed.Y);
        }

        /**
         * Updates the object. Read: moves it.
         */
        public virtual void update(float elapsed) { move(); }

    }
}
