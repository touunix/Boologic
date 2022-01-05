using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Boologic.Core;

namespace Boologic.Levels
{
    public class Level_3 : MG_abstract
    {
        private Texture2D[] button = new Texture2D[3];
        private Rectangle[] button_box = new Rectangle[3];

        private MouseState position_mouse, old_position_mouse;
        private Rectangle mouse_box;
        
        public override void LoadContent(ContentManager Content)
        {
                    button[0]=Content.Load<Texture2D>("button1");
                    button_box[0] = new Rectangle(512, 645,button[0].Width,button[0].Height);
                
        }
    
        public override void Update(GameTime gameTime)
        {
            old_position_mouse = position_mouse;
            position_mouse = Mouse.GetState();
            mouse_box = new Rectangle(position_mouse.X,position_mouse.Y,1,1);

            if(position_mouse.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0])) //START
                Settings_file.CurrentState = Settings_file.Layer.Game_level;
            else if (position_mouse.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[2])) //QUIT
                Settings_file.Exit = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
                spriteBatch.Draw(button[0],button_box[0],Color.Red);
                
                 if(mouse_box.Intersects(button_box[0]))
                 {
                     spriteBatch.Draw(button[0],button_box[0],Color.Yellow);
                 }
            
        }
    }
}