using System;
using System.Diagnostics.CodeAnalysis;
using PcapDotNet.Base;
using PcapDotNet.Packets.Arp;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.TestUtils;

namespace PcapDotNet.Packets.TestUtils
{
    [ExcludeFromCodeCoverage]
    public static class RandomArpExtensions
    {
        public static ArpLayer NextArpLayer(this Random random)
        {
            byte hardwareAddressLength = random.NextByte();
            byte protocolAddressLength = random.NextByte();
            return new ArpLayer
                   {
                       SenderHardwareAddress = random.NextBytes(hardwareAddressLength).AsReadOnlyCollection(),
                       SenderProtocolAddress = random.NextBytes(protocolAddressLength).AsReadOnlyCollection(),
                       TargetHardwareAddress = random.NextBytes(hardwareAddressLength).AsReadOnlyCollection(),
                       TargetProtocolAddress = random.NextBytes(protocolAddressLength).AsReadOnlyCollection(),
                       ProtocolType = random.NextEnum<EthernetType>(),
                       Operation = random.NextEnum<ArpOperation>(),
                   };
        }
    }
}