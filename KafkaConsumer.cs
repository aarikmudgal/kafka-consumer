using System;

namespace kafkaConsumer
{
    class KafkaConsumer
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var simpleConsumer = new SimpleConsumer();
            simpleConsumer.Listen(Console.WriteLine);
        }
    }
}
