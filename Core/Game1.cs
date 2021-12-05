﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;
using Boologic.State;

namespace Boologic.Core
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        private Check_state state_game;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Settings_file.ScreenWidth;
            graphics.PreferredBackBufferHeight = Settings_file.ScreenHeight;
            graphics.ApplyChanges();
            state_game = new Check_state();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            state_game.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            state_game.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            state_game.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}