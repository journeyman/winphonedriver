﻿namespace WindowsPhoneDriver.OuterDriver.CommandExecutors
{
    internal class ClickElementExecutor : CommandExecutorBase
    {
        #region Methods

        protected override string DoImpl()
        {
            var location = this.Automator.RequestElementLocation(this.ExecutedCommand.Parameters["ID"] as string);

            if (!location.HasValue)
            {
                // TODO return bad parameters?
                return this.JsonResponse();
            }

            this.Automator.EmulatorController.LeftButtonClick(location.Value);

            return this.JsonResponse();
        }

        #endregion
    }
}
