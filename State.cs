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
     * The base class for all of the game states.
     * (ie. HelpState, MenuState)
     * Part of the state Partition.
     * 
     * Implements StateInterface.
     */
    class State : StateInterface
    {
        public delegate void method();

        protected Vector2 resolution; /**< The resolution of the screen */

        protected List<Object> bitmaps; /**< Contains all of the object that act as simple pictures */
        protected List<LiveObject> liveObjects; /**< Contains moving objects */

        protected Dictionary<method, EventObject> methodButtons; /**< Contains buttons that trigger a method */
        protected Dictionary<stateIdentifier, EventObject> stateButtons; /**< Constains buttons that trigger a state transition */

        protected AudioHandler audioHandler; /**< The AudioHandler for the state. Should be a pointer. */

        /**
         * A constructor.
         * @param screenWidth the width of the screen resolution
         * @param screenHeight the height of the screen resolution
         */
        public State(int screenWidth, int screenHeight)
        {
            resolution = new Vector2(screenWidth, screenHeight);

            bitmaps = new List<Object>();
            liveObjects = new List<LiveObject>();
            methodButtons = new Dictionary<method, EventObject>();
            stateButtons = new Dictionary<stateIdentifier, EventObject>();

            audioHandler = new AudioHandler();
        }

        // Is the init() function even needed?
        virtual public void init() { }
        virtual public void update(float elapsedTime) { }

        virtual public void loadContent(ContentManager contentManager) {
            foreach (Object obj in bitmaps)
            {
                obj.loadAssets(contentManager);
            }

            foreach (LiveObject liveobj in liveObjects)
            {
                liveobj.loadAssets(contentManager);
            }

            foreach (EventObject eventobj in stateButtons.Values)
            {
                eventobj.loadAssets(contentManager);
            }

            foreach (EventObject eventobj in methodButtons.Values)
            {
                eventobj.loadAssets(contentManager);
            }
        }

        virtual public void draw(SpriteBatch sb) {
            for (int i = (int)Layer.BOTTOM; i <= (int)Layer.TOP; i++)
            {
                foreach (Object obj in bitmaps)
                {
                    if(obj.DrawLayer == (Layer)i)
                        obj.draw(sb);
                }

                foreach (LiveObject liveobj in liveObjects)
                {
                    if (liveobj.DrawLayer == (Layer)i)
                        liveobj.draw(sb);
                }

                foreach (EventObject eventobj in stateButtons.Values)
                {
                    if (eventobj.DrawLayer == (Layer)i)
                        eventobj.draw(sb);
                }

                foreach (EventObject eventobj in methodButtons.Values)
                {
                    if (eventobj.DrawLayer == (Layer)i)
                        eventobj.draw(sb);
                }
            }
        }

        /**
         * Reacts to events. Returns the stateIdentifier of the state 
         * which the MenuState requests.
         * 
         * @param vector of tap point
         * @return the stateIdentifier the state wishes to mutate to
         */
        public virtual stateIdentifier requests(Event recentEvent)
        {
            if (recentEvent.getType() == GestureType.Tap)
            {
                foreach (stateIdentifier id in stateButtons.Keys)
                {
                    if (stateButtons[id].isPressed(recentEvent.getVector()))
                        return id;
                }
            }

            return stateIdentifier.NONE;
        }

        #region addContentFunctionalities

        public void addBitmap(float x, float y, string textureName, Layer layer)
        {
            bitmaps.Add(new Object(x, y, textureName, layer));
        }

        public void addSilentBitmap(float x, float y, string textureName, Layer layer)
        {
            bitmaps.Add(Object.createSilentObject(x, y, textureName, layer));
        }

        public void addStateButton(stateIdentifier targetState, float x, float y, string textureName)
        {
            stateButtons.Add(targetState, new EventObject(x, y, textureName));
        }

        public void addSoundEffect(ContentManager content, string fileName)
        {
            audioHandler.addSoundEffect(content, fileName);
        }

        #endregion
    }
}
