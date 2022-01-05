using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;

namespace Boologic.Levels
{
    public class Game_level : MG_abstract
    {
        const int MAX_button = 6;
        private Texture2D[] button = new Texture2D[MAX_button];
        private Rectangle[] button_box = new Rectangle[MAX_button];

        const int MAX_shape = 2;
        private Texture2D[] shape = new Texture2D[MAX_shape];
        private Rectangle[] shape_box = new Rectangle[MAX_shape];

        private MouseState old_mouse_state = new MouseState();
        private Rectangle mouse_box;
        
        public override void LoadContent(ContentManager Content)
        {
            shape[0] = Content.Load<Texture2D>("logo");
            shape_box[0] = new Rectangle (0, 0, shape[0].Width, shape[0].Height);
            shape[1] = Content.Load<Texture2D>("line");
            shape_box[1] = new Rectangle (0, shape[0].Height, 1024,shape[1].Height);

            button[0] = Content.Load<Texture2D>("level_button_0"); //LEVEL 0
            button_box[0] = new Rectangle(56, shape[0].Height+shape[1].Height+40, button[0].Width, button[0].Height);
            button[1] = Content.Load<Texture2D>("level_button_1"); //LEVEL 1
            button_box[1] = new Rectangle(56, shape[0].Height+shape[1].Height+40+button[0].Height+40, button[1].Width, button[1].Height);
            button[2] = Content.Load<Texture2D>("level_button_2"); //LEVEL 2
            button_box[2] = new Rectangle(56, shape[0].Height+shape[1].Height+40+button[0].Height+40+button[1].Height+40, button[2].Width, button[2].Height);
            button[3] = Content.Load<Texture2D>("level_button_3"); //LEVEL 3
            button_box[3] = new Rectangle(56+button[0].Width+224, shape[0].Height+shape[1].Height+40, button[3].Width, button[3].Height);
            button[4] = Content.Load<Texture2D>("level_button_4"); //LEVEL 4
            button_box[4] = new Rectangle(56+button[0].Width+224, shape[0].Height+shape[1].Height+40+button[0].Height+40, button[4].Width, button[4].Height);
            button[5] = Content.Load<Texture2D>("button4_2");      //BACK
            button_box[5] = new Rectangle(56+button[0].Width+224+50, shape[0].Height+shape[1].Height+40+button[0].Height+40+button[1].Height+40, button[5].Width, button[5].Height);
        }
    
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
            else if (mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[5]) && old_mouse_state.LeftButton == ButtonState.Released) 
                Settings_file.CurrentState = Settings_file.Layer.Menu_level;  //BACK 
            old_mouse_state = mouse_state;
        }

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
        }
    }
}