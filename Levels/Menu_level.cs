using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Boologic.Core;

namespace Boologic.Levels
{
    public class Menu_level : MG_abstract
    {
        private Texture2D[] buttons = new Texture2D[4];
        private Rectangle[] buttons_under = new Rectangle[4];
        public override void LoadContent(ContentManager Content)
        {
            const int INCREMENT_VALUE = 125;
                for(int i=1; i<buttons.Length; i++)
                {
                    buttons[i]=Content.Load<Texture2D>($"button{i}");
                    buttons_under[i] = new Rectangle(0, 0+(INCREMENT_VALUE*i),buttons[i].Width,buttons[i].Height);
                }


        }
    
        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for(int i=1;i<buttons.Length;i++)
            {
                spriteBatch.Draw(buttons[i],buttons_under[i],Color.White);
            }
        }
    }
}