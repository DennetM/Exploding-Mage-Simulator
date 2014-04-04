using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Magowie.Stwory
{
    class Boss : Stworki
    {
        Model model;
        ContentManager content;
        Matrix bossWorld;

        public Boss()
        {
        }

        public override void LoadContent(ContentManager content1)
        {
            this.content = content1;
            model = content.Load<Model>(@"Models\corv");
        }

        public override void Initialize()
        {

            bossWorld = Matrix.Identity;
            bossWorld *= Matrix.CreateTranslation(bossWorld.Forward*10);
            bossWorld *= Matrix.CreateTranslation(-bossWorld.Right*20);
            base.Initialize();
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
                            effect.World = modelTransforms[mesh.ParentBone.Index] * bossWorld;
                        }
                        mesh.Draw();
                    }

            }

        }

        public override void Update(GameTime gameTime)
        {

        }


        public override void Renderuj()
        {

        }

        public override void Podaj_polozenie(float s1, float s2)
        {

            bossWorld *= Matrix.CreateTranslation(bossWorld.Forward * s1);
            bossWorld *= Matrix.CreateTranslation(-bossWorld.Right * s2);

        }

        public void Wykonuj()
        {

        }
    }
}
