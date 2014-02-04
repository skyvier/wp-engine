using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace wp_engine
{
    /**
     * A class that contains all of the information
     * of a single touch event required by the other
     * partitions of the library.
     * 
     * The only output form of the EventHandler.
     */
    class Event
    {
        private Vector2 dataVector;
        private GestureType type;

        public Event(GestureType type)
        {
            this.type = type;
        }

        public Event(GestureType type, Vector2 dataVector)
        {
            this.type = type;
            this.dataVector = dataVector;
        }

        public Vector2 getVector() {
            return dataVector;
        }

        public GestureType getType()
        {
            return type;
        }
    }
}
