using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Magowie.Objekty;
using Magowie.Stwory;
using Magowie.Pokoje;
namespace Magowie
{
    public class Engine : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Pokoj pokoj;
        float aspectRatio;
        Gracz gracz;

       
        List<Stworki> stworzenia = new List<Stworki>();
        public Engine()
        {
            pokoj = new Pokoj();
            gracz = new Gracz();
            stworzenia.Add(new Ryboczlek());
            stworzenia.Add(new Ryboczlek());
            stworzenia.Add(new Gargulec());
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

      
        protected override void Initialize()
        {
            for (int i = 0; i < stworzenia.Count; i++)
            {
                stworzenia[i].Initialize();
            }
            stworzenia[1].Podaj_polozenie(10f, -7f);
            stworzenia[2].Podaj_polozenie(-15f, -9f);
            gracz.Initialize();
            pokoj.Initialize();
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

            gracz.LoadContent(Content);
            pokoj.LoadContent(Content, aspectRatio);
            for (int i = 0; i < stworzenia.Count; i++)
            {
                stworzenia[i].LoadContent(Content);
            }

            
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            gracz.Update();
            for (int i = 0; i < stworzenia.Count; i++)
            {
                stworzenia[i].Update(gameTime);
            }

        
        }
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            gracz.Draw();
            pokoj.Draw(gameTime);
            for (int i = 0; i < stworzenia.Count; i++)
            {
                stworzenia[i].Draw(gameTime);
            }


        }


    }
}
