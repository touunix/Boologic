using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;

namespace Boologic.Levels
{
    public class Level_2 : MG_abstract
    {
        const int MAX_button = 2;
        private Texture2D[] button = new Texture2D[MAX_button];
        private Rectangle[] button_box = new Rectangle[MAX_button];

        const int MAX_shape = 5;
        private Texture2D[] shape = new Texture2D[MAX_shape];
        private Rectangle[] shape_box = new Rectangle[MAX_shape];

        private MouseState old_mouse_state = new MouseState();
        private Rectangle mouse_box;
        
        public override void LoadContent(ContentManager Content)
        {
            button[0]=Content.Load<Texture2D>("button5");   //RESTART
            button_box[0] = new Rectangle(66, 675, button[0].Width, button[0].Height);
            button[1]=Content.Load<Texture2D>("button4_2"); //BACK
            button_box[1] = new Rectangle(66+button[0].Width+66+4+4+142, 675, button[1].Width, button[1].Height);

            shape[0] = Content.Load<Texture2D>("line");
            shape_box[0] = new Rectangle (0, 667, 1024, shape[0].Height/3);
            shape[1] = Content.Load<Texture2D>("line");
            shape_box[1] = new Rectangle (66+button[0].Width+66, 675, shape[0].Height/3, 93);
            shape[2] = Content.Load<Texture2D>("line");
            shape_box[2] = new Rectangle (0, 93, 1024, shape[0].Height/3);
            shape[3] = Content.Load<Texture2D>("shape2"); //NUMER POZIOMU
            shape_box[3] = new Rectangle (931, 0, 93, 93);
            shape[4] = Content.Load<Texture2D>("line");
            shape_box[4] = new Rectangle (923, 0, shape[0].Height/3, 93);

        }
    
        public override void Update(GameTime gameTime)
        {
            MouseState mouse_state = Mouse.GetState();
            mouse_box = new Rectangle(mouse_state.X,mouse_state.Y,1,1);

            if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_0;    //RESTART
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[1]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Game_level; //BACK
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i<MAX_button; i++)
            {
                spriteBatch.Draw(button[i],button_box[i],Color.White);
                
                 if(mouse_box.Intersects(button_box[i]))
                    spriteBatch.Draw(button[i],button_box[i],Color.DarkGreen);
            }
            for(int i = 0; i<MAX_shape; i++){
                spriteBatch.Draw(shape[i],shape_box[i],Color.White);
            }
        }
    }
}