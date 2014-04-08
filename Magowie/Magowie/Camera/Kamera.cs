using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Magowie.Camera
{
    class Kamera
    {
        private Vector3 position;
        private Vector3 target;
        public Matrix viewMatrix, projectionMatrix;
        private float yaw, pitch, roll;
        private float speed;
        private Matrix cameraRotation;
        private Vector3 desiredPosition;
        private Vector3 desiredTarget;
        private Vector3 offsetDistance;
        private MouseState _prevMouseState;


        public Kamera()
        {
            ResetCamera();
        }
        public void ResetCamera()
        {
            position = new Vector3(0, 0, 100);
            target = new Vector3();

            viewMatrix = Matrix.Identity;
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60.0f), 16 / 9, .5f, 500f);
            yaw = 0.0f;
            pitch = 0.0f;
            roll = 0.0f;

            speed = .3f;

            cameraRotation = Matrix.Identity;
            desiredPosition = position;
            desiredTarget = target;

            offsetDistance = new Vector3(0, 45, 400);
        }

        public void Update(Matrix chasedObjectsWorld)
        {
            HandleInput();
            UpdateViewMatrix(chasedObjectsWorld);
        }

        private void HandleInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState st = Mouse.GetState();

            if (st.X < _prevMouseState.X)
            {
                yaw += .02f;
            }
            if (st.X > _prevMouseState.X)
            {
                yaw += -.02f;
            }
            if (keyboardState.IsKeyDown(Keys.U))
            {
                roll += -.02f;
            }
            if (keyboardState.IsKeyDown(Keys.O))
            {
                roll += .02f;
            }
        

            _prevMouseState = st;
        }

        private void MoveCamera(Vector3 addedVector)
        {
            position += speed * addedVector;
        }

        private void UpdateViewMatrix(Matrix chasedObjectsWorld)
        {


            cameraRotation.Forward.Normalize();
            chasedObjectsWorld.Right.Normalize();
            chasedObjectsWorld.Up.Normalize();

            cameraRotation = Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw) * Matrix.CreateFromAxisAngle(cameraRotation.Forward, roll);

            desiredTarget = chasedObjectsWorld.Translation;
            target = desiredTarget;
            target += chasedObjectsWorld.Right * yaw;
            target += chasedObjectsWorld.Up * pitch;

            desiredPosition = Vector3.Transform(offsetDistance, cameraRotation);
            desiredPosition += chasedObjectsWorld.Translation;
            position = desiredPosition;

            //target = chasedObjectsWorld.Translation;

            roll = MathHelper.SmoothStep(roll, 0f, .15f);

            viewMatrix = Matrix.CreateLookAt(position, target, cameraRotation.Up);


        }

    }
}
