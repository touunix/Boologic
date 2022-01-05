using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;

namespace Boologic.Levels
{
    public class Menu_level : MG_abstract
    {
        const int MAX_button = 3;
        private Texture2D[] button = new Texture2D[MAX_button];
        private Rectangle[] button_box = new Rectangle[MAX_button];

        const int MAX_shape = 8;
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
            shape[2] = Content.Load<Texture2D>("background");
            shape_box[2] = new Rectangle (0, shape[0].Height+shape[1].Height, 329, shape[2].Height);
            shape[3] = Content.Load<Texture2D>("background");
            shape_box[3] = new Rectangle (0, shape[0].Height+shape[1].Height+shape[2].Height, 329, shape[2].Height);
            shape[4] = Content.Load<Texture2D>("background");
            shape_box[4] = new Rectangle (0, shape[0].Height+shape[1].Height+shape[2].Height+shape[3].Height, 329, shape[2].Height);
            shape[5] = Content.Load<Texture2D>("background");
            shape_box[5] = new Rectangle (329+367, shape[0].Height+shape[1].Height, 329, shape[2].Height);
            shape[6] = Content.Load<Texture2D>("background");
            shape_box[6] = new Rectangle (329+367, shape[0].Height+shape[1].Height+shape[2].Height, 329, shape[2].Height);
            shape[7] = Content.Load<Texture2D>("background");
            shape_box[7] = new Rectangle (329+367, shape[0].Height+shape[1].Height+shape[2].Height+shape[3].Height, 329, shape[2].Height);

            button[0] = Content.Load<Texture2D>("button1"); //START
            button_box[0] = new Rectangle(329, shape[0].Height+shape[1].Height+40, button[0].Width, button[0].Height);
            button[1] = Content.Load<Texture2D>("button2"); //INFO
            button_box[1] = new Rectangle(373, shape[0].Height+shape[1].Height+40+button[0].Height+40, button[1].Width, button[1].Height);
            button[2] = Content.Load<Texture2D>("button3"); //QUIT
            button_box[2] = new Rectangle(367, shape[0].Height+shape[1].Height+40+button[0].Height+40+button[1].Height+40, button[2].Width, button[2].Height);
        }
    
        public override void Update(GameTime gameTime)
        {
            MouseState mouse_state = Mouse.GetState();
            mouse_box = new Rectangle(mouse_state.X,mouse_state.Y,1,1);

            if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Game_level; //START
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[1]) && old_mouse_state.LeftButton == ButtonState.Released) 
                Settings_file.CurrentState = Settings_file.Layer.Info_level; //INFO
            else if (mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[2]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.Exit = true; //QUIT
            old_mouse_state = mouse_state;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i<button.Length; i++)
            {
                spriteBatch.Draw(button[i],button_box[i],Color.White);
                
                 if(mouse_box.Intersects(button_box[i]))
                     spriteBatch.Draw(button[i],button_box[i],Color.DarkGreen);
            }

            spriteBatch.Draw(shape[0],shape_box[0],Color.White);
            spriteBatch.Draw(shape[1],shape_box[1],Color.White);

            for(int i = 2; i<MAX_shape; i++){
                spriteBatch.Draw(shape[i],shape_box[i],Color.DimGray);
            }
        }
    }
}