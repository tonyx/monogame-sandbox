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
    public class BarraOrizzontale : Subject
    {

        private List<Observer> observers = new List<Observer>();
        private Velocity xVelocity = new Velocity(1,16);

        private const int MILLISECONDS_FOR_MOVING_ONE_PIXEL_Y = 1;
        private const int MILLISECONDS_FOR_MOVING_ONE_PIXEL_X = Int32.MaxValue;
        private int elapsedGameTimeXMilliSecondTime = 0;
        private int elapsedGameTimeYMilliSecondTime = 0;

        int xDir = 0; 
        int yDir = 1; 

        Texture2D barra;
        Rectangle drawRectangle;
        int xSpeed;
        int ySpeed;
        int yWindowMargin;
        int xWindowMargin;

        public static int XSpriteRatio = 1;
        public static int YSpriteRatio = 1;

        public void RegisterObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            //Console.Out.WriteLine("enteed in notifyobservers");
            foreach (Observer observer in observers)
            {
                observer.ObserverUpdate(this.DrawRectangle.Y);
                //observer.ObserverUpdate(100);
            }
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

        public BarraOrizzontale(Texture2D barraSprite, int initXPosition, int initYPosition, int xBoundary, int yBoundary, int initXSpeed, int initYSpeed)
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
            get { return drawRectangle; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barra, drawRectangle, Color.White);
        }

        public void Update()
        {
            //Console.Out.WriteLine("entered in update");
            drawRectangle.X += xSpeed;
            drawRectangle.Y += YSpeed;

            if (drawRectangle.X >= this.xWindowMargin - this.drawRectangle.Width)
            {
                xSpeed = xSpeed * (-1);
            }

            if (drawRectangle.Y >= this.yWindowMargin - this.drawRectangle.Height)
            {
                ySpeed = ySpeed * (-1);
            }

            if (drawRectangle.Y <= Globals.HORIZONTAL_BAR_UPPER_MARGIN)
            {
                ySpeed = ySpeed * (-1);
            }
            NotifyObservers();
        }

        public void Update(GameTime gameTime)
        {

            //Console.Out.WriteLine("update");
            elapsedGameTimeXMilliSecondTime += gameTime.ElapsedGameTime.Milliseconds;
            elapsedGameTimeYMilliSecondTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedGameTimeXMilliSecondTime >= MILLISECONDS_FOR_MOVING_ONE_PIXEL_X)
            {
                drawRectangle.X += xDir;
                elapsedGameTimeXMilliSecondTime = 0;
            }

            if (elapsedGameTimeYMilliSecondTime >= MILLISECONDS_FOR_MOVING_ONE_PIXEL_Y)
            {
                //Console.Out.WriteLine(elapsedGameTimeYMilliSecondTime);
                drawRectangle.Y += yDir;
                elapsedGameTimeYMilliSecondTime = 0;
            }

            NotifyObservers();
            Bounce();
        }


        private void Bounce()
        {
            if (drawRectangle.X >= this.xWindowMargin - this.drawRectangle.Width)

            {
                xDir = xDir * (-1);
            }

            if (drawRectangle.Y >= this.yWindowMargin - this.drawRectangle.Height)

            {
                yDir = yDir * (-1);
            }

            if (drawRectangle.Y <= Globals.HORIZONTAL_BAR_UPPER_MARGIN)

            {
                yDir = yDir * (-1);
            }

        }

    }
}
