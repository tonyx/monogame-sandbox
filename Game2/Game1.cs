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
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ominosprite;
        Rectangle drawRectangle = new Rectangle();
        Rectangle drawRectangleOminoCursori = new Rectangle();

        Omino omino;
        OminoCursori ominoCursori;
        Texture2D barraSprite;
        //Barra barraOggetto;
        List<Barra> barre = new List<Barra>();
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
            ominosprite = Content.Load<Texture2D>("Omino");
            drawRectangle.Height = ominosprite.Height;
            drawRectangle.Width = ominosprite.Width;
            barraSprite = Content.Load<Texture2D>("Barra");


            drawRectangle.X = Globals.SCREEN_WIDTH;
            drawRectangle.Y = Globals.SCREEN_HEIGTH;

            drawRectangleOminoCursori.X = 50;
            drawRectangleOminoCursori.Y = 50;


            drawRectangleBarra.X = 100;
            drawRectangleBarra.Y = 100;

            omino = new Omino(ominosprite, drawRectangle, 1, 1);
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

            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            omino.Update();
            ominoCursori.UpdateDirection(Keyboard.GetState());
            ominoCursori.Update();
            MouseState mouseState = Mouse.GetState();
            int xMousePosition = mouseState.Position.X;
            int yMousePosition = mouseState.Position.Y;

            int xOmino = omino.XCenterPosition;
            int yOmino = omino.YCenterPosition;

            int xAdjustment = (xMousePosition - xOmino) / 50;
            int yAdjustment = (yMousePosition - yOmino) / 50;
            omino.XSpeed = xAdjustment;
            omino.YSpeed = yAdjustment;


            foreach (Barra barra in barre)
            {
                barra.Update();
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
