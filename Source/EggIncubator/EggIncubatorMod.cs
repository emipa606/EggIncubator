using Mlie;
using UnityEngine;
using Verse;

namespace EggIncubator
{
    [StaticConstructorOnStartup]
    internal class EggIncubatorMod : Mod
    {
        /// <summary>
        ///     The instance of the settings to be read by the mod
        /// </summary>
        public static EggIncubatorMod instance;

        private static string currentVersion;


        /// <summary>
        ///     The private settings
        /// </summary>
        private EggIncubatorModSettings settings;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="content"></param>
        public EggIncubatorMod(ModContentPack content)
            : base(content)
        {
            instance = this;
            currentVersion =
                VersionFromManifest.GetVersionFromModMetaData(
                    ModLister.GetActiveModWithIdentifier("Mlie.EggIncubator"));
        }


        /// <summary>
        ///     The instance-settings for the mod
        /// </summary>
        internal EggIncubatorModSettings Settings
        {
            get
            {
                if (settings != null)
                {
                    return settings;
                }

                settings = GetSettings<EggIncubatorModSettings>();

                return settings;
            }

            set => settings = value;
        }

        /// <summary>
        ///     The settings-window
        /// </summary>
        /// <param name="rect"></param>
        public override void DoSettingsWindowContents(Rect rect)
        {
            base.DoSettingsWindowContents(rect);
            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect);
            listing_Standard.CheckboxLabeled("EI.increasespeed.label".Translate(), ref Settings.IncreaseIncubationSpeed,
                "EI.increasespeed.tooltip".Translate());
            if (currentVersion != null)
            {
                GUI.contentColor = Color.gray;
                listing_Standard.Label("EI.version.label".Translate(currentVersion));
                GUI.contentColor = Color.white;
            }

            listing_Standard.End();
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
}