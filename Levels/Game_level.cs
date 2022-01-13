using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;

namespace Boologic.Levels
{
    /// <summary>
    /// Manages an Game Layer
    /// </summary>

    public class Game_level : MG_abstract
    {
        const int MAX_button = 14;
        private Texture2D[] button = new Texture2D[MAX_button];
        private Rectangle[] button_box = new Rectangle[MAX_button];

        const int MAX_shape = 2;
        private Texture2D[] shape = new Texture2D[MAX_shape];
        private Rectangle[] shape_box = new Rectangle[MAX_shape];

        private MouseState old_mouse_state = new MouseState();
        private Rectangle mouse_box;
        
        SpriteFont gameFont;

        /// <summary>
        /// Section which load content
        /// </summary>

        public override void LoadContent(ContentManager Content)
        {
            gameFont = Content.Load<SpriteFont>("font");

            shape[0] = Content.Load<Texture2D>("logo");
            shape_box[0] = new Rectangle (0, 0, shape[0].Width, shape[0].Height);
            shape[1] = Content.Load<Texture2D>("line");
            shape_box[1] = new Rectangle (0, shape[0].Height, 1024,shape[1].Height);

            int first_column= 35;

            button[0] = Content.Load<Texture2D>("level_button_0"); //LEVEL 0
            button_box[0] = new Rectangle(first_column, shape[0].Height+shape[1].Height+25, button[0].Width, button[0].Height);

            int button_width = button[0].Width;
            int button_height = button[0].Height;

            button[1] = Content.Load<Texture2D>("level_button_1"); //LEVEL 1
            button_box[1] = new Rectangle(first_column, shape[0].Height+shape[1].Height+25+button[0].Height+25, button_width, button_height);
            button[2] = Content.Load<Texture2D>("level_button_2"); //LEVEL 2
            button_box[2] = new Rectangle(first_column, shape[0].Height+shape[1].Height+25+button[0].Height+25+button[1].Height+25, button_width, button_height);
            button[3] = Content.Load<Texture2D>("level_button_3"); //LEVEL 3
            button_box[3] = new Rectangle(first_column, shape[0].Height+shape[1].Height+25+button[0].Height+25+button[1].Height+25+button[2].Height+25, button_width, button_height);

            int second_column = first_column + button_width + 55; 
            button[4] = Content.Load<Texture2D>("level_button_4"); //LEVEL 4
            button_box[4] = new Rectangle(second_column, shape[0].Height+shape[1].Height+25+button[0].Height+25, button_width, button_height);
            button[5] = Content.Load<Texture2D>("level_button_5"); //LEVEL 5
            button_box[5] = new Rectangle(second_column, shape[0].Height+shape[1].Height+25+button[0].Height+25+button[1].Height+25, button_width, button_height);
            button[6] = Content.Load<Texture2D>("level_button_6"); //LEVEL 6
            button_box[6] = new Rectangle(second_column, shape[0].Height+shape[1].Height+25+button[0].Height+25+button[1].Height+25+button[2].Height+25, button_width, button_height);

            int third_column = first_column + button_width + 55 + button_width + 55;
            button[7] = Content.Load<Texture2D>("level_button_7"); //LEVEL 7
            button_box[7] = new Rectangle(third_column, shape[0].Height+shape[1].Height+25+button[0].Height+25, button_width, button_height);
            button[8] = Content.Load<Texture2D>("level_button_8"); //LEVEL 8
            button_box[8] = new Rectangle(third_column, shape[0].Height+shape[1].Height+25+button[0].Height+25+button[1].Height+25, button_width, button_height);
            button[9] = Content.Load<Texture2D>("level_button_9"); //LEVEL 9
            button_box[9] = new Rectangle(third_column, shape[0].Height+shape[1].Height+25+button[0].Height+25+button[1].Height+25+button[2].Height+25, button_width, button_height);

            int fourth_column = first_column + button_width + 55 + button_width + 55 + button_width + 55;
            button[10] = Content.Load<Texture2D>("level_button_10"); //LEVEL 10
            button_box[10] = new Rectangle(fourth_column, shape[0].Height+shape[1].Height+25, button_width, button_height);
            button[11] = Content.Load<Texture2D>("level_button_11"); //LEVEL 11
            button_box[11] = new Rectangle(fourth_column, shape[0].Height+shape[1].Height+25+button[0].Height+25, button_width, button_height);
            button[12] = Content.Load<Texture2D>("level_button_12"); //LEVEL 12
            button_box[12] = new Rectangle(fourth_column, shape[0].Height+shape[1].Height+25+button[0].Height+25+button[1].Height+25, button_width, button_height);
            button[13] = Content.Load<Texture2D>("button4_2"); //BACK
            button_box[13] = new Rectangle(fourth_column, shape[0].Height+shape[1].Height+25+button[0].Height+25+button[1].Height+25+button[2].Height+25, button_width, button_height);
        }
    
        /// <summary>
        /// Section which update content
        /// </summary>

        public override void Update(GameTime gameTime)
        {
            MouseState mouse_state = Mouse.GetState();
            mouse_box = new Rectangle(mouse_state.X,mouse_state.Y,1,1);

            if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_0;     //LEVEL 0
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[1]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_1;     //LEVEL 1
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[2]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_2;     //LEVEL 2
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[3]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_3;     //LEVEL 3
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[4]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_4;     //LEVEL 4
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[5]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_5;     //LEVEL 5
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[6]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_6;     //LEVEL 6
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[7]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_7;     //LEVEL 7
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[8]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_8;     //LEVEL 8
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[9]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_9;     //LEVEL 9
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[10]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_10;     //LEVEL 10
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[11]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_11;     //LEVEL 11
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[12]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_12;     //LEVEL 12
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[13]) && old_mouse_state.LeftButton == ButtonState.Released) 
                Settings_file.CurrentState = Settings_file.Layer.Menu_level;  //BACK
            old_mouse_state = mouse_state;
        }

        /// <summary>
        /// Section which show content
        /// </summary>

        public override void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i<MAX_button; i++)
            {
                spriteBatch.Draw(button[i],button_box[i],Color.White);
                 if(mouse_box.Intersects(button_box[i]))
                    spriteBatch.Draw(button[i],button_box[i],Color.DarkGreen);
            }
            spriteBatch.Draw(shape[0],shape_box[0],Color.White);
            spriteBatch.Draw(shape[1],shape_box[1],Color.White);
            spriteBatch.DrawString(gameFont, " Choose ", new Vector2(325,shape[0].Height+shape[1].Height), Color.LightGray);
            spriteBatch.DrawString(gameFont, " level ", new Vector2(350,shape[0].Height+shape[1].Height+60), Color.LightGray);
        }
    }
}