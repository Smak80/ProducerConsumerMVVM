namespace ProducerConsumerMVVM
{
    internal class MainViewModel
    {
        private readonly SceneObjects _objs = new();
        public event Action? UpdateScene;
        public List<ShapeData> Shapes => _objs.GetPreview();
        public MainViewModel()
        {
            new Producer(ObjectComponent.Red,   _objs).Start();
            new Producer(ObjectComponent.Green, _objs).Start();
            new Producer(ObjectComponent.Blue,  _objs).Start();
            Start();
        }

        private void Start()
        {
            var t = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        UpdateScene?.Invoke();
                    }
                    catch
                    {
                        break;
                    }
                    Thread.Sleep(30);
                }
            })
            {
                IsBackground = true
            };
            t.Start();
        }

    }
}