using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace PixelBlaster
{
    class Game
    {
        //Window
        RenderWindow _window;

        CircleShape circle;

        Sprite sprite;

        public uint XWindowSize { get; set; }
        public uint YWindowSize { get; set; }

        public uint WindowOffset { get; set; }

        //Open Window
        public void StartGame()
        {
            this.XWindowSize = 400;
            this.YWindowSize = 300;
            this.WindowOffset = 15;

            _window = new RenderWindow(new VideoMode(XWindowSize, YWindowSize), "Pixel Blaster");
            _window.SetVisible(true);
            _window.Closed += new EventHandler(OnClosed);
            _window.KeyPressed += new EventHandler<SFML.Window.KeyEventArgs>(OnKeyPress);
            
            

            circle = new CircleShape();
            circle.Radius = 25f;
            circle.FillColor = Color.Green;
            

            Vector2f vect = new Vector2f();
            vect.X = (float)XWindowSize / 2 - circle.Radius;
            vect.Y = 4 * (float)YWindowSize / 5;

            circle.Position = vect;

            float circleSpeed = 4.0f;

            sprite = new Sprite();
            sprite.Color = Color.Red;
            sprite.Scale = vect;

            while (_window.IsOpen )
            {
                _window.DispatchEvents();
                
                _window.Clear();

                handleMovement(circleSpeed);

                _window.Draw(circle);
                _window.Draw(sprite);
                _window.Display();
                
            }
        }

        private void handleMovement (float playerSpeed)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && _window.HasFocus() && circle.Position.X < XWindowSize - WindowOffset - circle.Radius * 2)
            {
                circle.Position += new Vector2f(playerSpeed, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && _window.HasFocus() && circle.Position.X > WindowOffset)
            {
                circle.Position += new Vector2f(-playerSpeed, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && _window.HasFocus() && circle.Position.Y > WindowOffset)
            {
                circle.Position += new Vector2f(0, -playerSpeed);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && _window.HasFocus() && circle.Position.Y < YWindowSize - WindowOffset - circle.Radius * 2)
            {
                circle.Position += new Vector2f(0, playerSpeed);
            }
        }

        void OnClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
        // Keyboard
        void OnKeyPress(object sender, EventArgs e)
        {
            //if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            //{
            //    circle.Position += new Vector2f(25f, 0);
            //}
            //if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            //{
            //    circle.Position += new Vector2f(-25f, 0);
            //}
            //if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            //{
            //    circle.Position += new Vector2f(0, -25f);
            //}
            //if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            //{
            //    circle.Position += new Vector2f(0, 25f);
            //}
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _window.Close();
            }
        }
    }
}
