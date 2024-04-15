using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Puntos
    {
        public Vector3[] Vertices { get; }

        public Puntos(Vector3[] vertices)
        {
            Vertices = vertices ?? throw new ArgumentNullException(nameof(vertices));
        }
    }
}
