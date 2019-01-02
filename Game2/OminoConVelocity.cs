using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    public class OminoConVelocity
    {
        Texture2D omino;
        Rectangle drawRectangle;
        int xSpeed;
        int ySpeed;
        Velocity velocity;
        int elapsedTimePassed = 0;

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

        public OminoConVelocity(Texture2D omino, Rectangle drawRectangle, int xSpeed, int ySpeed)
        {
            this.omino = omino;
            this.drawRectangle = drawRectangle;
            this.XSpeed = xSpeed;
            this.YSpeed = ySpeed;
        }

        //public OminoConVelocity(Texture2D omino, Rectangle drawRectangle, int xSpeed, int ySpeed, Velocity velocity)
        //{
        //    this.omino = omino;
        //    this.drawRectangle = drawRectangle;
        //    this.XSpeed = xSpeed;
        //    this.YSpeed = ySpeed;
        //    this.velocity = velocity;
        //}

        public Rectangle DrawRectangle
        {
            get
            {
                return this.drawRectangle;
            }
        }

        public int XCenterPosition
        {
            get
            {
                return this.drawRectangle.X + this.drawRectangle.Width / 2;
            }
        }

        public int YCenterPosition
        {
            get
            {
                return this.drawRectangle.Y + this.drawRectangle.Height / 2;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(omino, drawRectangle, Color.White);

        }

        public void Update()
        {
            drawRectangle.X += xSpeed;
            drawRectangle.Y += YSpeed;
        }

        public void Update(GameTime gameTime)
        {
            drawRectangle.X += xSpeed;
            drawRectangle.Y += YSpeed;
        }
    }
}
