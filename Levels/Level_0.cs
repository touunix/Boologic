using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Boologic.Core;
using System;

namespace Boologic.Levels
{
    public class Level_0 : MG_abstract
    {
        const int MAX_button = 2;
        private Texture2D[] button = new Texture2D[MAX_button];
        private Rectangle[] button_box = new Rectangle[MAX_button];

        const int MAX_shape = 11;
        private Texture2D[] shape = new Texture2D[MAX_shape];
        private Rectangle[] shape_box = new Rectangle[MAX_shape];

        const int MAX_element = 12;
        private Texture2D[] element = new Texture2D[MAX_element];
        private Rectangle[] element_box = new Rectangle[MAX_element];

        private Texture2D[] blocks = new Texture2D[16];
        private Rectangle[] blocksRect = new Rectangle[16];

        private MouseState old_mouse_state = new MouseState();
        private MouseState mouse_state;
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
            shape[3] = Content.Load<Texture2D>("shape0"); //NUMER POZIOMU
            shape_box[3] = new Rectangle (931, 0, 93, 93);
            shape[4] = Content.Load<Texture2D>("line");
            shape_box[4] = new Rectangle (923, 0, shape[0].Height/3, 93);
            shape[5] = Content.Load<Texture2D>("available_logic_gates");
            shape_box[5] = new Rectangle (0, 0, (shape[5].Width*2)/3, 93);
            shape[6] = Content.Load<Texture2D>("and_gate");
            shape_box[6] = new Rectangle ((shape[5].Width*2)/3+11, 9, shape[6].Width, shape[6].Height);
            shape[7] = Content.Load<Texture2D>("and_gate");
            shape_box[7] = new Rectangle ((shape[5].Width*2)/3+11+shape[6].Width+11, 9, shape[6].Width, shape[6].Height);
            shape[8] = Content.Load<Texture2D>("and_gate");
            shape_box[8] = new Rectangle ((shape[5].Width*2)/3+11+shape[6].Width+11+shape[7].Width+11, 9, shape[6].Width, shape[6].Height);
            shape[9] = Content.Load<Texture2D>("and_gate");
            shape_box[9] = new Rectangle ((shape[5].Width*2)/3+11+shape[6].Width+11+shape[7].Width+11+shape[8].Width+11, 9, shape[6].Width, shape[6].Height);
            shape[10] = Content.Load<Texture2D>("and_gate");
            shape_box[10] = new Rectangle ((shape[5].Width*2)/3+11+shape[6].Width+11+shape[7].Width+11+shape[8].Width+11+shape[9].Width+11, 9, shape[6].Width, shape[6].Height);

            int height_zeroes_ones = 200;
            element[0] = Content.Load<Texture2D>("zero");
            element_box[0] = new Rectangle (52, height_zeroes_ones, element[0].Width, element[0].Height);
            element[1] = Content.Load<Texture2D>("zero");
            element_box[1] = new Rectangle (52+element[0].Width, height_zeroes_ones, element[1].Width, element[1].Height);
            element[2] = Content.Load<Texture2D>("zero");
            element_box[2] = new Rectangle (52+element[0].Width+element[1].Width+52, height_zeroes_ones, element[2].Width, element[2].Height);
            element[3] = Content.Load<Texture2D>("one");
            element_box[3] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width, height_zeroes_ones, element[3].Width, element[3].Height);
            element[4] = Content.Load<Texture2D>("one");
            element_box[4] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width+element[3].Width+52, height_zeroes_ones, element[4].Width, element[4].Height);
            element[5] = Content.Load<Texture2D>("one");
            element_box[5] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width+element[3].Width+52+element[4].Width, height_zeroes_ones, element[5].Width, element[5].Height);
            element[6] = Content.Load<Texture2D>("one");
            element_box[6] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width+element[3].Width+52+element[4].Width+element[5].Width+52, height_zeroes_ones, element[6].Width, element[6].Height);
            element[7] = Content.Load<Texture2D>("zero");
            element_box[7] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width+element[3].Width+52+element[4].Width+element[5].Width+element[6].Width+52, height_zeroes_ones, element[7].Width, element[7].Height);
            
            int height_inputs = 200 + element[0].Height;
            element[8] = Content.Load<Texture2D>("input_gate");
            element_box[8] = new Rectangle (52+element[0].Height/2, height_inputs, element[8].Width, element[8].Height);
            element[9] = Content.Load<Texture2D>("input_gate");
            element_box[9] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width/2, height_inputs, element[8].Width, element[8].Height);
            element[10] = Content.Load<Texture2D>("input_gate");
            element_box[10] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width+element[3].Width+52+element[4].Width/2, height_inputs, element[8].Width, element[8].Height);
            element[11] = Content.Load<Texture2D>("input_gate");
            element_box[11] = new Rectangle (52+element[0].Width+element[1].Width+52+element[2].Width+element[3].Width+52+element[4].Width+element[5].Width+element[6].Width, height_inputs, element[8].Width, element[8].Height);

            int height_outputs = 200 + element[0].Height+element[8].Height;
        }
    
        public override void Update(GameTime gameTime)
        {
            mouse_state = Mouse.GetState();
            mouse_box = new Rectangle(mouse_state.X,mouse_state.Y,1,1);

            if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Level_0;    //RESTART
            else if(mouse_state.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[1]) && old_mouse_state.LeftButton == ButtonState.Released)
                Settings_file.CurrentState = Settings_file.Layer.Game_level; //BACK

            for (int i=0; i < MAX_element; i++)
            {
                moveObject(i);
            }                
        }
 public void moveObject(int i)
        {
            if(mouse_state.LeftButton == ButtonState.Pressed && 
               element_box[i].Contains(mouse_box) && 
               check_colision_left(element_box[i]) &&
               check_colision_right(element_box[i]) &&
               check_colision_up(element_box[i]) &&
               check_colision_down(element_box[i]))
            {
                element_box[i].X = mouse_state.X-(element_box[i].Width/2);
                element_box[i].Y = mouse_state.Y-(element_box[i].Height/2);
            }
        }

private bool check_colision_left(Rectangle objectRect)
        {
            if(mouse_box.X - (objectRect.Width/2) >= 10)
                return true;
            else return false;
        }
        private bool check_colision_right(Rectangle objectRect)
        {
            if(mouse_box.X + (objectRect.Width/2) <= 1019)
                return true;
            else return false;
        }
        private bool check_colision_up(Rectangle objectRect)
        {
            if(mouse_box.Y - (objectRect.Height/2) > 10)
                return true;
            else return false;
        }
        private bool check_colision_down(Rectangle objectRect)
        {
            if(mouse_box.Y + (objectRect.Height/2) <= 500)
                return true;
            else return false;
        }


        
        public override void Draw(SpriteBatch spriteBatch)
        {
            try{

            
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

            }
            catch (Exception){

            }
        }
    }
}



       
