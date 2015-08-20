﻿namespace WindowsPhoneDriver.OuterDriver.CommandExecutors
{
    using WindowsPhoneDriver.Common;

    internal class GetCurrentWindowHandleExecutor : CommandExecutorBase
    {
        #region Methods

        protected override string DoImpl()
        {
            // TODO: There is only one window for windows phone app, so it must be OK, or not?
            return this.JsonResponse(ResponseStatus.Success, "current");
        }

        #endregion
    }
}
