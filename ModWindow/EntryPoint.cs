﻿using Core;
using System;
using DryIoc;

namespace ModWindow
{
    public static class EntryPoint
    {
        public static void Register(IRegistrator registrator)
        {
            registrator.Register<IInputHandler, Internal.WindowInputHandler>(Reuse.Singleton);
            registrator.Register<IWindow, Internal.ModWindow>(Reuse.Singleton);
        }
    }
}