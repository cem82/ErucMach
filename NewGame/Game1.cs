using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace NewGame
{

    public static class MySound
    {
        public static SoundEffect Shoot;
        public static SoundEffect Hit;
        public static SoundEffect Explosion;
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        Texture2D Character;
        Texture2D Bullet;
        static Texture2D Astreoid;
        static Texture2D Astreoid1;
        static Texture2D Astreoid2;
        Texture2D Astreoids;
        Vector2 pos;
        Texture2D Background;
        Texture2D c;
        Texture2D z;
        Texture2D x;
        public static double timer = 0.1D;
        public static double MaxTime = 0.1D;
        public static double Hittimer = 5D;
        public static double MaxHitTime = 5D;
        bool isHitting = false;
        bool Enemy1Hit = false;
        bool Enemy2Hit = false;
        bool Enemy3Hit = false;
    
        bool CKeyRelease = true;
        bool CKeyPressing = false;
        bool ZKeyRelease = true;
        bool ZKeyPressing = false;

        KeyboardState oldKstate = Keyboard.GetState();


        public bool isDead = true;

        public static int score;
        SpriteFont scoreFont;
        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth = 900;
            Graphics.PreferredBackBufferHeight = 900;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pos = new Vector2(450, Graphics.PreferredBackBufferHeight - 80);
            Window.Title = "ErucMach";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Character = Content.Load<Texture2D>("RocketsTest");
            Bullet = Content.Load<Texture2D>("NewBullet");
            Background = Content.Load<Texture2D>("Background1");
            Astreoid = Content.Load<Texture2D>("Astreoid1");
            Astreoid1 = Content.Load<Texture2D>("Astreoid3");
            Astreoid2 = Content.Load<Texture2D>("Astreoid2");
            c = Content.Load<Texture2D>("C2");
            x = Content.Load<Texture2D>("X2");
            z = Content.Load<Texture2D>("z2");
            scoreFont = Content.Load<SpriteFont>("galleryFont");


            MySound.Shoot = Content.Load<SoundEffect>("Sounds/Laser_Shoot7");
            MySound.Hit = Content.Load<SoundEffect>("Sounds/Hit_Hurt");
            MySound.Explosion = Content.Load<SoundEffect>("Sounds/Explosion2");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var mstate = Mouse.GetState();
            var kstate = Keyboard.GetState();
            var moveValue = 275;
            Random rand = new Random();
            int[] numbers = { 0, 1, 2, };
            int side = rand.Next(0, numbers.Length);

            switch (side)
            {
                case 0:
                    Astreoids = Astreoid;
                    break;
                case 1:
                    Astreoids = Astreoid1;
                    break;
                case 2:
                    Astreoids = Astreoid2;
                    break;
            }

            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (kstate.IsKeyDown(Keys.C) && CKeyPressing == false && CKeyRelease == true && ZKeyPressing == false && ZKeyRelease == true)
            {
                pos.X += moveValue;


                MySound.Hit.Play();

                CKeyRelease = false;
                CKeyPressing = true;

                if (isDead)
                {
                    isDead = false;
                }
            }

            if (kstate.IsKeyDown(Keys.Z) && CKeyPressing == false && CKeyRelease == true && ZKeyPressing == false && ZKeyRelease == true)
            {
                pos.X -= moveValue;
                MySound.Hit.Play();
                ZKeyRelease = false;
                ZKeyPressing = true;
                if (isDead)
                {
                    isDead = false;
                }
            }
            if (kstate.IsKeyUp(Keys.Z))
            {
                ZKeyRelease = true;
                ZKeyPressing = false;
            }
            if (kstate.IsKeyUp(Keys.C))
            {
                CKeyRelease = true;
                CKeyPressing = false;
            }

            if (isDead == false)
            {
                Spawner.Update(gameTime, Astreoids);
            }

            foreach (Projectiles proj in Projectiles.projectiles)
            {
                proj.Update(gameTime, isDead);

                if (proj.Position.Y > Graphics.PreferredBackBufferHeight || proj.Position.Y < 0)
                {
                    proj.Collided = true;
                }
            }

            foreach (Enemy enem in Enemy.Enemies)
            {
                enem.EnemyUpdate(gameTime, isDead);
                int sum = 64 + enem.radius;
                if (Vector2.Distance(pos, enem.Position) < sum)
                {
                    isDead = true;
                    pos = new Vector2(450, Graphics.PreferredBackBufferHeight - 80);
                    score = 0;
                    MySound.Explosion.Play();

                }

                if (enem.Position.Y > Graphics.PreferredBackBufferHeight)
                {
                    enem.Dead = true;
                    if (score > 0)
                    {
                        score--;
                    }
                }

            }
            foreach (Enemy enem in Enemy.Enemies1)
            {
                enem.EnemyUpdate(gameTime, isDead);
                int sum = 64 + enem.radius;
                if (Vector2.Distance(pos, enem.Position) < sum)
                {
                    isDead = true;
                    pos = new Vector2(450, Graphics.PreferredBackBufferHeight - 80);
                    score = 0;
                    MySound.Explosion.Play();

                }
                if (enem.Position.Y > Graphics.PreferredBackBufferHeight)
                {
                    enem.Dead = true;

                    if (score > 0)
                    {
                        score--;
                    }
                }
            }
            foreach (Enemy enem in Enemy.Enemies2)
            {
                enem.EnemyUpdate(gameTime, isDead);
                int sum = 64 + enem.radius;
                if (Vector2.Distance(pos, enem.Position) < sum)
                {
                    isDead = true;
                    pos = new Vector2(450, Graphics.PreferredBackBufferHeight - 80);
                    score = 0;
                    MySound.Explosion.Play();

                }
                if (enem.Position.Y > Graphics.PreferredBackBufferHeight)
                {
                    enem.Dead = true;
                    if (score > 0)
                    {
                        score--;
                    }
                }
            }

            if (Hittimer <= 0)
            {
                isHitting = false;
                Hittimer = MaxHitTime;
            }


            if (isDead && oldKstate.IsKeyUp(Keys.X) && kstate.IsKeyDown(Keys.X))
            {
                isDead = false;
                isHitting = false;
            }
            oldKstate = kstate;

            if (kstate.IsKeyDown(Keys.X) && timer <= 0 && !isDead)
            {
                Projectiles.projectiles.Add(new Projectiles(pos));
                timer = MaxTime;

                foreach (Projectiles proj in Projectiles.projectiles)
                {
                    if (proj.Collided == true)
                    {
                        isHitting = true;
                        Hittimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }

                }

                if (isHitting == false)
                {
                    MySound.Shoot.Play(0.6f, 0.1f, 0f);
                }

            }

            if (pos.X > 600)
            {
                pos.X = Graphics.PreferredBackBufferWidth - 90 * 2;
            }
            else if (pos.X < 300)
            {
                pos.X = 90 * 2;
            }

            foreach (Projectiles proj in Projectiles.projectiles)
            {
                foreach (Enemy enem in Enemy.Enemies)
                {
                    int sum = enem.radius + proj.radius;
                    if (Vector2.Distance(proj.Position, enem.Position) < sum)
                    {
                        Enemy1Hit = true;
                        proj.Collided = true;
                        enem.health--;
                        if (Enemy2Hit == false && Enemy3Hit == false)
                        {
                            MySound.Hit.Play(0.2f, 1f, 0f);
                        }

                    }
                    else
                    {
                        Enemy1Hit = false;
                    }

                }
                foreach (Enemy enem in Enemy.Enemies1)
                {
                    int sum = enem.radius + proj.radius;
                    if (Vector2.Distance(proj.Position, enem.Position) < sum)
                    {
                        Enemy2Hit = true;
                        proj.Collided = true;
                        enem.health--;
                        if (Enemy1Hit == false && Enemy3Hit == false)
                        {
                            MySound.Hit.Play(0.2f, 1f, 0f);
                        }

                    }
                    else
                    {
                        Enemy2Hit = false;
                    }

                }
                foreach (Enemy enem in Enemy.Enemies2)
                {
                    int sum = enem.radius + proj.radius;
                    if (Vector2.Distance(proj.Position, enem.Position) < sum)
                    {
                        Enemy3Hit = true;
                        proj.Collided = true;
                        enem.health--;
                        if (Enemy2Hit == false && Enemy1Hit == false)
                        {
                            MySound.Hit.Play(0.2f, 1f, 0f);
                        }

                    }
                    else
                    {
                        Enemy3Hit = false;
                    }
                }
            }

            Projectiles.projectiles.RemoveAll(p => p.Collided);
            Enemy.Enemies.RemoveAll(e => e.Dead);
            Enemy.Enemies1.RemoveAll(e => e.Dead);
            Enemy.Enemies2.RemoveAll(e => e.Dead);

            Projectiles.projectiles.RemoveAll(p => p.PlayerDead);
            Enemy.Enemies.RemoveAll(e => e.DeadPlayer);
            Enemy.Enemies1.RemoveAll(e => e.DeadPlayer);
            Enemy.Enemies2.RemoveAll(e => e.DeadPlayer);



            // TODO: Add your update logic here
            base.Update(gameTime);

        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            SpriteBatch.Draw(Background, new Rectangle(0, 0, 900, 900), new Rectangle(0, 0, 320, 180), Color.White);

            foreach (Projectiles proj in Projectiles.projectiles)
            {
                SpriteBatch.Draw(Bullet, new Vector2(proj.Position.X, proj.Position.Y - 48), null, Color.White, 0f, new Vector2(Character.Height / 2, Character.Width / 2), new Vector2(5, 5), SpriteEffects.None, 0f);
            }
            foreach (Enemy enem in Enemy.Enemies)
            {
                SpriteBatch.Draw(Astreoid, new Vector2(enem.Position.X, enem.Position.Y), null, Color.White, 0f, new Vector2(Character.Height / 2 - 7, Character.Width / 2), new Vector2(7, 7), SpriteEffects.None, 0f);
            }
            foreach (Enemy enem in Enemy.Enemies1)
            {
                SpriteBatch.Draw(Astreoid1, new Vector2(enem.Position.X, enem.Position.Y), null, Color.White, 0f, new Vector2(Character.Height / 2 - 7, Character.Width / 2), new Vector2(7, 7), SpriteEffects.None, 0f);
            }
            foreach (Enemy enem in Enemy.Enemies2)
            {
                SpriteBatch.Draw(Astreoid2, new Vector2(enem.Position.X, enem.Position.Y), null, Color.White, 0f, new Vector2(Character.Height / 2 - 7, Character.Width / 2), new Vector2(7, 7), SpriteEffects.None, 0f);
            }

            SpriteBatch.Draw(Character, pos, null, Color.White, 0f, new Vector2(Character.Height / 2, Character.Width / 2), new Vector2(8, 8), SpriteEffects.None, 0f);

            if (isDead)
            {

                SpriteBatch.Draw(x, new Vector2(pos.X, pos.Y - 256), null, Color.White, 0f, new Vector2(Character.Height / 2, Character.Width / 2), new Vector2(10, 10), SpriteEffects.None, 0f);
                SpriteBatch.Draw(z, new Vector2(175 + 48, pos.Y - 256), null, Color.White, 0f, new Vector2(Character.Height / 2, Character.Width / 2), new Vector2(10, 10), SpriteEffects.None, 0f);
                SpriteBatch.Draw(c, new Vector2(725 - 48, pos.Y - 256), null, Color.White, 0f, new Vector2(Character.Height / 2, Character.Width / 2), new Vector2(10, 10), SpriteEffects.None, 0f);
            }

            SpriteBatch.DrawString(scoreFont, score.ToString(), new Vector2(Graphics.PreferredBackBufferWidth / 2 - 8, 3), Color.LightSkyBlue);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}