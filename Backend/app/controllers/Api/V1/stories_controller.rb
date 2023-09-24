class Api::V1::StoriesController < ApplicationController
    def index
        render json: { status: 'SUCCESS', message: 'Loaded lobbies'}
    end

    def create        
        Story.create(story: params.keys[0])
        if (Story.count >= ActionCable.server.connections.length)
            ActionCable.server.broadcast("LobbyChannel", "start_talk")
        end
        render json: { status: 'SUCCESS', message: 'Loaded lobbies'}
    end
end
