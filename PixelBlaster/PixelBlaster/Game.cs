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

        //Open Window
        public void StartGame()
        {

            _window = new RenderWindow(new VideoMode(800, 600), "Pixel Blaster");
            _window.SetVisible(true);
            _window.Closed += new EventHandler(OnClosed);
            _window.KeyPressed += new EventHandler<SFML.Window.KeyEventArgs>(OnKeyPress);
            

            circle = new CircleShape();
            circle.Radius = 50f;
            circle.FillColor = Color.Green;
            

            Vector2f vect = new Vector2f();
            vect.X = 25f;
            vect.Y = 25f;

            circle.Position = vect;

            sprite = new Sprite();
            sprite.Color = Color.Red;
            sprite.Scale = vect;

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();
                _window.Draw(circle);
                _window.Draw(sprite);
                _window.Display();
            }
        }

        void OnClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
        // Keyboard
        void OnKeyPress(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                circle.Position += new Vector2f(25f, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                circle.Position += new Vector2f(-25f, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                circle.Position += new Vector2f(0, -25f);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                circle.Position += new Vector2f(0, 25f);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                _window.Close();
            }
        }
    }
}
