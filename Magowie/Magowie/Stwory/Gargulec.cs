using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Magowie.Stwory
{
    class Gargulec:Stworki
    {
        Model model;
        ContentManager content;
        Matrix gargulecWorld;

        public Gargulec()
            
        {
        }

        public override void LoadContent(ContentManager content1)
        {
            this.content = content1;
            model = content.Load<Model>(@"Models\corv");
            //model = content.Load<Model>(@"Models/sampleModelTextured");
        }

        public override void Initialize()
        {
            gargulecWorld = Matrix.Identity;
        }


        public override void Draw(GameTime gameTime)
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
                        effect.World = modelTransforms[mesh.ParentBone.Index] * gargulecWorld;
                    }
                    mesh.Draw();
                }

            }


        }

        public void Update(GameTime gameTime)
        {

        }


        public void Renderuj()
        {

        }

        public override void Podaj_polozenie(float s1, float s2)
        {
            gargulecWorld *= Matrix.CreateTranslation(gargulecWorld.Forward * s1);
            gargulecWorld *= Matrix.CreateTranslation(-gargulecWorld.Right * s2);

        }

        public void Wykonuj()
        {

        }
    }
}
