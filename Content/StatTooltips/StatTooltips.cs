﻿namespace AccessoriesPlus.Content.StatTooltips;
// TODO stat tooltips
internal class StatTooltips : GlobalItem
{
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        // Getting stats
        var wingStats = WingStats.Get(item);
        var hookStats = HookStats.Get(item);
        var lightPetStats = LightPetStats.Get(item);
        var minecartStats = MinecartStats.Get(item);
        var mountStats = MountStats.Get(item);

        // Wings
        if (Config.Instance.StatsWings && wingStats != null)
        {
            AddMiscLine(tooltips, wingStats, "Equipable", after: true);
            var wingTooltips = new List<TooltipLine>
            {
                Util.GetTooltipLine("WingStats.NegatesFallDamage"),
            };

            tooltips.InsertTooltips("Equipable", after: true, wingTooltips.ToArray());
        }

        // Hooks
        if (Config.Instance.StatsHooks && hookStats != null)
        {
            // TODO - Fix conversions
            AddMiscLine(tooltips, hookStats, "Equipable", after: true);
            var hookTooltips = new List<TooltipLine>
            {
                hookStats.Reach != -1 ? Util.GetTooltipLine("HookStats.Reach", Util.RoundToNearest(hookStats.Reach/* / 16f*/)) : Util.GetTooltipLine("HookStats.ReachUnknown"),
                hookStats.NumHooks != -1 ? Util.GetTooltipLine("HookStats.NumHooks", hookStats.NumHooks) : Util.GetTooltipLine("HookStats.NumHooksUnknown"),
                Util.GetTooltipLine(hookStats.Latching switch
                {
                    HookStats.LatchingMode.Single => "HookStats.LatchingSingle",
                    HookStats.LatchingMode.Individual => "HookStats.LatchingIndividual",
                    HookStats.LatchingMode.Simultaneous => "HookStats.LatchingSimultaneous",
                    _ => "HookStats.LatchingUnknown",
                }),
                hookStats.ShootSpeed != -1 ? Util.GetTooltipLine("HookStats.ShootSpeed", Util.RoundToNearest(hookStats.ShootSpeed * Util.PPTToMPH)) : Util.GetTooltipLine("HookStats.ShootSpeedUnknown"),
                hookStats.RetreatSpeed != -1 ? Util.GetTooltipLine("HookStats.RetreatSpeed", Util.RoundToNearest(hookStats.RetreatSpeed * Util.PPTToMPH)) : Util.GetTooltipLine("HookStats.RetreatSpeedUnknown"),
                hookStats.PullSpeed != -1 ? Util.GetTooltipLine("HookStats.PullSpeed", Util.RoundToNearest(hookStats.PullSpeed * Util.PPTToMPH)) : Util.GetTooltipLine("HookStats.PullSpeedUnknown"),
            };

            tooltips.InsertTooltips("Equipable", after: true, hookTooltips.ToArray());
        }

        // Light pets
        if (Config.Instance.StatsLightPets && lightPetStats != null)
        {
            AddMiscLine(tooltips, lightPetStats, "Equipable", after: true);
            var lightPetTooltips = new List<TooltipLine>
            {
                Util.GetTooltipLine("LightPetStats.Brightness", lightPetStats.Brightness != -1f ? (int)(lightPetStats.Brightness * 100f) : Util.GetTextValue("Unknown"))
            };

            if (lightPetStats.Controllable)
                lightPetTooltips.Add(Util.GetTooltipLine("LightPetStats.Controllable"));
            if (lightPetStats.ExposesEnemies)
                lightPetTooltips.Add(Util.GetTooltipLine("LightPetStats.ExposesEnemies"));
            if (lightPetStats.ExposesTreasure)
                lightPetTooltips.Add(Util.GetTooltipLine("LightPetStats.ExposesTreasure"));

            tooltips.InsertTooltips("Equipable", after: true, lightPetTooltips.ToArray());
        }

        // Minecarts
        if (Config.Instance.StatsMinecarts && minecartStats != null)
        {
            AddMiscLine(tooltips, minecartStats, "Equipable", after: true);
            var minecartTooltips = new List<TooltipLine>
            {
                Util.GetTooltipLine("MinecartStats.MaxSpeed", (int)minecartStats.MaxSpeed),
                Util.GetTooltipLine("MinecartStats.Acceleration", (int)minecartStats.Acceleration)
            };

            tooltips.InsertTooltips("Equipable", after: true, minecartTooltips.ToArray());
        }

        // Mounts
        if (Config.Instance.StatsMounts && mountStats != null)
        {

        }
    }

    // Adds the misc info to the tooltips
    // TODO - is misc line even needed
    private static void AddMiscLine(List<TooltipLine> tooltips, Stats stats, string nameToInsertAfter, bool after)
    {
        if (!string.IsNullOrEmpty(stats.Misc))
            tooltips.InsertTooltips(nameToInsertAfter, after, Util.GetTooltipLine(stats.Misc));
    }
}
