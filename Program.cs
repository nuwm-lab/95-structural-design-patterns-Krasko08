using System;

namespace NetworkPacketBuilder
{
    // === Product ===
    public class DataPacket
    {
        public string DataType { get; set; }
        public string Source { get; set; }
        public string Receiver { get; set; }

        public override string ToString()
        {
            return $"Packet:\n" +
                   $"- Data Type: {DataType}\n" +
                   $"- Source: {Source}\n" +
                   $"- Receiver: {Receiver}";
        }
    }

    // === Builder Interface ===
    public interface IDataPacketBuilder
    {
        IDataPacketBuilder SetDataType(string type);
        IDataPacketBuilder SetSource(string source);
        IDataPacketBuilder SetReceiver(string receiver);
        DataPacket Build();
    }

    // === Concrete Builder ===
    public class DataPacketBuilder : IDataPacketBuilder
    {
        private readonly DataPacket packet = new DataPacket();

        public IDataPacketBuilder SetDataType(string type)
        {
            packet.DataType = type;
            return this;
        }

        public IDataPacketBuilder SetSource(string source)
        {
            packet.Source = source;
            return this;
        }

        public IDataPacketBuilder SetReceiver(string receiver)
        {
            packet.Receiver = receiver;
            return this;
        }

        public DataPacket Build() => packet;
    }

    // === Director (необов’язково, але красиво) ===
    public class PacketDirector
    {
        public DataPacket CreateJsonPacket(IDataPacketBuilder builder)
        {
            return builder
                .SetDataType("JSON")
                .SetSource("Client")
                .SetReceiver("Server")
                .Build();
        }
    }

    // === Main ===
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new DataPacketBuilder();
            var director = new PacketDirector();

            DataPacket packet = director.CreateJsonPacket(builder);

            Console.WriteLine(packet);
        }
    }
}
