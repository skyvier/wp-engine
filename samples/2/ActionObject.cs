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
    abstract class ActionObject : EventObject
    {
        public ActionObject(float x, float y, Texture2D texture) : base(x, y, texture) { }

        public override bool isPressed(Vector2 pressedLocation)
        {
            if(base.isPressed(pressedLocation)) {
                action();
                return true;
            }

            return false;
        }

        protected abstract void action();
    }
}
