using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    enum Direction { Up, Down, Left, Right, None };
    struct Velocity { 
        int pixels; 
        int milliseconds;
        public Velocity(int pixels, int milliSeconds)
        {
            this.pixels = pixels;
            this.milliseconds = milliSeconds;
        }
        public int Pixels
        {
            get { return pixels;}
            set { this.pixels = value;}
        }
        public int Milliseconds
        {
            get { return milliseconds;}
            set { this.milliseconds = value;}
        }
    };


    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ominosprite;
        Rectangle drawRectangle = new Rectangle();
        Rectangle drawRectangleOminoCursori = new Rectangle();
        SpriteFont spriteFont;

        Omino omino;
        OminoCursori ominoCursori;
        Texture2D barraSprite;
        Texture2D barraOrizzontaleSprite;
        //Barra barraOggetto;
        List<Barra> barre = new List<Barra>();
        List<BarraOrizzontale> barreOrizzontali = new List<BarraOrizzontale>();

        Random rand = new Random(System.DateTime.Now.Millisecond);

        Rectangle drawRectangleBarra = new Rectangle();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            graphics.PreferredBackBufferHeight = Globals.SCREEN_HEIGTH;
            graphics.PreferredBackBufferWidth = Globals.SCREEN_WIDTH;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //ominosprite = Content.Load<Texture2D>("Omino");
            ominosprite = Content.Load<Texture2D>("mario2");
            drawRectangle.Height = ominosprite.Height;
            drawRectangle.Width = ominosprite.Width;
            //barraSprite = Content.Load<Texture2D>("Barra");
            barraSprite = Content.Load<Texture2D>("barra2");
            barraOrizzontaleSprite = Content.Load<Texture2D>("barra_orizzontale");

            spriteFont = Content.Load<SpriteFont>("Arial_12");


            drawRectangle.X = 20;
            drawRectangle.Y = 20;

            drawRectangleOminoCursori.X = 50;
            drawRectangleOminoCursori.Y = 50;

            drawRectangleBarra.X = 100;
            drawRectangleBarra.Y = 100;

            //omino = new Omino(ominosprite, drawRectangle, 0, 0);
            Vector2 ominoDirection = new Vector2((float)1000, (float)1000);


            omino = new Omino(ominosprite, drawRectangle, ominoDirection,(float)0.1);

            ominoCursori = new OminoCursori(ominosprite, drawRectangleOminoCursori, 0, 0);

            //barraOggetto = new Barra(barra, drawRectangleBarra, 100, 100);

            for (int i = 0; i < Globals.NUMBER_OF_BARS; i++)
            {
                barre.Add(new Barra(barraSprite,  
                                    //rand.Next(graphics.PreferredBackBufferWidth-(barraSprite.Width/Barra.XSpriteRatio)),
                                    Globals.BAR_X_POSITIONS[i],
                                    rand.Next(graphics.PreferredBackBufferHeight-(barraSprite.Height/Barra.YSpriteRatio)),

                                    graphics.PreferredBackBufferWidth,
                                    graphics.PreferredBackBufferHeight,
                                    Globals.BAR_X_SPEED,
                                    Globals.BAR_Y_SPEED
                                   
                                   ));
            }

            var firstBar = new BarraOrizzontale(barraOrizzontaleSprite,
                                    //rand.Next(graphics.PreferredBackBufferWidth-(barraSprite.Width/Barra.XSpriteRatio)),
                                    Globals.HORIZONTAL_BAR_X_POSITIONS[0],
                                                          rand.Next(Globals.HORIZONTAL_BAR_UPPER_MARGIN, graphics.PreferredBackBufferHeight - (barraOrizzontaleSprite.Height / Barra.YSpriteRatio)),

                                    graphics.PreferredBackBufferWidth,
                                    graphics.PreferredBackBufferHeight,
                                    Globals.HORIZONTAL_BAR_X_SPEED,
                                    Globals.HORIZONTAL_BAR_Y_SPEED
                            );
            firstBar.RegisterObserver(ominoCursori);

            barreOrizzontali.Add(firstBar);



            for (int i = 1; i < Globals.NUMBER_OF_HORIZONTAL_BARS; i++)
            {
                barreOrizzontali.Add( new BarraOrizzontale(barraOrizzontaleSprite,  
                                    //rand.Next(graphics.PreferredBackBufferWidth-(barraSprite.Width/Barra.XSpriteRatio)),
                                    Globals.HORIZONTAL_BAR_X_POSITIONS[i],
                                                          rand.Next(Globals.HORIZONTAL_BAR_UPPER_MARGIN,graphics.PreferredBackBufferHeight-(barraOrizzontaleSprite.Height/Barra.YSpriteRatio)),

                                    graphics.PreferredBackBufferWidth,
                                    graphics.PreferredBackBufferHeight,
                                    Globals.HORIZONTAL_BAR_X_SPEED,
                                    Globals.HORIZONTAL_BAR_Y_SPEED
                                   
                                   ));
            }




            // TODO: use this.Content to load your game content here
            //spriteBatch.DrawString(spriteFont, "score", new Vector2(5, 5), Color.White);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //omino.Update();

            omino.Update(gameTime);

            ominoCursori.UpdateDirection(Keyboard.GetState());
            ominoCursori.Update();
            MouseState mouseState = Mouse.GetState();


            //int xMousePosition = mouseState.Position.X;
            //int yMousePosition = mouseState.Position.Y;

            //int xOmino = omino.XCenterPosition;
            //int yOmino = omino.YCenterPosition;

            //int xAdjustment = (xMousePosition - xOmino) / 50;
            //int yAdjustment = (yMousePosition - yOmino) / 50;
            //omino.XSpeed = xAdjustment;
            //omino.YSpeed = yAdjustment;



            //omino.Update(gameTime);


            foreach (Barra barra in barre)
            {
                barra.Update();
            }   

            foreach (BarraOrizzontale barra in barreOrizzontali)
            {
                //barra.Update();
                barra.Update(gameTime);
            }   


            if (DetectCollision(ominoCursori, barre)) {
                ominoCursori.XPosition = 1;
                ominoCursori.YPosition = 1;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {


            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // TODO: Add your drawing code here

            //            spriteBatch.Draw(barra, drawRectangleBarra, Color.White);
            omino.Draw(spriteBatch);
            ominoCursori.Draw(spriteBatch);
            //barraOggetto.Draw(spriteBatch);

            foreach (Barra barra in barre)
            {
                barra.Draw(spriteBatch);
            }

            foreach (BarraOrizzontale barra in barreOrizzontali)
            {
                barra.Draw(spriteBatch);
            }

            spriteBatch.DrawString(spriteFont, "score", new Vector2(5, 5), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);


        }

        private bool DetectCollision(OminoCursori ominoCursori, List<Barra> barre)
        {
            foreach (Barra barra in barre)
            {
                if (barra.DrawRectangle.Intersects(ominoCursori.DrawRectangle))
                    return true;
            }
            return false;
        }

    }

}
