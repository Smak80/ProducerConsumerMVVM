using System.Windows.Media;

namespace ProducerConsumerMVVM
{
    public class Producer(
        ObjectComponent type, 
        SceneObjects objs
    ) {
        private readonly Random _rnd = new();
        public void Start()
        {

            new Thread(() =>
            {
                while (true) // Цикл производства объектов
                {
                    Generate();
                    var pauseTime = _rnd.Next(10, 100);
                    while (Move()) // Цикл движения объекта
                    {
                        Thread.Sleep(pauseTime);
                    }
                }
            })
            {
                IsBackground = true
            }.Start();

        }

        private bool Move()
        {
            return objs.Update(type);
        }

        private void Generate()
        {
            objs.CreateNew(type, (byte)_rnd.Next(256));
        }
    }
}
