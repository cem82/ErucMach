using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NewGame
{
     class Projectiles
    {
        public static List<Projectiles> projectiles = new List<Projectiles>();
        Vector2 position;
        public int speed = 1000;
        public int radius = 40;
        bool isCollided = false;
        public bool PlayerDead;

        public Projectiles(Vector2 newPos)
        {
            position = newPos;
        }

        public Vector2 Position
        {
            get { return position; }
        }
        public bool Collided
        {
            get
            {
                return isCollided;
            }
            set
            {
                isCollided = value;
            }
        }

        public void Update(GameTime gameTime, bool PlayerIsDead)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(!PlayerIsDead)
            {
                position.Y -= speed * dt;
                PlayerDead = false;
            } 
            else
            {
                PlayerDead = true;
            }

        }
    }
}

