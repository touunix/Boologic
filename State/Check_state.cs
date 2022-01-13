using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Boologic.Core;
using Boologic.Levels;

namespace Boologic.State
{   
    /// <summary>
    /// Checking current layer
    /// </summary>

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
        private Level_5 level_5 = new Level_5();
        private Level_6 level_6 = new Level_6();
        private Level_7 level_7 = new Level_7();
        private Level_8 level_8 = new Level_8();
        private Level_9 level_9 = new Level_9();
        private Level_10 level_10 = new Level_10();
        private Level_11 level_11 = new Level_11();
        private Level_12 level_12 = new Level_12();


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
            level_5.LoadContent(Content);
            level_6.LoadContent(Content);
            level_7.LoadContent(Content);
            level_8.LoadContent(Content);
            level_9.LoadContent(Content);
            level_10.LoadContent(Content);
            level_11.LoadContent(Content);
            level_12.LoadContent(Content);
        }
    
        public override void Update(GameTime gameTime)
        {
            switch (Settings_file.CurrentState)
            {
                case Settings_file.Layer.Menu_level: //MENU
                    menu.Update(gameTime);
                    break;
                case Settings_file.Layer.Game_level: //GAME
                    game.Update(gameTime);
                    break;
                case Settings_file.Layer.Info_level: //INFO
                    info.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_0: //0
                    level_0.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_1: //1
                    level_1.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_2: //2
                    level_2.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_3: //3
                    level_3.Update(gameTime);
                    break;
                case Settings_file.Layer.Level_4: //4
                    level_4.Update(gameTime);
                    break;               
                case Settings_file.Layer.Level_5: //5
                    level_5.Update(gameTime);
                    break;               
                case Settings_file.Layer.Level_6: //6
                    level_6.Update(gameTime);
                    break;               
                case Settings_file.Layer.Level_7: //7
                    level_7.Update(gameTime);
                    break;               
                case Settings_file.Layer.Level_8: //8
                    level_8.Update(gameTime);
                    break;               
                case Settings_file.Layer.Level_9: //9
                    level_9.Update(gameTime);
                    break;               
                case Settings_file.Layer.Level_10: //10
                    level_10.Update(gameTime);
                    break;               
                case Settings_file.Layer.Level_11: //11
                    level_11.Update(gameTime);
                    break;               
                case Settings_file.Layer.Level_12: //12
                    level_12.Update(gameTime);
                    break;               
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (Settings_file.CurrentState)
            {
                case Settings_file.Layer.Menu_level: //MENU
                    menu.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Game_level: //GAME
                    game.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Info_level: //INFO
                    info.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_0: //0
                    level_0.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_1: //1
                    level_1.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_2: //2
                    level_2.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_3: //3
                    level_3.Draw(spriteBatch);
                    break;
                case Settings_file.Layer.Level_4: //4
                    level_4.Draw(spriteBatch);
                    break;                 
                case Settings_file.Layer.Level_5: //5
                    level_5.Draw(spriteBatch);
                    break;                 
                case Settings_file.Layer.Level_6: //6
                    level_6.Draw(spriteBatch);
                    break;                 
                case Settings_file.Layer.Level_7: //7
                    level_7.Draw(spriteBatch);
                    break;                 
                case Settings_file.Layer.Level_8: //8
                    level_8.Draw(spriteBatch);
                    break;                 
                case Settings_file.Layer.Level_9: //9
                    level_9.Draw(spriteBatch);
                    break;                 
                case Settings_file.Layer.Level_10: //10
                    level_10.Draw(spriteBatch);
                    break;                 
                case Settings_file.Layer.Level_11: //11
                    level_11.Draw(spriteBatch);
                    break;                 
                case Settings_file.Layer.Level_12: //12
                    level_12.Draw(spriteBatch);
                    break;                 
            }
        }
    }
}