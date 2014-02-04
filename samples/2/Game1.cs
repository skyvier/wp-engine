using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using wp_engine; // the program uses the wp_engine namespace (the library)

namespace WPEngineTesti
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MenuState menu; // The specified state for menu
        HelpState help; // The specified state for about screen
        PlayState play;
        StateManager manager; // The state manager

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            menu = new MenuState(800, 480); // Creates menu with screen resolution of 800x480
            help = new HelpState(800, 480); // Creates help/about screen with a resolution of 800x480 
            play = new PlayState(800, 480);

            manager = new StateManager(); // Creates the state manager

            // TODO: use this.Content to load your game content here
            menu.addStateButton(stateIdentifier.GAME, 0, 0, "play"); // Adds a button that changes the gameState to GAME to the menu screen
            menu.addStateButton(stateIdentifier.HELP, 0, 0, "about"); // Adds a button that changes the gameState to HELP to the menu screen 
            // The animation is created specifically in the MenuState codebase, a better way is yet to be implemented
            // TODO: find an easier way to create animations (both in states and outside of them)

            help.addBitmap(0, 0, "helpbg", Layer.BOTTOM); // Adds a background to the help screen
            help.addStateButton(stateIdentifier.MENU, 750, 400, "backbutton"); // Adds a button that changes the gameState to MENU to the help screen

            menu.loadContent(Content); // Loads menu content
            help.loadContent(Content); // Loads help content
            play.loadContent(Content);

            // Could this be done in a better way? 
            // Maybe there shouldn't be any specific states (ex. MenuState or HelpState) but just states?
            manager.addState(stateIdentifier.MENU, menu); // Adds states to manager
            manager.addState(stateIdentifier.HELP, help);
            manager.addState(stateIdentifier.GAME, play);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            manager.update(gameTime.ElapsedGameTime.Milliseconds); // the manager updates the current state

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            manager.draw(spriteBatch); // the manager draws the current state

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
