using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game2
{
    public class OminoCursori
    {

        Texture2D omino;
        Rectangle drawRectangle;
        Direction currentDirection = Direction.None;
        int xSpeed;
        int ySpeed;

        public int XPosition 
        {
            get { return DrawRectangle.X;}
            set { drawRectangle.X = value; }
        }

        public int YPosition 
        {
            get { return DrawRectangle.Y;}
            set { drawRectangle.Y = value; }
        }



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

        public OminoCursori(Texture2D omino, Rectangle drawRectangle, int xSpeed, int ySpeed)
        {
            this.omino = omino;
            this.drawRectangle = drawRectangle;
            this.drawRectangle.Width = omino.Width;
            this.drawRectangle.Height = omino.Height;
            this.XSpeed = xSpeed;
            this.YSpeed = ySpeed;
        }

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

        public void UpdateDirection(KeyboardState keyBoardState)
        {
            if (keyBoardState.IsKeyDown(Keys.Down))
            {
                ySpeed = 1;
                xSpeed = 0;
            }
            else
            if (keyBoardState.IsKeyDown(Keys.Right))
            {
                ySpeed = 0;
                xSpeed = 1;
            }
            else
            if (keyBoardState.IsKeyDown(Keys.Left))
            {
                ySpeed = 0;
                xSpeed = -1;
            }
            else
            if (keyBoardState.IsKeyDown(Keys.Up))
            {
                ySpeed = -1;
                xSpeed = 0;
            }
            else
            {
                ySpeed = 0;
                xSpeed = 0;
            }

        }


        public void Update()
        {

            drawRectangle.X += xSpeed;
            drawRectangle.Y += YSpeed;
        }
    }

}
