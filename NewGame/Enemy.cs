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
    
    class Enemy
    {
        public static List<Enemy> Enemies = new List<Enemy>();
        public static List<Enemy> Enemies1 = new List<Enemy>();
        public static List<Enemy> Enemies2 = new List<Enemy>();

        Vector2 pos = new Vector2(0, 0);
        public float speed = 250;
        public int radius = 30;
        public int health = 3;
        bool isDead = false;
        public bool DeadPlayer;
        double timer = 0.1;
        double MaxTime = 0.1;
        public Enemy(Vector2 newPos, Texture2D spriteSheet)
        {
            pos = newPos;
        }


        public void EnemyUpdate(GameTime gameTime , bool PlayerIsDead)
        {
            if(health <= 0)
            {
                Dead = true;
                Game1.score++;
            }
            if (!PlayerIsDead)
            { 
            pos.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                DeadPlayer = false;
            } else
            {
                timer--;

                if(timer <= 0)
                {
                    DeadPlayer = true;
                    timer = MaxTime;
                }
            }

           if(speed < 800)
            {
                speed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            } 
            
        }
        public Vector2 Position
        {
            get
            {
                return pos;
            }
        }

        public bool Dead
        {
            get
            {
                return isDead;
            }
            set
            {
                isDead = value;
            }
        }
    }
}
        


