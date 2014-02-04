using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;

namespace wp_engine
{
    /**
     * Consists of identifiers for the most basic states.
     */
    enum stateIdentifier
    {
        MENU, HELP, GAME, EXIT, NONE
    };

    /**
     * A class that handles the states smoothly.
     * Part of the state partition.
     */
    class StateManager
    {
        /**
         * A dictionary that connects the stateIdentifier to the state
         * class.
         */
        private Dictionary<stateIdentifier, State> gameStates;
        private EventHandler eventHandler;

        private stateIdentifier currentState;

        public StateManager()
        {
            gameStates = new Dictionary<stateIdentifier, State>();
            eventHandler = new EventHandler();

            eventHandler.enableGesture(GestureType.Tap);
            eventHandler.enableGesture(GestureType.Hold);
            eventHandler.enableGesture(GestureType.HorizontalDrag);
            currentState = stateIdentifier.MENU;
        }

        public void addState(stateIdentifier id, State state)
        {
            gameStates.Add(id, state);
        }

        public void update(float elapsed)
        {
            Event recentEvent = eventHandler.readEvent();

            stateIdentifier request = gameStates[currentState].requests(recentEvent);
            if (request != stateIdentifier.NONE && gameStates.ContainsKey(request))
                currentState = request;

            gameStates[currentState].handleEvent(recentEvent);

            gameStates[currentState].update(elapsed);
        }

        public void draw(SpriteBatch sb)
        {
            gameStates[currentState].draw(sb);
        }
    }
}
