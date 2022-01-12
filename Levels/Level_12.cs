using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;

namespace Boologic.Levels
{
    public class Level_12 : MG_abstract
    {
        const int MAX_button = 3;
        private Texture2D[] button = new Texture2D[MAX_button];
        private Rectangle[] button_box = new Rectangle[MAX_button];

        const int MAX_shape = 6;
        private Texture2D[] shape = new Texture2D[MAX_shape];
        private Rectangle[] shape_box = new Rectangle[MAX_shape];

        const int MAX_overlayer = 2;
        private Texture2D[] overlayer = new Texture2D[MAX_overlayer];
        private Rectangle[] overlay_box = new Rectangle[MAX_overlayer];

        private MouseState old_mouse_state = new MouseState();
        private MouseState mouse_state;
        private Rectangle mouse_box;

        SpriteFont gameFont;
        SpriteFont gameFont_2;
        
        public override void LoadContent(ContentManager Content)
        {   
            gameFont = Content.Load<SpriteFont>("font");
            gameFont_2 = Content.Load<SpriteFont>("font_small");

            button[0]=Content.Load<Texture2D>("button5");   //NEXT
            button_box[0] = new Rectangle(0, 675, button[0].Width, button[0].Height);
            button[1]=Content.Load<Texture2D>("button4_2"); //BACK
            button_box[1] = new Rectangle(795, 675, button[1].Width, button[1].Height);
            button[2]=Content.Load<Texture2D>("button6");   //CHECK
            button_box[2] = new Rectangle(button[0].Width+8+61+75, 675, button[2].Width, button[2].Height);

            shape[0] = Content.Load<Texture2D>("line");
            shape_box[0] = new Rectangle (0, 667, 1024, shape[0].Height/3);
            shape[1] = Content.Load<Texture2D>("line");
            shape_box[1] = new Rectangle (button[0].Width, 675, shape[0].Height/3, 93);
            shape[2] = Content.Load<Texture2D>("line");
            shape_box[2] = new Rectangle (0, 93, 1024, shape[0].Height/3);
            shape[3] = Content.Load<Texture2D>("shape12"); //NUMER POZIOMU
            shape_box[3] = new Rectangle (931, 0, 93, 93);
            shape[4] = Content.Load<Texture2D>("line");
            shape_box[4] = new Rectangle (923, 0, shape[0].Height/3, 93);
            shape[5] = Content.Load<Texture2D>("line");
            shape_box[5] = new Rectangle (787, 675, shape[0].Height/3, 93);

            overlayer[0] = Content.Load<Texture2D>("line");
            overlay_box[0] = new Rectangle (0, 0, 1024, 768);
            overlayer[1] = Content.Load<Texture2D>("order_space");
            overlay_box[1] = new Rectangle (255, 64, overlayer[1].Width, overlayer[1].Height);
        }
    
        public override void Update(GameTime gameTime)
        {
            mouse_state = Mouse.GetState();
            mouse_box = new Rectangle(mouse_state.X,mouse_state.Y,1,1);

            if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Menu_level; //NEXT
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[1]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Game_level; //BACK
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
                for(int i = 0; i<MAX_shape; i++){
                    spriteBatch.Draw(shape[i],shape_box[i],Color.White);
                }


            spriteBatch.DrawString(gameFont,"END GAME",new Vector2(300,20),Color.LightGray);
            spriteBatch.DrawString(gameFont,"Thank you for",new Vector2(170,270),Color.LightGray);
            spriteBatch.DrawString(gameFont,"your game.",new Vector2(240,335),Color.LightGray);
            spriteBatch.DrawString(gameFont_2,"To check your final order click button CHECK",new Vector2(350,640),Color.LightGray);

            if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[2]))
            {
                spriteBatch.Draw(overlayer[0],overlay_box[0],Color.LightGray);
                spriteBatch.Draw(overlayer[1],overlay_box[1],Color.White);
                spriteBatch.DrawString(gameFont, "Congratulations !!!",new Vector2(25,0),Color.DarkViolet);
                spriteBatch.DrawString(gameFont, "Ultimate Order",new Vector2(180,700),Color.DarkViolet);
            }    
        }
    }
}