class Api::V1::GeneStoriesController < ApplicationController
    def index
        prompt = "はじけた話を20文字程度でしてください"
        client = OpenAI::Client.new(access_token: ENV['OPENAI_API_KEY'])
        response = client.chat(
            parameters: {
                model: "gpt-3.5-turbo",
                messages: [{ role: "user", content: prompt}],
                temperature: 0.7,
            })
        gene_story01 = response.dig("choices", 0, "message", "content")

        prompt = "他のはじけた話を20文字程度でしてください"
        response = client.chat(
            parameters: {
                model: "gpt-3.5-turbo",
                messages: [{ role: "user", content: prompt}],
                temperature: 0.7,
            })
        gene_story02 = response.dig("choices", 0, "message", "content")

        prompt = "他のはじけた話を20文字程度でしてください"
        response = client.chat(
            parameters: {
                model: "gpt-3.5-turbo",
                messages: [{ role: "user", content: prompt}],
                temperature: 0.7,
            })
        gene_story03 = response.dig("choices", 0, "message", "content")
        render json: { status: 'SUCCESS', message: 'Loaded lobbies', geneStory01: gene_story01, geneStory02: gene_story02, geneStory03: gene_story03}
    end
end
