using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace AsteroidAssault
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class StarField : Microsoft.Xna.Framework.GameComponent
    {
        // pg. 101
        private List<Sprite> stars = new List<Sprite>();
        private int screenWidth = 800;
        private int screenHeight = 600;
        private Random rand = new Random();
        private Color[] colors = { Color.White, Color.Yellow,
                                     Color.Wheat, Color.WhiteSmoke,
                                     Color.SlateGray };
        public StarField(
            int screenWidth,
            int screenHeight,
            int starCount,
            Vector2 starVelocity,
            Texture2D texture,
            Rectangle frameRectangle)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            for (int x = 0; x < starCount; x++)
            {

                stars.Add(new Sprite(
                    new Vector2(rand.Next(0, screenWidth),
                        rand.Next(0,screenHeight)),
                        texture,
                        frameRectangle,
                        starVelocity));
                Color starColor = colors[rand.Next(0, colors.Count())];
                starColor *= (float)(rand.Next(30, 80) / 100f);
                stars[stars.Count() - 1].TintColor = starColor;
            }
        }
        // pg. 102
        public void Update(GameTime gameTime)
        {
            foreach (Sprite star in stars)
            {
                star.Update(gameTime);
                if (star.Location.Y > screenHeight)
                {
                    star.Location = new Vector2(
                    rand.Next(0, screenWidth), 0);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite star in stars)
            {
                star.Draw(spriteBatch);
            }
        }
    }

}
   
    

