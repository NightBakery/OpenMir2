﻿using GameSvr.Player;

namespace GameSvr.Command.Commands
{
    /// <summary>
    /// ShowOpen
    /// </summary>
    [Command("ShowOpen", "", "", 10)]
    public class ShowHumanUnitOpenCommand : Commond
    {
        [ExecuteCommand]
        public void ShowOpen(string[] @params, PlayObject playObject)
        {

        }
    }
}