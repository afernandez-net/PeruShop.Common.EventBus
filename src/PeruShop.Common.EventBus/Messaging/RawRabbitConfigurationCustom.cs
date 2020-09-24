using RawRabbit.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeruShop.Common.EventBus.Messaging
{
    public class RawRabbitConfigurationCustom : RawRabbitConfiguration
    {
        public string NameExchange { get; set; }
    }
}
