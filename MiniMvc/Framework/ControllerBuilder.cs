﻿using System;

namespace MiniMvc.Framework
{
    public  class ControllerBuilder
    {
        private Func<IControllerFactory> factoryThunk;
        public static ControllerBuilder Current { get; private set; }

        static ControllerBuilder()
        {
            Current = new ControllerBuilder();
        }

        public IControllerFactory GetControllerFactory()
        {
            return factoryThunk();
        }

        public void SetControllerFactory(IControllerFactory controllerFactory)
        {
            factoryThunk = () => controllerFactory;
        }
    }
}