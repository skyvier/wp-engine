using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using FarseerPhysics.Factories;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Common;
using FarseerPhysics.Collision;

namespace wp_engine
{
    class Panda : Character
    {
        public Panda(float x, float y, float framelength, World world) :
            base(x, y, framelength)
        {
            float x_m = x * pixelsToMeters;
            float y_m = y * pixelsToMeters;
            Body tempBody = BodyFactory.CreateBody(world, new Vector2(x_m, y_m));
            tempBody.Mass = 100;
            tempBody.Friction = 1;
            tempBody.Restitution = 0;
        }
    }
}
