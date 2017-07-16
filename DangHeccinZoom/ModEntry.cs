using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using SFarmer = StardewValley.Farmer;

namespace DangHeccinZoom
{
    class ModEntry : Mod
    {
        bool sprinting = false;
        SFarmer player;

        public override void Entry(IModHelper helper)
        {
            ControlEvents.KeyPressed += this.ControlEvents_KeyPress;
            ControlEvents.KeyReleased += this.ControlEvents_KeyRelease;
            GameEvents.FourthUpdateTick += this.GameEvents_FourthTick;
            GameEvents.SecondUpdateTick += this.GameEvents_SecondTick;
        }

        private void ControlEvents_KeyPress(object sender, EventArgsKeyPressed e)
        {
            if (Context.IsWorldReady && e.KeyPressed.ToString() == "Space")
            {
                sprinting = true;
                player = Game1.player;
            }
        }

        private void ControlEvents_KeyRelease(object sender, EventArgsKeyPressed e)
        {
            if (Context.IsWorldReady && e.KeyPressed.ToString() == "Space")
            {
                sprinting = false;
                player = Game1.player;
            }
        }

        private void GameEvents_FourthTick(object sender, EventArgs e)
        {
            if (player != null)
            {
                if (sprinting && player.stamina > 20)
                    player.addedSpeed = 10;
                else
                    player.addedSpeed = 0;
            }
        }

        private void GameEvents_SecondTick(object sender, EventArgs e)
        {
            if (player != null && player.stamina > 20 && sprinting)
                player.stamina -= 0.1f;
        }
    }
}
