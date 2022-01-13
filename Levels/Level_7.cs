using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;

namespace Boologic.Levels
{
    /// <summary>
    /// Manages an Level 7 Layer
    /// </summary>    

    public class Level_7 : MG_abstract
    {
        const int MAX_button = 3;
        private Texture2D[] button = new Texture2D[MAX_button];
        private Rectangle[] button_box = new Rectangle[MAX_button];

        const int MAX_shape = 7;
        private Texture2D[] shape = new Texture2D[MAX_shape];
        private Rectangle[] shape_box = new Rectangle[MAX_shape];

        const int MAX_element = 8;
        private Texture2D[] element = new Texture2D[MAX_element];
        private Rectangle[] element_box = new Rectangle[MAX_element];

        const int MAX_drag_element = 2;
        private Texture2D[] drag_element = new Texture2D[MAX_drag_element];
        private Rectangle[] drag_element_box = new Rectangle[MAX_drag_element];

        const int MAX_overlayer = 2;
        private Texture2D[] overlayer = new Texture2D[MAX_overlayer];
        private Rectangle[] overlay_box = new Rectangle[MAX_overlayer];

        private MouseState old_mouse_state = new MouseState();
        private MouseState mouse_state;
        private Rectangle mouse_box;

        SpriteFont gameFont;
        SpriteFont gameFont_2;

        bool result1, result2 = false;

        /// <summary>
        /// Section which load content
        /// </summary>
        
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
            shape[3] = Content.Load<Texture2D>("shape7"); //NUMER POZIOMU
            shape_box[3] = new Rectangle (931, 0, 93, 93);
            shape[4] = Content.Load<Texture2D>("line");
            shape_box[4] = new Rectangle (923, 0, shape[0].Height/3, 93);
            shape[5] = Content.Load<Texture2D>("available_logic_gates");
            shape_box[5] = new Rectangle (0, 0, (shape[5].Width*2)/3, 93);
            shape[6] = Content.Load<Texture2D>("line");
            shape_box[6] = new Rectangle (787, 675, shape[0].Height/3, 93);

            overlayer[0] = Content.Load<Texture2D>("line");
            overlay_box[0] = new Rectangle (0, 0, 1024, 768);
            overlayer[1] = Content.Load<Texture2D>("order_diamond");
            overlay_box[1] = new Rectangle (255, 64, overlayer[1].Width, overlayer[1].Height);

            int height_zeroes_ones = 200;
            element[0] = Content.Load<Texture2D>("zero");
            element_box[0] = new Rectangle (52+element[0].Width+element[0].Width+52+element[0].Width/2, height_zeroes_ones, element[0].Width, element[0].Height);
            element[1] = Content.Load<Texture2D>("one");
            element_box[1] = new Rectangle (52+element[0].Width+element[0].Width+52+element[0].Width+element[0].Width+52+element[0].Width/2, height_zeroes_ones, element[0].Width, element[0].Height);
            
            int height_inputs = 200 + element[0].Height;
            element[2] = Content.Load<Texture2D>("correct_input");
            element_box[2] = new Rectangle (52+element[0].Width+element[0].Width+52+element[0].Width/2, height_inputs, element[0].Width, element[0].Height);
            element[3] = Content.Load<Texture2D>("correct_input");
            element_box[3] = new Rectangle (52+element[0].Width+element[0].Width+52+element[0].Width+element[0].Width+52+element[0].Width/2, height_inputs, element[0].Width, element[0].Height);

            int height_outputs = 200 + element[0].Height*2;
            element[4] = Content.Load<Texture2D>("output_gate");
            element_box[4] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width/2, height_outputs, element[0].Width, element[0].Height);
            element[5] = Content.Load<Texture2D>("output_gate");
            element_box[5] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width+element[3].Width+52+element[4].Width/2, height_outputs, element[0].Width, element[0].Height);
            
            element[6] = Content.Load<Texture2D>("input_gate");
            element_box[6] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width/2, height_inputs, element[0].Width, element[0].Height);
            element[7] = Content.Load<Texture2D>("input_gate");
            element_box[7] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width+element[3].Width+52+element[4].Width/2, height_inputs, element[0].Width, element[0].Height);

            drag_element[0] = Content.Load<Texture2D>("not_gate");
            drag_element_box[0] = new Rectangle ((shape[5].Width*2)/3+29+drag_element[0].Width+29, 9, drag_element[0].Width, drag_element[0].Height);
            drag_element[1] = Content.Load<Texture2D>("not_gate");
            drag_element_box[1] = new Rectangle ((shape[5].Width*2)/3+29+drag_element[0].Width+29+drag_element[1].Width+29, 9, drag_element[1].Width, drag_element[1].Height);

        }

        /// <summary>
        /// Section which update content
        /// </summary>
    
        public override void Update(GameTime gameTime)
        {
            mouse_state = Mouse.GetState();
            mouse_box = new Rectangle(mouse_state.X,mouse_state.Y,1,1);

            if(result1==true && result2==true && mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_8;  //NEXT
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[1]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Game_level; //BACK
            old_mouse_state = mouse_state;

            for (int i=0; i < MAX_drag_element; i++) //RUSZANIE ELEMENTAMI
            {
                drag_elements(i);
                specific_area(i);
            }                
        }

        /// <summary>
        /// Section which enable dragging elements
        /// </summary>

        public void drag_elements(int i)
        {
            if(mouse_state.LeftButton == ButtonState.Pressed && drag_element_box[i].Intersects(mouse_box) && margin_left(drag_element_box[i]) && margin_right(drag_element_box[i]) &&
            margin_up(drag_element_box[i]) && margin_down(drag_element_box[i]))
            {
                drag_element_box[i].X = mouse_state.X-(drag_element_box[i].Width/2);
                drag_element_box[i].Y = mouse_state.Y-(drag_element_box[i].Height/2);
            }
        }

        /// <summary>
        /// Section which determines the area
        /// </summary>

        public void specific_area(int i)
        { 
            int int_drag_x;
            int int_drag_y;
            int_drag_x = (int)drag_element_box[i].X;
            int_drag_y = (int)drag_element_box[i].Y;

            if(int_drag_x > 342 && int_drag_x < 437 && int_drag_y > 295 && int_drag_y < 390)
            {   
                element[4] = element[1];
                element[6] = element[2];
                result1 = true;
            }

            if(int_drag_x > 584 && int_drag_x < 679 && int_drag_y > 295 && int_drag_y < 390)
            {
                element[5] = element[0];
                element[7] = element[2];
                result2 = true;
            }
        }

        private bool margin_left(Rectangle drag_element_box)
        {
            if(mouse_box.X - (drag_element_box.Width/2) >= 2) return true;
            else return false;
        }
        private bool margin_right(Rectangle drag_element_box)
        {
            if(mouse_box.X + (drag_element_box.Width/2) <= 1022) return true;
            else return false;
        }
        private bool margin_up(Rectangle drag_element_box)
        {
            if(mouse_box.Y - (drag_element_box.Height/2) > 1) return true;
            else return false;
        }
        private bool margin_down(Rectangle drag_element_box)
        {
            if(mouse_box.Y + (drag_element_box.Height/2) <= 663) return true;
            else return false;
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
                for(int i = 0; i<MAX_shape; i++){
                    spriteBatch.Draw(shape[i],shape_box[i],Color.White);
                }
                for(int i = 0; i<MAX_element; i++){
                    spriteBatch.Draw(element[i],element_box[i],Color.White);
                }
                for(int i = 0; i<MAX_drag_element; i++){
                    spriteBatch.Draw(drag_element[i],drag_element_box[i],Color.White);
                    if(mouse_box.Intersects(drag_element_box[i]))
                        spriteBatch.Draw(drag_element[i],drag_element_box[i],Color.Orange);
                }

            spriteBatch.DrawString(gameFont, "NOT Gate Level 2",new Vector2(110,120),Color.LightGray);
            spriteBatch.DrawString(gameFont_2,"Finish level to check your order",new Vector2(385,640),Color.LightGray);

            if(result1==true && result2==true && mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[2]))
                {
                    spriteBatch.Draw(overlayer[0],overlay_box[0],Color.LightGray);
                    spriteBatch.Draw(overlayer[1],overlay_box[1],Color.White);
                    spriteBatch.DrawString(gameFont, "Congratulations !!!",new Vector2(25,0),Color.Black);
                    spriteBatch.DrawString(gameFont, "Diamond Order",new Vector2(200,700),Color.LightBlue);
                }    
        }
    }
}