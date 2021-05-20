using System;
using System.Diagnostics;

namespace Benchmark
{
    public class BenchEngine
    {
        private readonly IObjectToObjectMapper _mapper;
        private readonly string _mode;

        public BenchEngine(IObjectToObjectMapper mapper, string mode)
        {
            _mapper = mapper;
            _mode = mode;
        }

        public void Start()
        {
            var timer = Stopwatch.StartNew();
            _mapper.Initialize();
            _mapper.Map();

            Console.WriteLine("{0}: - {1} - To First Map: \t{2}ms", _mapper.Name, _mode, timer.Elapsed.TotalMilliseconds);


            for (int i = 0; i < 1000000; i++)
            {
                _mapper.Map();
            }

            timer.Stop();

            Console.WriteLine("{0}: - {1} - Mapping time: \t{2}ms", _mapper.Name, _mode, timer.Elapsed.TotalMilliseconds);
        }
    }
}