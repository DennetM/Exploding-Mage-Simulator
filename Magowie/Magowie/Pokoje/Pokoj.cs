using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Magowie.Pokoje
{
    class Pokoj
    {

        float x1;
        float y1;
        float z1;
        float aspectRatio;
        Model model;
        ContentManager content;
        Matrix pokojWorld;

        public void LoadContent(ContentManager content, float aspectRatio)
        {
            this.aspectRatio = aspectRatio;
            this.content = content;
            model = content.Load<Model>(@"Models\Room-Fountain-raw-v1");
        }
        public void Initialize()
        {

            pokojWorld = Matrix.Identity;
        }



        public void Draw(GameTime gameTime)
        {


            if (model != null)
            {
                Matrix[] modelTransforms = new Matrix[model.Bones.Count];
                model.CopyAbsoluteBoneTransformsTo(modelTransforms);

                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();
                        effect.World = modelTransforms[mesh.ParentBone.Index] * pokojWorld;
                    }
                    mesh.Draw();
                }

            }


            //foreach (ModelMesh mesh in model.Meshes)
            //{
            //    foreach (BasicEffect effect in mesh.Effects)
            //    {
            //        effect.EnableDefaultLighting();
            //        //effect.View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            //        effect.World = Matrix.CreateTranslation(x1, y1, z1);
            //        effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(20.0f), aspectRatio, 1.0f, 50.0f);
            //    }

            //    mesh.Draw();
            //}


        }


    }
}
