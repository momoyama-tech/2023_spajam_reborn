class Api::V1::LobbiesController < ApplicationController
    def index
        # render json: { status: 'SUCCESS', message: 'Loaded lobbies', userCount: User.count}
        render json: { status: 'SUCCESS', message: 'Loaded lobbies', userCount: ActionCable.server.connections.length}
    end
end
