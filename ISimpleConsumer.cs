using System;
using System.Collections.Generic;
using System.Text;

namespace kafkaConsumer
{
    interface ISimpleConsumer
    {
        void Listen(Action<string> messgae);
    }
}
