using System.Windows.Media;

namespace ProducerConsumerMVVM
{
    public enum ObjectComponent
    {
        Red, Green, Blue
    }

    public class SceneObjects
    {
        private readonly Dictionary<ObjectComponent, Queue<ShapeData>> _data = new ();
        public SceneObjects()
        {
            lock (_data)
            {
                _data.Add(ObjectComponent.Red, new Queue<ShapeData>());
                _data.Add(ObjectComponent.Green, new Queue<ShapeData>());
                _data.Add(ObjectComponent.Blue, new Queue<ShapeData>());
            }
        }

        public bool Update(ObjectComponent type)
        {
            lock (_data)
            {
                var sd = _data[type].Peek();
                sd.X++;
            }

            return true;
        }

        public void CreateNew(ObjectComponent type, byte color)
        {
            var sd = new ShapeData
            {
                X = 0,
                Y = type switch
                {
                    ObjectComponent.Red => 0,
                    ObjectComponent.Green => 100,
                    ObjectComponent.Blue => 200,
                    _ => -1000,
                },
                Color = Color.FromArgb( 
                    255,
                    type == ObjectComponent.Red   ? color : (byte)0,
                    type == ObjectComponent.Green ? color : (byte)0,
                    type == ObjectComponent.Blue  ? color : (byte)0)
            };
            lock (_data)
            {
                _data[type].Enqueue(sd);
            }
        }

        public List<ShapeData> GetPreview()
        {
            var lst = new List<ShapeData>();
            lock (_data)
            {
                foreach (var (t, qsd) in _data)
                {
                    foreach (var shapeData in qsd)
                    {
                        lst.Add(shapeData);
                    }
                }
            }
            return lst;
        }
    }
}