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
    public class Info_level : MG_abstract
    {
        private Texture2D[] button = new Texture2D[3];
        private Rectangle[] button_box = new Rectangle[3];

        private MouseState position_mouse, old_position_mouse;
        private Rectangle mouse_box;
        
        public override void LoadContent(ContentManager Content)
        {
            const int INCREMENT_VALUE = 200;
                for(int i=0; i<button.Length; i++)
                {
                    button[i]=Content.Load<Texture2D>($"button{i+1}");
                    button_box[i] = new Rectangle(0, 0+(INCREMENT_VALUE*i),button[i].Width,button[i].Height);
                }
        }
    
        public override void Update(GameTime gameTime)
        {
            old_position_mouse = position_mouse;
            position_mouse = Mouse.GetState();
            mouse_box = new Rectangle(position_mouse.X,position_mouse.Y,1,1);

            if(position_mouse.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[0])) //START
                Settings_file.CurrentState = Settings_file.Layer.Game_level;
            else if(position_mouse.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[1])) //INFO
                Settings_file.CurrentState = Settings_file.Layer.Info_level;
            else if (position_mouse.LeftButton == ButtonState.Pressed && mouse_box.Intersects(button_box[2])) //QUIT
                Settings_file.Exit = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for(int i=0;i<button.Length;i++)
            {
                spriteBatch.Draw(button[i],button_box[i],Color.White);
                
                 if(mouse_box.Intersects(button_box[i]))
                 {
                     spriteBatch.Draw(button[i],button_box[i],Color.Yellow);
                 }
            }
        }
    }
}