using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Boologic.Core;
using Boologic.Levels;

namespace Boologic.State
{
    public class Check_state : MG_abstract
    {
        private Menu_level menu = new Menu_level();
        private Game_level game = new Game_level();
        public override void LoadContent(ContentManager Content)
        {
            menu.LoadContent(Content);
            game.LoadContent(Content);
        }
    
        public override void Update(GameTime gameTime)
        {
            switch (Settings_file.CurrentState)
            {
                case Settings_file.Layer.Menu_level:
                    menu.Update(gameTime);
                    break;
                case Settings_file.Layer.Game_level:
                    game.Update(gameTime);
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (Settings_file.CurrentState)
            {
                case Settings_file.Layer.Menu_level:
                    menu.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Game_level:
                    game.Draw(spriteBatch);
                    break;
            }
        }
    }
}