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
    // Robert Foder
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
       

        // pg. 90
        enum GameStates { TitleScreen, Playing, PlayerDead, GameOver };
        //pg. 102
        GameStates gameState = GameStates.Playing;
        Texture2D titleScreen;
        Texture2D spriteSheet;
        //pg. 102
        StarField starField;
         //pg. 110
        AsteroidManager asteroidManager;
         //pg. 125
        PlayerManager playerManager;
         //pg. 138
        EnemyManager enemyManager;
        //pg. 150 declarations
        ExplosionManager explosionManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //pg 90
            titleScreen = Content.Load<Texture2D>(@"TitleScreen");
            spriteSheet = Content.Load<Texture2D>(@"spriteSheet");

           // pg. 103
            starField = new StarField(
                this.Window.ClientBounds.Width,
                this.Window.ClientBounds.Height,
                200,
                new Vector2(0, 30f),
                spriteSheet,
                new Rectangle(0, 450, 2, 2));
            //pg. 110
            asteroidManager = new AsteroidManager(
                10,
                spriteSheet,
                new Rectangle(0, 0, 50, 50),
                20,
                this.Window.ClientBounds.Width,
                this.Window.ClientBounds.Height);
            // pg. 125
            playerManager = new PlayerManager(
                spriteSheet,
                new Rectangle(0, 150, 50, 50),
                3,
                new Rectangle(
                    0,
                    0,
                    this.Window.ClientBounds.Width,
                    this.Window.ClientBounds.Height));
        
            //pg. 138
            enemyManager = new EnemyManager(
                spriteSheet,
                new Rectangle(0, 200, 50, 50),
                6,
                playerManager,
                new Rectangle(
                    0,
                    0,
                this.Window.ClientBounds.Width,
                this.Window.ClientBounds.Height));
            //pg. 150 loadcontent
            explosionManager = new ExplosionManager(
                spriteSheet,
                new Rectangle(0, 100, 50, 50),
                3,
                new Rectangle(0, 450, 2, 2));
                    
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            // pg. 90
            switch (gameState)
            {
                case GameStates.TitleScreen:
                    break;

                case GameStates.Playing:
                    //pg. 103
                    starField.Update(gameTime);
                    //pg.111
                    asteroidManager.Update(gameTime);
                    //pg. 125
                    playerManager.Update(gameTime);
                    //pg. 138
                    enemyManager.Update(gameTime);
                    //pg. 150 update
                    explosionManager.Update(gameTime);
                    
                    break;

                case GameStates.PlayerDead:
                    break;

                case GameStates.GameOver:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        { 
            //pg. 103
            GraphicsDevice.Clear(Color.Black);
            // pg 90
            spriteBatch.Begin();

            if (gameState == GameStates.TitleScreen)
            {
                spriteBatch.Draw(titleScreen,
                    new Rectangle(0, 0, this.Window.ClientBounds.Width,
                        this.Window.ClientBounds.Height),
                        Color.White);
            }

            if ((gameState == GameStates.Playing) ||
                (gameState == GameStates.PlayerDead) ||
                (gameState == GameStates.GameOver))
            {
                //pg. 103
                starField.Draw(spriteBatch);
                //pg. 111
                asteroidManager.Draw(spriteBatch);
                //pg. 125
                playerManager.Draw(spriteBatch);
                //pg. 138
                enemyManager.Draw(spriteBatch);
                //pg. 150 draw
                explosionManager.Draw(spriteBatch);
            }

            if ((gameState == GameStates.GameOver))
            {
            }

            spriteBatch.End();

            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
