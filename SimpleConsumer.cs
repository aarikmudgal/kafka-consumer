using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace kafkaConsumer
{
    class SimpleConsumer : ISimpleConsumer
    {
        public void Listen(Action<string> messgae)
        {
            var config = new Dictionary<string, object>
            {
                {"group.id", "simple_consumer"},
                {"bootstrap.servers", "localhost:9092" },
                {"enable.auto.commit", "false" }
            };

            using (var consumer = new Consumer<Null, string>(config, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe("simpletest");
                 
                    
                consumer.OnMessage += (_, msg) =>
                {
                    messgae(msg.Value);
                };

                while (true)
                {
                    consumer.Poll(100);
                }
            }
        }

       
    }
}
