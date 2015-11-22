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
    class Object
    {
        public CircleShape shape { get; set; }

        public Object()
        {
            shape.FillColor = Color.Green;
            shape.Radius = 50F;
        }



    }
}
