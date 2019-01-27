using System;
using System.Collections.Generic;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetCamera("nikon");
            Camera camera2 = Camera.GetCamera("asus");
            Camera camera3 = Camera.GetCamera("vestel");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);

            Console.ReadLine();
        }
    }

    class Camera
    {
        static Dictionary<string,Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        public Guid Id { get; set; }

        private Camera()
        {
            Id = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }

            return _cameras[brand];
        }
    }
}
