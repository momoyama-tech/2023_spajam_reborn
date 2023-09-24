class Api::V1::StoriesController < ApplicationController
    def index
        stories = Story.all
        render json: { status: 'SUCCESS', message: 'Loaded lobbies', story01: stories[0].story, story02: stories[1].story, story03: stories[2].story, story04: stories[3].story}
    end

    def create        
        Story.create(story: params.keys[0])
        if (Story.count >= ActionCable.server.connections.length)
            ActionCable.server.broadcast("LobbyChannel", "start_talk")
        end
        render json: { status: 'SUCCESS', message: 'Loaded lobbies'}
    end
end
