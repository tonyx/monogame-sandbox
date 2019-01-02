using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;



namespace Game2
{
    class Omino
    {
        Texture2D omino;
        Rectangle drawRectangle;
        int xSpeed;
        int ySpeed;
        Vector2 direction;
        float speed;

        Vector2 currentPosition;

        public int XSpeed
        {
            get { return xSpeed; }
            set { xSpeed = value; }
        }

        public int YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value; }
        }


        //public Omino(Texture2D omino, Rectangle drawRectangle, int xSpeed, int ySpeed)
        //{
        //    this.omino = omino;
        //    this.drawRectangle = drawRectangle;
        //    this.XSpeed = xSpeed;
        //    this.YSpeed = ySpeed;
        //}

        public Omino(Texture2D omino, Rectangle drawRectangle, Vector2 direction, float speed) 
        {
            this.omino = omino;
            this.drawRectangle = drawRectangle;
            this.direction = direction;
            this.direction.Normalize();

            Console.Out.WriteLine(this.direction.X);

            this.direction.X *= speed;
            this.direction.Y *= speed;

            Console.Out.WriteLine(this.direction.X);
            Console.Out.WriteLine(this.direction.Y);

            this.speed = speed;
            this.currentPosition.X = drawRectangle.X;
            this.currentPosition.Y = drawRectangle.Y;
        }

        public Rectangle DrawRectangle
        {
            get
            {
                return this.drawRectangle;
            }
        }

        public int XCenterPosition {
            get {
                return this.drawRectangle.X + this.drawRectangle.Width / 2;
            }
        }

        public int YCenterPosition {
            get {
                return this.drawRectangle.Y + this.drawRectangle.Height / 2;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(omino, drawRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Console.Out.WriteLine(currentPosition.X);
            currentPosition.X = currentPosition.X + (((float)(gameTime.ElapsedGameTime.Milliseconds))*this.direction.X);
            currentPosition.Y = currentPosition.Y + (((float)(gameTime.ElapsedGameTime.Milliseconds))*this.direction.Y);
            //Console.Out.WriteLine(currentPosition.X);


            drawRectangle.X = (int)Math.Round(currentPosition.X);
            drawRectangle.Y = (int)Math.Round(currentPosition.Y);


        }


        public void Update()
        {
            drawRectangle.X += xSpeed;
            drawRectangle.Y += YSpeed;
        }
    }


}
