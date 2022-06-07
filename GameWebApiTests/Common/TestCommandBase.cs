using GameWebApi.Database;
using System;

namespace GameWebApiTests.Common
{
    public abstract class TestCommandBase:IDisposable
    {
        protected readonly GameContext Context;

        public TestCommandBase()
        {
            Context = GameContextFactory.Create();
        }

        public void Dispose()
        {
            GameContextFactory.Destroy(Context);
        }
    }
}
