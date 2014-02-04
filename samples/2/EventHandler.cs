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
     * A class that simplifies touch event handling.
     * Part of the utility partition.
     * 
     * Still in development...
     */
    class EventHandler
    {
        protected List<GestureType> enabledGestures; /**< List of enabled gestures */

        /**
         * A constructor.
         * 
         * Simply initializes class variables.
         */
        public EventHandler()
        {
            enabledGestures = new List<GestureType>();
        }

        /**
         * The function enables a single gesture in the EventHandler.
         * Remember to enable all gestures you want to use.
         * 
         * @param gesture the GestureType of the gesture you wish to enable
         */
        public void enableGesture(GestureType gesture)
        {
            if(!enabledGestures.Contains(gesture))
                enabledGestures.Add(gesture);

            updateGestures();
        }

        /**
         * The function disables a single gesture in the EventHandler.
         * 
         * @param gesture the GestureType of the gesture you wish to disable
         */
        public void disableGesture(GestureType gesture)
        {
            if (enabledGestures.Contains(gesture))
                enabledGestures.Remove(gesture);

            updateGestures();
        }

        /**
         * Function returns true if the user has pushed back button on his phone.
         * @param true if user pressed the back button
         */
        public bool userExit() {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                return true;

            return false;
        }

        /**
         * This function is deprecated. Please use the readEventType() function instead.
         * Returns the vector to the tapped point. Vector is a zero vector if there was
         * no touch event.
         * 
         * OUTDATED!
         * 
         * @return the touch event location
         */
        public Vector2 readTapPoint()
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (TouchLocation tl in touchCollection)
            {
                if ((tl.State == TouchLocationState.Pressed)
                        || (tl.State == TouchLocationState.Moved))
                {
                    return tl.Position;
                }
            }

            return new Vector2(0, 0);
        }

        /**
         * The function handles implemented and enabled gestures and
         * places the gesture data in the dataVector variable which can
         * be retrieved using the getDataVector() function.
         * 
         * Currently the following gestures are implemented:
         * Tap, HorizontalDrag, Hold, VerticalDrag.
         * 
         * @return the GestureType of the detected gesture (or None)
         */
        public Event readEvent()
        {
            GestureType eventType = GestureType.None;

            if (TouchPanel.IsGestureAvailable)
            {
                GestureSample gs = TouchPanel.ReadGesture();
                eventType = gs.GestureType;

                switch (gs.GestureType)
                {
                    case GestureType.Tap:
                        return new Event(eventType, gs.Position);
                    case GestureType.HorizontalDrag:
                        return new Event(eventType, gs.Delta);
                    case GestureType.Hold:
                        return new Event(eventType, gs.Position);
                    case GestureType.VerticalDrag:
                        return new Event(eventType, gs.Delta);
                    case GestureType.FreeDrag:
                        return new Event(eventType, gs.Position);
                }
            }

            return new Event(eventType);
        }

        // Seems to work
        private void updateGestures()
        {
            GestureType allGestures = GestureType.None;
            foreach (GestureType gesture in enabledGestures)
            {
                allGestures |= gesture;
            }

            TouchPanel.EnabledGestures = allGestures;
        }
    }
}
