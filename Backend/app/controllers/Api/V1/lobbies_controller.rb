class Api::V1::LobbiesController < ApplicationController
    def index
        render json: { status: 'SUCCESS', message: 'Loaded lobbies', userCount: User.count}
    end
end
