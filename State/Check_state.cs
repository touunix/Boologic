using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Boologic.Core;
using Boologic.Levels;

namespace Boologic.State
{
    public class Check_state : MG_abstract
    {
        private Menu_level menu = new Menu_level();
        private Game_level game = new Game_level();
        private Info_level info = new Info_level();
        private Level_0 level_0 = new Level_0();
        private Level_1 level_1 = new Level_1();
        private Level_2 level_2 = new Level_2();
        private Level_3 level_3 = new Level_3();
        private Level_4 level_4 = new Level_4();


        public override void LoadContent(ContentManager Content)
        {
            menu.LoadContent(Content);
            game.LoadContent(Content);
            info.LoadContent(Content);
            level_0.LoadContent(Content);
            level_1.LoadContent(Content);
            level_2.LoadContent(Content);
            level_3.LoadContent(Content);
            level_4.LoadContent(Content);
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
                case Settings_file.Layer.Info_level:
                    info.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_0:
                    level_0.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_1:
                    level_1.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_2:
                    level_2.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_3:
                    level_3.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_4:
                    level_4.Update(gameTime);
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
                case Settings_file.Layer.Info_level:
                    info.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_0:
                    level_0.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_1:
                    level_1.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_2:
                    level_2.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_3:
                    level_3.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_4:
                    level_4.Draw(spriteBatch);
                    break;                 
            }
        }
    }
}