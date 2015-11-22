using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PixelBlaster
{
    class Program
    {
        //Instantiate the game and start it
        static void Main(string[] args)
        {
            Game app = new Game();
            app.StartGame();
        }
    }
}
