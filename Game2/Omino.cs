using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Game2
{
    class Omino
    {
        Texture2D omino;
        Rectangle drawRectangle;
        int xSpeed;
        int ySpeed;

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

        public Omino(Texture2D omino, Rectangle drawRectangle, int xSpeed, int ySpeed)
        {
            this.omino = omino;
            this.drawRectangle = drawRectangle;
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


        public void Update()
        {

            drawRectangle.X += xSpeed;
            drawRectangle.Y += YSpeed;

        }
    }


}
