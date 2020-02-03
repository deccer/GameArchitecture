using System.ComponentModel;
using Core;
using Core.Messages;
using OpenTK;

namespace ModWindow.Internal
{
    internal class ModWindow : IWindow
    {
        private readonly GameWindow _gameWindow;
        private readonly MessageBus _messageBus;

        public ModWindow(MessageBus messageBus)
        {
            _messageBus = messageBus;
            _gameWindow = new GameWindow(800, 600);
            _gameWindow.Closing += GameWindowClosing;
        }

        public void Close()
        {
            _gameWindow.Close();
        }

        public void Show()
        {
            _gameWindow.Run();
        }

        private void GameWindowClosing(object sender, CancelEventArgs eventArgs)
        {
            _messageBus.PublishWait(new QuitGameMessage());
        }
    }
}