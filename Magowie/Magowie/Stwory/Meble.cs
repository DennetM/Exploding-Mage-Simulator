using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Magowie.Stwory
{
    class Meble : Stworki
    {
        Model model;
        ContentManager content;
        Matrix mebleWorld;

        public Meble()
            : base()
        {
        }

        public override void LoadContent(ContentManager content1)
        {
            this.content = content1;
            model = content.Load<Model>(@"Models\corv");
        }
        public override void Initialize()
        {
            mebleWorld = Matrix.Identity;
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
                        effect.World = modelTransforms[mesh.ParentBone.Index] * mebleWorld;
                    }
                    mesh.Draw();
                }

            }

        }

        public override void Update(GameTime gameTime)
        {

        }


        public void Renderuj()
        {

        }

        public void Podaj_polozenie()
        {

        }

        public void Wykonuj()
        {

        }
    }
}
