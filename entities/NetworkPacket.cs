namespace NetMonitor.entities;

public class NetworkPacket
{
    private char SourceIp { get; set; }
    private char DestinationIp { get; set; }
    private char SourcePort { get; set; }
    private char DestinationPort { get; set; }
    private Protocol protocol { get; set; }
    private byte[] packetSize { get; set; }
    private DateTime packetTime { get; set; }

    public NetworkPacket(char SourceIp, char DestinationIp, char SourcePort, char DestinationPort, Protocol protocol,
        byte[] packetSize, DateTime packetTime)
    {
        this.SourceIp = SourceIp;
        this.DestinationIp = DestinationIp;
        this.SourcePort = SourcePort;
        this.DestinationPort = DestinationPort;
        this.protocol = protocol;
        this.packetSize = packetSize;
        this.packetTime = packetTime;
    }
    
    
}