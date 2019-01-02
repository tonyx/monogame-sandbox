using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game2
{
    class Barra
    {
        Texture2D barra;
        Rectangle drawRectangle;
        int xSpeed;
        int ySpeed;
        int yWindowMargin;
        int xWindowMargin;

        public static int XSpriteRatio = 1;
        public static int YSpriteRatio = 1;

        public int XSpeed
        {
            get { return xSpeed; }
            set { xSpeed = value; }
        }

        public int YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value;}
        }


        public Barra(Texture2D barraSprite, int initXPosition, int initYPosition, int xBoundary, int yBoundary, int initXSpeed, int initYSpeed)
        {
            this.barra = barraSprite;
            this.drawRectangle = new Rectangle();
            this.drawRectangle.Width = barraSprite.Width / XSpriteRatio;
            this.drawRectangle.Height = barraSprite.Height / YSpriteRatio;
            this.drawRectangle.X = initXPosition;
            this.drawRectangle.Y = initYPosition;

            this.XSpeed = initXSpeed;
            this.YSpeed = initYSpeed;

            this.xWindowMargin = xBoundary;
            this.yWindowMargin = yBoundary;
        }




        public Rectangle DrawRectangle
        {
            get { return drawRectangle;}
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barra, drawRectangle, Color.White);

        }


        public void Update()
        {
            drawRectangle.X += xSpeed;
            drawRectangle.Y += YSpeed;

            if (drawRectangle.X >= this.xWindowMargin-this.drawRectangle.Width)
            {
                xSpeed = xSpeed * (-1);
            }

            if (drawRectangle.Y >= this.yWindowMargin-this.drawRectangle.Height)
            {
                ySpeed = ySpeed * (-1);
            }

            if (drawRectangle.Y <= 0)
            {
                ySpeed = ySpeed * (-1);
            }

        }
    }

}
