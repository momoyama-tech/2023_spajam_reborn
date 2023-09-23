Rails.application.routes.draw do
  mount ActionCable.server, at: '/cable'

  namespace 'api' do
    namespace 'v1' do
      resources :posts
      resources :lobbies
    end
  end
end