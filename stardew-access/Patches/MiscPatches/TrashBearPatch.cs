using StardewValley;
using StardewValley.Characters;

namespace stardew_access.Patches
{
    internal class TrashBearPatch
    {
        internal static void CheckActionPatch(TrashBear __instance, bool __result, int ___itemWantedIndex, int ___showWantBubbleTimer)
        {
            try
            {
                if (__result) return; // The true `true` value of __result indicates the bear is interactable i.e. when giving the bear the wanted item
                if (__instance.Sprite.CurrentAnimation != null) return;

                string itemName = Game1.objectInformation[___itemWantedIndex].Split('/')[4];
                MainClass.ScreenReader.Say(MainClass.Translate("patch.trash_bear.wanted_item", new {trash_bear_name = __instance.displayName, item_name = itemName}), true);
            }
            catch (Exception e)
            {
                MainClass.ErrorLog($"An error occured TrashBearPatch::CheckActionPatch():\n{e.Message}\n{e.StackTrace}");
            }
        }
    }
}
