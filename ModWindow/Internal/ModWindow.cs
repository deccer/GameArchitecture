using System;
using System.Drawing;
using Core;
using Core.Messages;
using OpenTK;
using OpenTK.Input;

namespace ModWindow.Internal
{
    internal class ModWindow : IWindow
    {
        public event Action<FrameEventArgs> OnUpdateFrame;

        public event Action<FrameEventArgs> OnRenderFrame;

        private readonly GameWindow _gameWindow;

        private readonly IMessageBus _messageBus;

        private readonly ILogger _logger;

        private readonly IInputHandler _inputHandler;

        private readonly IRenderer _renderer;

        private KeyboardState _previousKeyboardState;

        public ModWindow(IMessageBus messageBus, ILogger logger, IInputHandler inputHandler, IRenderer renderer)
        {
            _previousKeyboardState = Keyboard.GetState();

            _messageBus = messageBus;
            _logger = logger;
            _inputHandler = inputHandler;
            _renderer = renderer;
            _gameWindow = new GameWindow(800, 600);
            _gameWindow.Closed += GameWindowClosed;
            _gameWindow.UpdateFrame += GameWindowUpdateFrame;
            _gameWindow.RenderFrame += GameWindowRenderFrame;
            _gameWindow.Load += GameWindowLoad;
        }

        public void Close()
        {
            _gameWindow.Close();
        }

        public void Dispose()
        {
            _logger.Write("Cleanup - ModWindow");
            _renderer.Dispose();
        }

        public void Run()
        {
            _gameWindow.Run();
        }

        private void GameWindowLoad(object sender, EventArgs eventArgs)
        {
            _renderer.Initialize();
        }

        private void GameWindowUpdateFrame(object sender, FrameEventArgs eventArgs)
        {
            var currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState != _previousKeyboardState)
            {
                _inputHandler.NotifyInput(currentKeyboardState);
            }
            _previousKeyboardState = currentKeyboardState;
        }

        private void GameWindowRenderFrame(object sender, FrameEventArgs eventArgs)
        {
            _renderer.DrawRectangle(new Vector2(-0.5f, -0.5f), new Vector2(0.25f, 0.25f), Color.Yellow);
            _gameWindow.SwapBuffers();
        }

        private void GameWindowClosed(object sender, EventArgs eventArgs)
        {
            _messageBus.PublishWait(new QuitGameMessage());
        }
    }
}