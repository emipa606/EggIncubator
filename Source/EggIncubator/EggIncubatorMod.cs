﻿using Mlie;
using UnityEngine;
using Verse;

namespace EggIncubator;

[StaticConstructorOnStartup]
internal class EggIncubatorMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static EggIncubatorMod Instance;

    private static string currentVersion;


    /// <summary>
    ///     The private settings
    /// </summary>
    public readonly EggIncubatorModSettings Settings;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public EggIncubatorMod(ModContentPack content)
        : base(content)
    {
        Instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
        Settings = GetSettings<EggIncubatorModSettings>();
    }


    /// <summary>
    ///     The settings-window
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        base.DoSettingsWindowContents(rect);
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.CheckboxLabeled("EI.increasespeed.label".Translate(), ref Settings.IncreaseIncubationSpeed,
            "EI.increasespeed.tooltip".Translate());
        if (currentVersion != null)
        {
            GUI.contentColor = Color.gray;
            listingStandard.Label("EI.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }


    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Egg Incubator";
    }
}