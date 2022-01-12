using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;

namespace Boologic.Levels
{
    public class Level_0 : MG_abstract
    {
        const int MAX_button = 3;
        private Texture2D[] button = new Texture2D[MAX_button];
        private Rectangle[] button_box = new Rectangle[MAX_button];

        const int MAX_shape = 9;
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
            shape[3] = Content.Load<Texture2D>("shape0"); //NUMER POZIOMU
            shape_box[3] = new Rectangle (931, 0, 93, 93);
            shape[4] = Content.Load<Texture2D>("line");
            shape_box[4] = new Rectangle (923, 0, shape[0].Height/3, 93);
            shape[5] = Content.Load<Texture2D>("introduction");
            shape_box[5] = new Rectangle (0, 0, shape[5].Width, 93);
            shape[6] = Content.Load<Texture2D>("line");
            shape_box[6] = new Rectangle (787, 675, shape[0].Height/3, 93);
            shape[7] = Content.Load<Texture2D>("table_and");
            shape_box[7] = new Rectangle (750, 220, shape[7].Width, shape[7].Height);
            shape[8] = Content.Load<Texture2D>("and_gate");
            shape_box[8] = new Rectangle (165, 450, shape[8].Width*2, shape[8].Height*2);

            overlayer[0] = Content.Load<Texture2D>("line");
            overlay_box[0] = new Rectangle (0, 0, 1024, 768);
            overlayer[1] = Content.Load<Texture2D>("order");
            overlay_box[1] = new Rectangle (255, 64, overlayer[1].Width, overlayer[1].Height);
        }
    
        public override void Update(GameTime gameTime)
        {
            mouse_state = Mouse.GetState();
            mouse_box = new Rectangle(mouse_state.X,mouse_state.Y,1,1);

            if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_1; //NEXT
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

            spriteBatch.DrawString(gameFont, "AND Gate Level",new Vector2(170,120),Color.LightGray);
            spriteBatch.DrawString(gameFont_2, "The AND gate is a basic digital logic gate that implements logical conjunction (^)",new Vector2(10,220),Color.LightGray);
            spriteBatch.DrawString(gameFont_2,"from mathematical logic. The behavior of operation is shown on the right, in truth",new Vector2(10,255),Color.LightGray);
            spriteBatch.DrawString(gameFont_2,"table. A HIGH output results only if all the inputs to the AND gate are HIGH.",new Vector2(10,290),Color.LightGray);
            spriteBatch.DrawString(gameFont_2,"If none or not all inputs to the AND gate are HIGH, LOW output results.",new Vector2(10,325),Color.LightGray);
            spriteBatch.DrawString(gameFont_2,"The function can be extended to any number of inputs. ",new Vector2(10,360),Color.LightGray);
            spriteBatch.DrawString(gameFont_2,"Symbol of AND gate: ",new Vector2(150,420),Color.LightGray);
            spriteBatch.DrawString(gameFont_2,"To check your order click button CHECK ",new Vector2(350,640),Color.LightGray);

            if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[2]))
            {
                spriteBatch.Draw(overlayer[0],overlay_box[0],Color.LightGray);
                spriteBatch.Draw(overlayer[1],overlay_box[1],Color.White);
                spriteBatch.DrawString(gameFont, "Congratulations !!!",new Vector2(25,0),Color.Black);
                spriteBatch.DrawString(gameFont, "AND Order",new Vector2(310,700),Color.Black);
            }    
        }
    }
}