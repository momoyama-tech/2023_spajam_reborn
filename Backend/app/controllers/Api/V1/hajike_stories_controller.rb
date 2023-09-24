class Api::V1::HajikeStoriesController < ApplicationController
    def index
        render json: { status: 'SUCCESS', message: 'Loaded lobbies'}
    end

    def create
        prompt = "#{params.keys[0]}を20文字程度でまとめてください"
        client = OpenAI::Client.new(access_token: ENV['OPENAI_API_KEY'])
        response = client.chat(
            parameters: {
                model: "gpt-3.5-turbo",
                messages: [{ role: "user", content: prompt}],
                temperature: 0.7,
            })
        gene_story = response.dig("choices", 0, "message", "content")
        Story.create(story:gene_story)
        if (Story.count >= ActionCable.server.connections.length)
            ActionCable.server.broadcast("LobbyChannel", "start_talk")
        end
        render json: { status: 'SUCCESS', message: 'Loaded lobbies'}
    end
end
