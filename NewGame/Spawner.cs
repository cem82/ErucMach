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
     class Spawner
    {
        public static double timer = 0.5D;
        public static double MaxTime = 1D;
        static Random rand = new Random();

        public static void Update(GameTime gameTime, Texture2D spriteSheet)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                int[] numbers = { 0, 1,2, 3, 4, 5, 6, 7, 8};
                int side = rand.Next(0, numbers.Length);

                switch (side)
                {
                    case 0:
                        Enemy.Enemies.Add(new Enemy(new Vector2(175 - 30, -50), spriteSheet));
                        break;

                    case 1:
                        Enemy.Enemies.Add(new Enemy(new Vector2(450 - 48, -50), spriteSheet));
                        break;

                    case 2:
                        Enemy.Enemies.Add(new Enemy(new Vector2(725 - 48, -50), spriteSheet));
                        break;

                    case 3:
                        Enemy.Enemies1.Add(new Enemy(new Vector2(175 - 30, -50), spriteSheet));
                        break;

                    case 4:
                        Enemy.Enemies1.Add(new Enemy(new Vector2(450 - 48, -50), spriteSheet));
                        break;

                    case 5:
                        Enemy.Enemies2.Add(new Enemy(new Vector2(725 - 48, -50), spriteSheet));
                        break;

                    case 6:
                        Enemy.Enemies2.Add(new Enemy(new Vector2(175 - 30, -50), spriteSheet));
                        break;

                    case 7:
                        Enemy.Enemies2.Add(new Enemy(new Vector2(450 - 48, -50), spriteSheet));
                        break;

                    case 8:
                        Enemy.Enemies2.Add(new Enemy(new Vector2(725 - 48, -50), spriteSheet));
                        break;

                }
                timer = MaxTime;
            }
            if (MaxTime > 0.4)
            {
                MaxTime -= 0.1D;
            }
        }
    }
}
