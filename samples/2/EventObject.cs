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
     * A class of event handling objects.
     * Part of the object partition.
     * 
     * Inherits Object.
     */
    class EventObject : Object
    {
        /**
         * A constructor.
         * @param x object location (x-coordinate)
         * @param y object location (y-coordinate)
         * @param texture the texture of the object
         */
        public EventObject(float x, float y, Texture2D texture) : base(x, y, texture, Layer.TOP) { }

        public EventObject(float x, float y, string assetName) : base(x, y, assetName, Layer.TOP) { }

        /**
         * Returns true if parameter coordinates are inside the EventObject.
         * @param pressedLocation the location which the user pressed (Vector2)
         * @return boolean, true if parameter coordinates are inside the EventObject
         */
        public virtual bool isPressed(Vector2 pressedLocation)
        {
            Rectangle tempRect = new Rectangle((int)location.X, (int)location.Y, texture.Width, texture.Height);
            return tempRect.Contains((int)pressedLocation.X, (int)pressedLocation.Y);
        }

    }
}
