using System;
using Core;
using Core.Messages;
using OpenTK;

namespace ModWindow.Internal
{
    internal class ModWindow : IWindow
    {
        public event Action<FrameEventArgs> OnUpdateFrame;
        public event Action<FrameEventArgs> OnRenderFrame;

        private readonly GameWindow _gameWindow;

        private readonly MessageBus _messageBus;

        public ModWindow(MessageBus messageBus)
        {
            _messageBus = messageBus;
            _gameWindow = new GameWindow(800, 600);
            _gameWindow.Closed += GameWindowClosed;
            _gameWindow.UpdateFrame += GameWindowUpdateFrame;
            _gameWindow.RenderFrame += GameWindowRenderFrame;
        }

        public void Close()
        {
            _gameWindow.Close();
        }

        public void Run()
        {
            _gameWindow.Run();
        }

        private void GameWindowUpdateFrame(object sender, FrameEventArgs eventArgs)
        {
        }

        private void GameWindowRenderFrame(object sender, FrameEventArgs eventArgs)
        {
        }

        private void GameWindowClosed(object sender, EventArgs eventArgs)
        {
            _messageBus.PublishWait(new QuitGameMessage());
        }
    }
}