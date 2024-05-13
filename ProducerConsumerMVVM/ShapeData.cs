using System.Windows.Media;

namespace ProducerConsumerMVVM
{
    public class ShapeData
    {
        public bool IsReady { get; set; } = false;
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
    }
}
