public class WebSocketRequestMessage
{
    public string command { get; set; }
    public string identifier { get; set; }
    public string data { get; set; }
    public WebSocketRequestMessage(string command, string channel, string action, string message)
    {
        this.command = command;
        this.identifier = "{\"channel\": \"" + channel + "\"}";
        this.data = "{\"message\": \"" + message + "\" , \"action\": \"" + action + "\"}";
    }
}