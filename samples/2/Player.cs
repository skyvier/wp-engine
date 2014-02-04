using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;
using FarseerPhysics.Factories;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;

namespace wp_engine
{
    class Player
    {
        protected Character model;

        public Player(Character model)
        {
            this.model = model;

            model.Speed = new Vector2(2, 0);
        }

        public void update(float elapsed)
        {
            deaccelerate();
            model.update(elapsed);
        }

        public void draw(SpriteBatch sb)
        {
            model.draw(sb);
        }

        private void move(Vector2 speed)
        {
            model.Speed = speed;
        }

        private void stop()
        {
            model.Speed = new Vector2(0, 0);
        }

        private void deaccelerate()
        {
            float modela = model.Acceleration.X;
            if (modela > 0)
            {
                model.Acceleration = new Vector2(modela-1, 0);
            }
            else if (modela < 0)
            {
                model.Acceleration = new Vector2(modela + 1, 0);
            }
        }

        public void handleEvent(Event recentEvent)
        {
            switch (recentEvent.getType())
            {
                case GestureType.HorizontalDrag:
                    if (recentEvent.getVector().X > 0)
                    {
                        model.Acceleration = new Vector2(2, 0);
                    }
                    else
                    {
                        model.Acceleration = new Vector2(-2, 0);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
