using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace RoverGUI
{
 
    public class RenderSurface : Game
    {
        Texture2D RoverTexture;
        Texture2D PathTexture;

        public float RoverAngle;
        public float PathAngle;
        Rectangle Path = new Rectangle();
        Vector2 RoverOrigin;
        Vector2 PathOrigin;


        public Vector2 RoverPosition;
        public Vector2 PathPosition;
        public string RenderStartPosition(string startposition)
        {
            string[] _startpositionArray = startposition.Split(' ');

            
            RoverPosition = new Vector2(int.Parse(_startpositionArray[0]), int.Parse(_startpositionArray[1]));
            PathPosition = RoverPosition;

            switch (_startpositionArray[2])
            {
                case "N":
                    RoverAngle = 0.0f;
                    break;
                case "E":
                    RoverAngle = 90.0f;
                    break;
                case "S":
                    RoverAngle = 180.0f;
                    break;
                case "W":
                    RoverAngle = 270.0f;
                    break;
            };


            return startposition;
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        MoveCommand roverMoveCommand;

        public RenderSurface()
        {
            _graphics = new GraphicsDeviceManager(this);
 
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            _graphics.PreferredBackBufferWidth = 900;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 900;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            RoverTexture = Content.Load<Texture2D>("rover");
            PathTexture = Content.Load<Texture2D>("path");

            RoverOrigin = new Vector2(RoverTexture.Width / 2, RoverTexture.Height / 2);
            PathOrigin = new Vector2(PathTexture.Width / 2, PathTexture.Height / 2);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(PathTexture, PathPosition, null, Color.White, PathAngle * (MathHelper.Pi / 180), PathOrigin,
                 0.2f, SpriteEffects.None, 0);

            _spriteBatch.Draw(RoverTexture, RoverPosition, null, Color.WhiteSmoke, RoverAngle * (MathHelper.Pi / 180), RoverOrigin,
                            0.2f, SpriteEffects.None, 0);

 

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
