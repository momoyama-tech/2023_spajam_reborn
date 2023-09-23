public class WebSocketRequestSubscribe
{
    public string command { get; set; }
    public string identifier { get; set; }
    public WebSocketRequestSubscribe(string command, string channel)
    {
        this.command = command;
        this.identifier = "{\"channel\": \"" + channel + "\"}";
    }
}