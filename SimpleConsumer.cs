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
                {"bootstrap.servers", "35.200.142.220:9092" },
                {"enable.auto.commit", "false" }
            };

            using (var consumer = new Consumer<Null, string>(config, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe("simpletest");
                 
                consumer.OnMessage += (_, msg) =>
                {
                    messgae(msg.Value);
                };
                
                //List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
                //Console.WriteLine(products.Count);
                //Product p1 = products[0];
                //Console.WriteLine(p1.Name);
                
                while (true)
                {
                    consumer.Poll(100);
                }
            }
        }

       
    }
}
