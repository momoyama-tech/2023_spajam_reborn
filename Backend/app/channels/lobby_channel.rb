class LobbyChannel < ApplicationCable::Channel
  def subscribed
    stream_from "LobbyChannel"
  end

  def unsubscribed
    # Any cleanup needed when channel is unsubscribed
  end

  def lobbies(data)
    if data['message'] == 'lobby_init'
      ActionCable.server.broadcast("LobbyChannel", "lobby_init")
    else
      ActionCable.server.broadcast("LobbyChannel", "continue")
    end
  end
end
