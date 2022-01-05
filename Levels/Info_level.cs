using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;

namespace Boologic.Levels
{
    public class Info_level : MG_abstract
    {
        const int MAX_button = 1;
        private Texture2D[] button = new Texture2D[MAX_button];
        private Rectangle[] button_box = new Rectangle[MAX_button];

        const int MAX_shape = 3;
        private Texture2D[] shape = new Texture2D[MAX_shape];
        private Rectangle[] shape_box = new Rectangle[MAX_shape];

        private MouseState old_mouse_state = new MouseState();
        private Rectangle mouse_box;
        
        public override void LoadContent(ContentManager Content)
        {
            button[0]=Content.Load<Texture2D>("button4"); //BACK
            button_box[0] = new Rectangle(362, 617,button[0].Width,button[0].Height);
            
            shape[0]=Content.Load<Texture2D>("text_1");
            shape_box[0] = new Rectangle(15, 0,(shape[0].Width*2)/3,shape[0].Height*2);
            shape[1]=Content.Load<Texture2D>("text_2");
            shape_box[1] = new Rectangle(15,shape[0].Height*2-20,(shape[1].Width*2)/3,shape[1].Height*2);
            shape[2] = Content.Load<Texture2D>("line");
            shape_box[2] = new Rectangle (0, 590, 1024,shape[2].Height);
        }
    
        public override void Update(GameTime gameTime)
        {
            MouseState mouse_state = Mouse.GetState();
            mouse_box = new Rectangle(mouse_state.X,mouse_state.Y,1,1);

            if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0]) && old_mouse_state.LeftButton == ButtonState.Released) 
                Settings_file.CurrentState = Settings_file.Layer.Menu_level; //BACK
            old_mouse_state = mouse_state;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(button[0],button_box[0],Color.White);
                spriteBatch.Draw(shape[0],shape_box[0],Color.White);
                spriteBatch.Draw(shape[1],shape_box[1],Color.White);
                spriteBatch.Draw(shape[2],shape_box[2],Color.White);
                
                 if(mouse_box.Intersects(button_box[0]))
                 {
                    spriteBatch.Draw(button[0],button_box[0],Color.DarkGreen);
                 }
        }
    }
}