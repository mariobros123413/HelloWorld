using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(800, 600); 
            Television televesion = new Television(window);
            window.Run();
            
        }
    }
}
