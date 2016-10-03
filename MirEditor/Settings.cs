using System.IO;
using System;
using System.Windows.Forms;

namespace MirEditor
{
    class Settings
    {
        public static int ScreenWidth = 800, ScreenHeight = 600;

        private static InIReader Reader = new InIReader(@".\MirEditor.ini");


        public static string DataPath = @".\Data\",
                            MapPath = @".\Map\",
                            SoundPath = @".\Sound\",
                            ExtraDataPath = @".\Data\Extra\",
                            ShadersPath = @".\Data\Shaders\",
                            MonsterPath = @".\Data\Monster\",
                            GatePath = @".\Data\Gate\",
                            FlagPath = @".\Data\Flag\",
                            NPCPath = @".\Data\NPC\",
                            CArmourPath = @".\Data\CArmour\",
                            CWeaponPath = @".\Data\CWeapon\",
                            CHairPath = @".\Data\CHair\",
                            AArmourPath = @".\Data\AArmour\",
                            AWeaponPath = @".\Data\AWeapon\",
                            AHairPath = @".\Data\AHair\",
                            ARArmourPath = @".\Data\ARArmour\",
                            ARWeaponPath = @".\Data\ARWeapon\",
                            ARHairPath = @".\Data\ARHair\",
                            CHumEffectPath = @".\Data\CHumEffect\",
                            AHumEffectPath = @".\Data\AHumEffect\",
                            ARHumEffectPath = @".\Data\ARHumEffect\",
                            MountPath = @".\Data\Mount\",
                            FishingPath = @".\Data\Fishing\",
                            PetsPath = @".\Data\Pet\",
                            TransformPath = @".\Data\Transform\",
                            TransformMountsPath = @".\Data\TransformRide2\",
                            TransformEffectPath = @".\Data\TransformEffect\",
                            TransformWeaponEffectPath = @".\Data\TransformWeaponEffect\",
                            DatabasePath = @".\Server.MirDB";

        // Logs
        public static bool LogErrors = true;
        public static int RemainingErrorLogs = 100;
        public static string MirPath = "";
      
        public static void Load()
        {
            MirPath = Reader.ReadString("Game", "MirPath", MirPath);
            LogErrors = Reader.ReadBoolean("Logs", "LogErrors", LogErrors);

            
            while( !Directory.Exists( MirPath + "\\Map") )
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "没有找到游戏目录，请设置";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MirPath = dialog.SelectedPath;
                    MessageBox.Show("已选择文件夹:" + MirPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Save();
                }
                
            }
                

            

            if (!Directory.Exists(DataPath)) Directory.CreateDirectory(DataPath);
            if (!Directory.Exists(MapPath)) Directory.CreateDirectory(MapPath);
            if (!Directory.Exists(SoundPath)) Directory.CreateDirectory(SoundPath);

            DataPath = MirPath + @"\" + @".\Data\";
            MapPath = MirPath + @"\" + @".\Map\";
            SoundPath = MirPath + @"\" + @".\Sound\";
            ExtraDataPath = MirPath + @"\" + @".\Data\Extra\";
            ShadersPath = MirPath + @"\" + @".\Data\Shaders\";
            MonsterPath = MirPath + @"\" + @".\Data\Monster\";
            GatePath = MirPath + @"\" + @".\Data\Gate\";
            FlagPath = MirPath + @"\" + @".\Data\Flag\";
            NPCPath = MirPath + @"\" + @".\Data\NPC\";
            CArmourPath = MirPath + @"\" + @".\Data\CArmour\";
            CWeaponPath = MirPath + @"\" + @".\Data\CWeapon\";
            CHairPath = MirPath + @"\" + @".\Data\CHair\";
            AArmourPath = MirPath + @"\" + @".\Data\AArmour\";
            AWeaponPath = MirPath + @"\" + @".\Data\AWeapon\";
            AHairPath = MirPath + @"\" + @".\Data\AHair\";
            ARArmourPath = MirPath + @"\" + @".\Data\ARArmour\";
            ARWeaponPath = MirPath + @"\" + @".\Data\ARWeapon\";
            ARHairPath = MirPath + @"\" + @".\Data\ARHair\";
            CHumEffectPath = MirPath + @"\" + @".\Data\CHumEffect\";
            AHumEffectPath = MirPath + @"\" + @".\Data\AHumEffect\";
            ARHumEffectPath = MirPath + @"\" + @".\Data\ARHumEffect\";
            MountPath = MirPath + @"\" + @".\Data\Mount\";
            FishingPath = MirPath + @"\" + @".\Data\Fishing\";
            PetsPath = MirPath + @"\" + @".\Data\Pet\";
            TransformPath = MirPath + @"\" + @".\Data\Transform\";
            TransformMountsPath = MirPath + @"\" + @".\Data\TransformRide2\";
            TransformEffectPath = MirPath + @"\" + @".\Data\TransformEffect\";
            TransformWeaponEffectPath = MirPath + @"\" + @".\Data\TransformWeaponEffect\";

            DatabasePath = MirPath + @".\Server.MirDB";
        }

        public static void Save()
        {
            //Graphics
            Reader.Write("Game", "MirPath", MirPath);
            Reader.Write("Logs", "LogErrors", LogErrors);
        }

    }
}
