using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Content;
using Magowie.Objekty;
using Magowie.Camera;
namespace Magowie.Objekty
{
    class Gracz
    {
        Model model;
        Matrix playerWorld;
        private MouseState _prevMouseState;
        ContentManager content;
        Kamera camera = new Kamera();

        public void Initialize()
        {
            playerWorld = Matrix.Identity;
            //playerWorld = Matrix.CreateFromAxisAngle(Vector3.Up,60f) * playerWorld;
        }


        public virtual void LoadContent(ContentManager content)
        {
            this.content = content;
            model = content.Load<Model>(@"Models\corv");
        }

        public void Update()
        {
            camera.Update(playerWorld);
            KeyboardState keyBoardState = Keyboard.GetState();
            MouseState st = Mouse.GetState();
            
            if (st.X < _prevMouseState.X)
            {
                playerWorld = Matrix.CreateFromAxisAngle(Vector3.Up, .02f) * playerWorld;
            }
            if (st.X > _prevMouseState.X)
            {
                playerWorld = Matrix.CreateFromAxisAngle(Vector3.Up, -.02f) * playerWorld;
            }

            _prevMouseState = st;

            if (keyBoardState.IsKeyDown(Keys.X))
            {
                playerWorld = Matrix.CreateFromAxisAngle(Vector3.Up, .02f) * playerWorld;
            }
            if (keyBoardState.IsKeyDown(Keys.Z))
            {
                playerWorld = Matrix.CreateFromAxisAngle(Vector3.Up, -.02f) * playerWorld;
            }

            if (keyBoardState.IsKeyDown(Keys.W))
            {
                playerWorld *= Matrix.CreateTranslation(playerWorld.Forward);
            }
            if (keyBoardState.IsKeyDown(Keys.S))
            {
                playerWorld *= Matrix.CreateTranslation(playerWorld.Backward);
            }
            if (keyBoardState.IsKeyDown(Keys.A))
            {
                playerWorld *= Matrix.CreateTranslation(-playerWorld.Right);
            }
            if (keyBoardState.IsKeyDown(Keys.D))
            {
                playerWorld *= Matrix.CreateTranslation(playerWorld.Right);
            }

          
        }

        public void Draw()
        {
            Matrix[] modelTransforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(modelTransforms);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = modelTransforms[mesh.ParentBone.Index] * playerWorld;
                    effect.View = camera.viewMatrix;
                    effect.Projection = camera.projectionMatrix;
                }
                mesh.Draw();
            }
        }

    }
}
