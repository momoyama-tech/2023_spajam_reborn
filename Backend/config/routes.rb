Rails.application.routes.draw do
  mount ActionCable.server, at: '/cable'

  namespace 'api' do
    namespace 'v1' do
      resources :gene_stories
      resources :hajike_stories
      resources :lobbies
      resources :stories
    end
  end
end