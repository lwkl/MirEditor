using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.IO.Compression;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace MirEditor
{
    public static class Libraries
    {
        public static bool Loaded;
        public static int Count, Progress;

        public static readonly MLibrary
            ChrSel = new MLibrary(Settings.DataPath + "ChrSel"),
            Prguse = new MLibrary(Settings.DataPath + "Prguse"),
            Prguse2 = new MLibrary(Settings.DataPath + "Prguse2"),
            BuffIcon = new MLibrary(Settings.DataPath + "BuffIcon"),
            Help = new MLibrary(Settings.DataPath + "Help"),
            MiniMap = new MLibrary(Settings.DataPath + "MMap"),
            Title = new MLibrary(Settings.DataPath + "Title"),
            MagIcon = new MLibrary(Settings.DataPath + "MagIcon"),
            MagIcon2 = new MLibrary(Settings.DataPath + "MagIcon2"),
            Magic = new MLibrary(Settings.DataPath + "Magic"),
            Magic2 = new MLibrary(Settings.DataPath + "Magic2"),
            Magic3 = new MLibrary(Settings.DataPath + "Magic3"),
            Effect = new MLibrary(Settings.DataPath + "Effect"),
            MagicC = new MLibrary(Settings.DataPath + "MagicC"),
            GuildSkill = new MLibrary(Settings.DataPath + "GuildSkill");

        public static readonly MLibrary
            Background = new MLibrary(Settings.DataPath + "Background");



        public static readonly MLibrary
            Dragon = new MLibrary(Settings.DataPath + "Dragon");

        //Map
        public static readonly MLibrary[] MapLibs = new MLibrary[400];

        //Items
        public static readonly MLibrary
            Items = new MLibrary(Settings.DataPath + "Items"),
            StateItems = new MLibrary(Settings.DataPath + "StateItem"),
            FloorItems = new MLibrary(Settings.DataPath + "DNItems");

        //Deco
        public static readonly MLibrary
            Deco = new MLibrary(Settings.DataPath + "Deco");

        public static readonly MLibrary[] CArmours = new MLibrary[42],
                                          CWeapons = new MLibrary[55],
                                          CHair = new MLibrary[9],
                                          CHumEffect = new MLibrary[3],
                                          AArmours = new MLibrary[17],
                                          AWeaponsL = new MLibrary[14],
                                          AWeaponsR = new MLibrary[14],
                                          AHair = new MLibrary[9],
                                          AHumEffect = new MLibrary[3],
                                          ARArmours = new MLibrary[17],
                                          ARWeapons = new MLibrary[19],
                                          ARWeaponsS = new MLibrary[19],
                                          ARHair = new MLibrary[9],
                                          ARHumEffect = new MLibrary[3],
                                          Monsters = new MLibrary[406],
                                          Gates = new MLibrary[2],
                                          Flags = new MLibrary[12],
                                          Mounts = new MLibrary[12],
                                          NPCs = new MLibrary[200],
                                          Fishing = new MLibrary[2],
                                          Pets = new MLibrary[12],
                                          Transform = new MLibrary[28],
                                          TransformMounts = new MLibrary[28],
                                          TransformEffect = new MLibrary[2],
                                          TransformWeaponEffect = new MLibrary[1];

        static Libraries()
        {
            //Wiz/War/Tao
            for (int i = 0; i < CArmours.Length; i++)
                CArmours[i] = new MLibrary(Settings.CArmourPath + i.ToString("00"));

            for (int i = 0; i < CHair.Length; i++)
                CHair[i] = new MLibrary(Settings.CHairPath + i.ToString("00"));

            for (int i = 0; i < CWeapons.Length; i++)
                CWeapons[i] = new MLibrary(Settings.CWeaponPath + i.ToString("00"));

            for (int i = 0; i < CHumEffect.Length; i++)
                CHumEffect[i] = new MLibrary(Settings.CHumEffectPath + i.ToString("00"));

            //Assassin
            for (int i = 0; i < AArmours.Length; i++)
                AArmours[i] = new MLibrary(Settings.AArmourPath + i.ToString("00"));

            for (int i = 0; i < AHair.Length; i++)
                AHair[i] = new MLibrary(Settings.AHairPath + i.ToString("00"));

            for (int i = 0; i < AWeaponsL.Length; i++)
                AWeaponsL[i] = new MLibrary(Settings.AWeaponPath + i.ToString("00") + " L");

            for (int i = 0; i < AWeaponsR.Length; i++)
                AWeaponsR[i] = new MLibrary(Settings.AWeaponPath + i.ToString("00") + " R");

            for (int i = 0; i < AHumEffect.Length; i++)
                AHumEffect[i] = new MLibrary(Settings.AHumEffectPath + i.ToString("00"));

            //Archer
            for (int i = 0; i < ARArmours.Length; i++)
                ARArmours[i] = new MLibrary(Settings.ARArmourPath + i.ToString("00"));

            for (int i = 0; i < ARHair.Length; i++)
                ARHair[i] = new MLibrary(Settings.ARHairPath + i.ToString("00"));

            for (int i = 0; i < ARWeapons.Length; i++)
                ARWeapons[i] = new MLibrary(Settings.ARWeaponPath + i.ToString("00"));

            for (int i = 0; i < ARWeaponsS.Length; i++)
                ARWeaponsS[i] = new MLibrary(Settings.ARWeaponPath + i.ToString("00") + " S");

            for (int i = 0; i < ARHumEffect.Length; i++)
                ARHumEffect[i] = new MLibrary(Settings.ARHumEffectPath + i.ToString("00"));

            //Other
            for (int i = 0; i < Monsters.Length; i++)
                Monsters[i] = new MLibrary(Settings.MonsterPath + i.ToString("000"));

            for (int i = 0; i < Gates.Length; i++)
                Gates[i] = new MLibrary(Settings.GatePath + i.ToString("00"));

            for (int i = 0; i < Flags.Length; i++)
                Flags[i] = new MLibrary(Settings.FlagPath + i.ToString("00"));

            for (int i = 0; i < NPCs.Length; i++)
                NPCs[i] = new MLibrary(Settings.NPCPath + i.ToString("00"));

            for (int i = 0; i < Mounts.Length; i++)
                Mounts[i] = new MLibrary(Settings.MountPath + i.ToString("00"));

            for (int i = 0; i < Fishing.Length; i++)
                Fishing[i] = new MLibrary(Settings.FishingPath + i.ToString("00"));

            for (int i = 0; i < Pets.Length; i++)
                Pets[i] = new MLibrary(Settings.PetsPath + i.ToString("00"));

            for (int i = 0; i < Transform.Length; i++)
                Transform[i] = new MLibrary(Settings.TransformPath + i.ToString("00"));

            for (int i = 0; i < TransformMounts.Length; i++)
                TransformMounts[i] = new MLibrary(Settings.TransformMountsPath + i.ToString("00"));

            for (int i = 0; i < TransformEffect.Length; i++)
                TransformEffect[i] = new MLibrary(Settings.TransformEffectPath + i.ToString("00"));

            for (int i = 0; i < TransformWeaponEffect.Length; i++)
                TransformWeaponEffect[i] = new MLibrary(Settings.TransformWeaponEffectPath + i.ToString("00"));

            #region Maplibs
            //wemade mir2 (allowed from 0-99)
            MapLibs[0] = new MLibrary(Settings.DataPath + "Map\\WemadeMir2\\Tiles");
            MapLibs[1] = new MLibrary(Settings.DataPath + "Map\\WemadeMir2\\Smtiles");
            MapLibs[2] = new MLibrary(Settings.DataPath + "Map\\WemadeMir2\\Objects");
            for (int i = 2; i < 24; i++)
            {
                MapLibs[i + 1] = new MLibrary(Settings.DataPath + "Map\\WemadeMir2\\Objects" + i.ToString());
            }
            //shanda mir2 (allowed from 100-199)
            MapLibs[100] = new MLibrary(Settings.DataPath + "Map\\ShandaMir2\\Tiles");
            for (int i = 1; i < 10; i++)
            {
                MapLibs[100 + i] = new MLibrary(Settings.DataPath + "Map\\ShandaMir2\\Tiles" + (i + 1));
            }
            MapLibs[110] = new MLibrary(Settings.DataPath + "Map\\ShandaMir2\\SmTiles");
            for (int i = 1; i < 10; i++)
            {
                MapLibs[110 + i] = new MLibrary(Settings.DataPath + "Map\\ShandaMir2\\SmTiles" + (i + 1));
            }
            MapLibs[120] = new MLibrary(Settings.DataPath + "Map\\ShandaMir2\\Objects");
            for (int i = 1; i < 31; i++)
            {
                MapLibs[120 + i] = new MLibrary(Settings.DataPath + "Map\\ShandaMir2\\Objects" + (i + 1));
            }
            MapLibs[190] = new MLibrary(Settings.DataPath + "Map\\ShandaMir2\\AniTiles1");
            //wemade mir3 (allowed from 200-299)
            string[] Mapstate = { "", "wood\\", "sand\\", "snow\\", "forest\\"};
            for (int i = 0; i < Mapstate.Length; i++)
            {
                MapLibs[200 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Tilesc");
                MapLibs[201 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Tiles30c");
                MapLibs[202 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Tiles5c");
                MapLibs[203 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Smtilesc");
                MapLibs[204 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Housesc");
                MapLibs[205 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Cliffsc");
                MapLibs[206 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Dungeonsc");
                MapLibs[207 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Innersc");
                MapLibs[208 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Furnituresc");
                MapLibs[209 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Wallsc");
                MapLibs[210 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "smObjectsc");
                MapLibs[211 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Animationsc");
                MapLibs[212 +(i*15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Object1c");
                MapLibs[213 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Object2c");
            }
            Mapstate = new string[] { "", "wood", "sand", "snow", "forest"};
            //shanda mir3 (allowed from 300-399)
            for (int i = 0; i < Mapstate.Length; i++)
            {
                MapLibs[300 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Tilesc" + Mapstate[i]);
                MapLibs[301 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Tiles30c" + Mapstate[i]);
                MapLibs[302 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Tiles5c" + Mapstate[i]);
                MapLibs[303 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Smtilesc" + Mapstate[i]);
                MapLibs[304 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Housesc" + Mapstate[i]);
                MapLibs[305 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Cliffsc" + Mapstate[i]);
                MapLibs[306 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Dungeonsc" + Mapstate[i]);
                MapLibs[307 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Innersc" + Mapstate[i]);
                MapLibs[308 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Furnituresc" + Mapstate[i]);
                MapLibs[309 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Wallsc" + Mapstate[i]);
                MapLibs[310 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "smObjectsc" + Mapstate[i]);
                MapLibs[311 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Animationsc" + Mapstate[i]);
                MapLibs[312 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Object1c" + Mapstate[i]);
                MapLibs[313 + (i * 15)] = new MLibrary(Settings.DataPath + "Map\\ShandaMir3\\" + "Object2c" + Mapstate[i]);
            }
            #endregion

            LoadLibraries();
            LoadGameLibraries();

            // Thread thread = new Thread(LoadGameLibraries) { IsBackground = true };
            // thread.Start();
        }

        static void LoadLibraries()
        {
            ChrSel.Initialize();
            Progress++;

            Prguse.Initialize();
            Progress++;

            Prguse2.Initialize();
            Progress++;

            Title.Initialize();
            Progress++;
        }

        private static void LoadGameLibraries()
        {
            Count = MapLibs.Length + Monsters.Length + Gates.Length + NPCs.Length + CArmours.Length +
                CHair.Length + CWeapons.Length + AArmours.Length + AHair.Length + AWeaponsL.Length + AWeaponsR.Length +
                ARArmours.Length + ARHair.Length + ARWeapons.Length + ARWeaponsS.Length +
                CHumEffect.Length + AHumEffect.Length + ARHumEffect.Length + Mounts.Length + Fishing.Length + Pets.Length +
                Transform.Length + TransformMounts.Length + TransformEffect.Length + TransformWeaponEffect.Length + 17;

            Dragon.Initialize();
            Progress++;

            BuffIcon.Initialize();
            Progress++;

            Help.Initialize();
            Progress++;

            MiniMap.Initialize();
            Progress++;

            MagIcon.Initialize();
            Progress++;
            MagIcon2.Initialize();
            Progress++;

            Magic.Initialize();
            Progress++;
            Magic2.Initialize();
            Progress++;
            Magic3.Initialize();
            Progress++;
            MagicC.Initialize();
            Progress++;

            Effect.Initialize();
            Progress++;

            GuildSkill.Initialize();
            Progress++;

            Background.Initialize();
            Progress++;

            Deco.Initialize();
            Progress++;

            Items.Initialize();
            Progress++;
            StateItems.Initialize();
            Progress++;
            FloorItems.Initialize();
            Progress++;

            for (int i = 0; i < MapLibs.Length; i++)
            {
                if (MapLibs[i] == null)
                    MapLibs[i] = new MLibrary("");
                else
                    MapLibs[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < Monsters.Length; i++)
            {
                Monsters[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < Gates.Length; i++)
            {
                Gates[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < NPCs.Length; i++)
            {
                NPCs[i].Initialize();
                Progress++;
            }


            for (int i = 0; i < CArmours.Length; i++)
            {
                CArmours[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < CHair.Length; i++)
            {
                CHair[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < CWeapons.Length; i++)
            {
                CWeapons[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < AArmours.Length; i++)
            {
                AArmours[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < AHair.Length; i++)
            {
                AHair[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < AWeaponsL.Length; i++)
            {
                AWeaponsL[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < AWeaponsR.Length; i++)
            {
                AWeaponsR[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < ARArmours.Length; i++)
            {
                ARArmours[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < ARHair.Length; i++)
            {
                ARHair[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < ARWeapons.Length; i++)
            {
                ARWeapons[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < ARWeaponsS.Length; i++)
            {
                ARWeaponsS[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < CHumEffect.Length; i++)
            {
                CHumEffect[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < AHumEffect.Length; i++)
            {
                AHumEffect[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < ARHumEffect.Length; i++)
            {
                ARHumEffect[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < Mounts.Length; i++)
            {
                Mounts[i].Initialize();
                Progress++;
            }


            for (int i = 0; i < Fishing.Length; i++)
            {
                Fishing[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < Pets.Length; i++)
            {
                Pets[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < Transform.Length; i++)
            {
                Transform[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < TransformEffect.Length; i++)
            {
                TransformEffect[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < TransformWeaponEffect.Length; i++)
            {
                TransformWeaponEffect[i].Initialize();
                Progress++;
            }

            for (int i = 0; i < TransformMounts.Length; i++)
            {
                TransformMounts[i].Initialize();
                Progress++;
            }
            
            Loaded = true;
        }

    }

    public sealed class MLibrary
    {
        private const string Extention = ".Lib";
        public const int LibVersion = 2;

        public readonly string _fileName;

        public List<MImage> _images;
        public  List<int> _indexList;
        public int _count;
        public bool _initialized = false;

        private BinaryReader _reader;
        private FileStream _stream;

        public MLibrary(string filename)
        {
            _fileName = Path.ChangeExtension(filename, Extention);
        }

        public void Initialize()
        {
            int CurrentVersion = 0;
            _initialized = true;

            if (!File.Exists(_fileName))
                return;
            try
            {
                _stream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                _reader = new BinaryReader(_stream);
                CurrentVersion = _reader.ReadInt32();
                if (CurrentVersion != LibVersion)
                {
                    //cant use a directx based error popup cause it could be the lib file containing the interface is invalid :(
                    System.Windows.Forms.MessageBox.Show("Wrong version, expecting lib version: " + LibVersion.ToString() + " found version: " + CurrentVersion.ToString() + ".", _fileName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                    System.Windows.Forms.Application.Exit();
                    return;
                }
                _count = _reader.ReadInt32();
                _images = new List<MImage>(_count);
                _indexList = new List<int>(_count);

                for (int i = 0; i < _count; i++)
                    _indexList.Add( _reader.ReadInt32() );

                for (int i = 0; i < _count; i++)
                    _images.Add(null);


                // 装载图片
                /*
                for (int i = 0; i < _count; i++)
                {
                    CheckImage(i);
                }
                */
            }
            catch (Exception)
            {
                _initialized = false;
                throw;
            }
        }

        public void Close()
        {
            if (_stream != null)
                _stream.Dispose();
            if (_reader != null)
                _reader.Dispose();
        }

        public void Save()
        {
            Close();

            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            _count = _images.Count;
            _indexList.Clear();

            int offSet = 8 + _count * 4;
            for (int i = 0; i < _count; i++)
            {
                _indexList.Add((int)stream.Length + offSet);
                _images[i].Save(writer);
            }

            writer.Flush();
            byte[] fBytes = stream.ToArray();
            //  writer.Dispose();

            _stream = File.Create( _fileName );
            writer = new BinaryWriter(_stream);
            writer.Write(LibVersion);
            writer.Write(_count );
            for (int i = 0; i < _count; i++)
                writer.Write( _indexList[i]);

            writer.Write(fBytes);
            writer.Flush();
            writer.Close();
            writer.Dispose();
            Close();
        }


        public MImage LoadMImage( int index )
        {
            if (!_initialized)
                Initialize();

            if (_images == null || index < 0 || index >= _images.Count)
                return null;

            if (_images[index] == null)
            {
                _stream.Position = _indexList[index];
                _images[index] = new MImage(_reader);
            }
            MImage mi = _images[index];
            return mi;
        }

        public void createImage( int index )
        {
            MImage mi = _images[index];
            if (mi != null && !mi.ImageValid)
            {
                if ((mi.Width == 0) || (mi.Height == 0))
                    return;
                _stream.Seek(_indexList[index] + 17, SeekOrigin.Begin);
                mi.CreateImage(_reader);
            }
        }

        public bool CheckImage(int index)
        {
            if (!_initialized)
                Initialize();

            if (_images == null || index < 0 || index >= _images.Count)
                return false;


            if (_images[index] == null)
            {
                _stream.Position = _indexList[index];
                _images[index] = new MImage(_reader);
            }
            MImage mi = _images[index];
            if (!mi.ImageValid)
            {
                if ( (mi.Width == 0) || (mi.Height == 0) )
                    return false;
                _stream.Seek(_indexList[index] + 17, SeekOrigin.Begin);
                mi.CreateImage( _reader );
                
            }

            return true;
        }



        public Point GetOffSet(int index)
        {
            if (!_initialized) Initialize();

            if (_images == null || index < 0 || index >= _images.Count)
                return Point.Empty;

            if (_images[index] == null)
            {
                _stream.Seek(_indexList[index], SeekOrigin.Begin);
                _images[index] = new MImage(_reader);
            }

            return new Point(_images[index].X, _images[index].Y);
        }
        public Size GetSize(int index)
        {
            if (!_initialized) Initialize();
            if (_images == null || index < 0 || index >= _images.Count)
                return Size.Empty;

            if (_images[index] == null)
            {
                _stream.Seek(_indexList[index], SeekOrigin.Begin);
                _images[index] = new MImage(_reader);
            }

            return new Size(_images[index].Width, _images[index].Height);
        }

        public MImage GetMImage(int index)
        {
            if (index < 0 || index >= _images.Count)
                return null;
            CheckImage(index);
            return _images[index];
        }

        public Bitmap GetImage(int index )
        {
            if (index < 0 || index >= _images.Count)
                return new Bitmap(1, 1);
            CheckImage(index);
            return _images[index].Image;
        }
        public Bitmap GetPreview(int index)
        {
            if (index < 0 || index >= _images.Count)
                return new Bitmap(1, 1);
            MImage image = _images[index];
            if (image == null || image.Image == null)
                return new Bitmap(1, 1);
            if (image.Preview == null)
                image.CreatePreview();
            Bitmap preview = image.Preview;
            return preview;
        }

        public void AddImage(Bitmap image, short x, short y)
        {
            MImage mImage = new MImage(image) { X = x, Y = y };

            _count++;
            _images.Add(mImage);
        }

        public void ReplaceImage(int Index, Bitmap image, short x, short y)
        {
            MImage mImage = new MImage(image) { X = x, Y = y };
            _images[Index] = mImage;
        }

        public void InsertImage(int index, Bitmap image, short x, short y)
        {
            MImage mImage = new MImage(image) { X = x, Y = y };

            _count++;
            _images.Insert(index, mImage);
        }

        public void RemoveImage(int index)
        {
            if (_images == null || _count <= 1)
            {
                _count = 0;
                _images = new List<MImage>();
                return;
            }
            _count--;
            _images.RemoveAt(index);
        }

        public static bool CompareBytes(byte[] a, byte[] b)
        {
            if (a == b) return true;

            if (a == null || b == null || a.Length != b.Length) return false;

            for (int i = 0; i < a.Length; i++) if (a[i] != b[i]) return false;

            return true;
        }

        public void RemoveBlanks(bool safe = false)
        {
            for (int i = _count - 1; i >= 0; i--)
            {
                if ( _images[i].Image == null || (_images[i].Image.Width < 2 &&  _images[i].Image.Height < 2) )
                {
                    if (!safe)
                        RemoveImage(i);
                    else if (_images[i].X == 0 && _images[i].Y == 0)
                        RemoveImage(i);
                }
            }
        }


        // Draw系列函数
        public void Draw(int index, int x, int y)
        {
            if (x >= Settings.ScreenWidth || y >= Settings.ScreenHeight)
                return;

            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (x + mi.Width < 0 || y + mi.Height < 0)
                return;


            // DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, new PointF(x, y), Color.White);
            // mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }
        public void Draw(int index, Point point, Color colour, bool offSet = false)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X, mi.Y);

            if (point.X >= Settings.ScreenWidth || point.Y >= Settings.ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;



            // DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, colour);
            // mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }

        public void Draw(int index, Point point, Color colour, bool offSet, float opacity)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X, mi.Y);

            if (point.X >= Settings.ScreenWidth || point.Y >= Settings.ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            // float oldOpacity = DXManager.Opacity;
            // DXManager.SetOpacity(opacity);
            // DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, colour);
            // DXManager.SetOpacity(oldOpacity);
            // mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }

        public void DrawBlend(int index, Point point, Color colour, bool offSet = false, float rate = 1)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X, mi.Y);

            if (point.X >= Settings.ScreenWidth || point.Y >= Settings.ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            //bool oldBlend = DXManager.Blending;
            //DXManager.SetBlend(true, rate);

            //DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, colour);

            //DXManager.SetBlend(oldBlend);
            //mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }
        public void Draw(int index, Rectangle section, Point point, Color colour, bool offSet)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X, mi.Y);


            if (point.X >= Settings.ScreenWidth || point.Y >= Settings.ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            if (section.Right > mi.Width)
                section.Width -= section.Right - mi.Width;

            if (section.Bottom > mi.Height)
                section.Height -= section.Bottom - mi.Height;

            //DXManager.Sprite.Draw2D(mi.Image, section, section.Size, point, colour);
            //mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }
        public void Draw(int index, Rectangle section, Point point, Color colour, float opacity)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];


            if (point.X >= Settings.ScreenWidth || point.Y >= Settings.ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            if (section.Right > mi.Width)
                section.Width -= section.Right - mi.Width;

            if (section.Bottom > mi.Height)
                section.Height -= section.Bottom - mi.Height;

            //float oldOpacity = DXManager.Opacity;
            //DXManager.SetOpacity(opacity);

            //DXManager.Sprite.Draw2D(mi.Image, section, section.Size, point, colour);

            //DXManager.SetOpacity(oldOpacity);
            //mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }
        public void Draw(int index, Point point, Size size, Color colour)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (point.X >= Settings.ScreenWidth || point.Y >= Settings.ScreenHeight || point.X + size.Width < 0 || point.Y + size.Height < 0)
                return;

            //DXManager.Sprite.Draw2D(mi.Image, new Rectangle(Point.Empty, new Size(mi.Width, mi.Height)), size, point, colour);
            //mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }

        public void DrawTinted(int index, Point point, Color colour, Color Tint, bool offSet = false)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X, mi.Y);

            if (point.X >= Settings.ScreenWidth || point.Y >= Settings.ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;
            //DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, colour);

            if (mi.HasMask)
            {
                //DXManager.Sprite.Draw2D(mi.MaskImage, Point.Empty, 0, point, Tint);
            }

            // mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }

        public void DrawUp(int index, int x, int y)
        {
            if (x >= Settings.ScreenWidth)
                return;

            if (!CheckImage(index))
                return;

            MImage mi = _images[index];
            y -= mi.Height;
            if (y >= Settings.ScreenHeight)
                return;
            if (x + mi.Width < 0 || y + mi.Height < 0)
                return;


            //DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, new PointF(x, y), Color.White);
            //mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }
        public void DrawUpBlend(int index, Point point)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            point.Y -= mi.Height;


            if (point.X >= Settings.ScreenWidth || point.Y >= Settings.ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            //bool oldBlend = DXManager.Blending;
            //DXManager.SetBlend(true, 1);

            //DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, Color.White);

            //DXManager.SetBlend(oldBlend);
            //mi.CleanTime = CMain.Time + Settings.CleanDelay;
        }

    }

    public sealed class MImage
    {
        public short Width, Height, X, Y, ShadowX, ShadowY;
        public byte Shadow;
        public int Length;

        // 看看有没有装载过
        public bool ImageValid;
        public Bitmap Image, Preview;
        //layer 2:
        public short MaskWidth, MaskHeight, MaskX, MaskY;
        public int MaskLength;

        public Bitmap MaskImage;
        public Boolean HasMask;

        public long CleanTime;
        public Size TrueSize;


        public MImage(BinaryReader reader)
        {
            //read layer 1
            Width = reader.ReadInt16();
            Height = reader.ReadInt16();
            X = reader.ReadInt16();
            Y = reader.ReadInt16();
            ShadowX = reader.ReadInt16();
            ShadowY = reader.ReadInt16();
            Shadow = reader.ReadByte();
            Length = reader.ReadInt32();

            // layer1为17的地方
            //check if there's a second layer and read it
            HasMask = ((Shadow >> 7) == 1) ? true : false;
            if (HasMask)
            {
                reader.ReadBytes(Length);
                MaskWidth = reader.ReadInt16();
                MaskHeight = reader.ReadInt16();
                MaskX = reader.ReadInt16();
                MaskY = reader.ReadInt16();
                MaskLength = reader.ReadInt32();
            }
        }

        public MImage(Bitmap image)
        {
            if (image == null)
            {
                return;
            }

            Width = (short)image.Width;
            Height = (short)image.Height;

            Image = image;
        }

        public MImage(Bitmap image, Bitmap Maskimage)
        {
            if (image == null)
            {
                return;
            }

            Width = (short)image.Width;
            Height = (short)image.Height;
            Image = image;// FixImageSize(image);
            if (Maskimage == null)
            {
                return;
            }
            HasMask = true;
            MaskWidth = (short)Maskimage.Width;
            MaskHeight = (short)Maskimage.Height;
            MaskImage = Maskimage;
        }


        // 创建图形
        public void CreateImage(BinaryReader reader )
        {
            int w = Width;
            int h = Height;
            
            if (w == 0 || h == 0)
                return;
            if ((w < 2) || (h < 2)) return;
            Image = new Bitmap(w, h);
            byte[] dest = Decompress(reader.ReadBytes(Length));
            BitmapData data = Image.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite,
                                                 PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, data.Scan0, dest.Length);
            Image.UnlockBits(data);

            dest = null;
            if( HasMask )
            {
                // -- 前面12个字节
                reader.ReadBytes(12);
                w = MaskWidth;
                h = MaskHeight;
                if( w == 0 || h == 0 )
                {
                    return;
                }

                try
                {
                    MaskImage = new Bitmap(w, h);
                    data = MaskImage.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite,
                                                     PixelFormat.Format32bppArgb);
                    dest = Decompress(reader.ReadBytes(MaskLength));
                    Marshal.Copy(dest, 0, data.Scan0, dest.Length);
                    MaskImage.UnlockBits(data);
                }
                catch (Exception ex)
                {
                    if (Settings.LogErrors) MainForm.SaveError(ex.ToString());
                }
            }
            ImageValid = true;
            dest = null;
        }

        public void CreatePreview()
        {
            if (Image == null)
            {
                Preview = new Bitmap(1, 1);
                return;
            }

            Preview = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(Preview))
            {
                g.InterpolationMode = InterpolationMode.Low;//HighQualityBicubic
                g.Clear(Color.Transparent);
                int w = Math.Min((int)Width, 64);
                int h = Math.Min((int)Height, 64);
                g.DrawImage(Image, new Rectangle((64 - w) / 2, (64 - h) / 2, w, h), new Rectangle(0, 0, Width, Height), GraphicsUnit.Pixel);
                g.Save();
            }
        }

        private Bitmap FixImageSize(Bitmap input)
        {
            int w = input.Width + (4 - input.Width % 4) % 4;
            int h = input.Height + (4 - input.Height % 4) % 4;

            if (input.Width != w || input.Height != h)
            {
                Bitmap temp = new Bitmap(w, h);
                using (Graphics g = Graphics.FromImage(temp))
                {
                    g.Clear(Color.Transparent);
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.DrawImage(input, 0, 0);
                    g.Save();
                }
                input.Dispose();
                input = temp;
            }

            return input;
        }

        private byte[] ConvertBitmapToArray(Bitmap input)
        {
            BitmapData data = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.ReadOnly,
                                             PixelFormat.Format32bppArgb);

            byte[] pixels = new byte[input.Width * input.Height * 4];

            Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            input.UnlockBits(data);

            for (int i = 0; i < pixels.Length; i += 4)
            {
                if (pixels[i] == 0 && pixels[i + 1] == 0 && pixels[i + 2] == 0)
                    pixels[i + 3] = 0; //Make Transparent
            }

            byte[] compressedBytes;
            compressedBytes = Compress(pixels);

            return compressedBytes;
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Width);
            writer.Write(Height);
            writer.Write(X);
            writer.Write(Y);
            writer.Write(ShadowX);
            writer.Write(ShadowY);
            writer.Write(HasMask ? (byte)(Shadow | 0x80) : (byte)Shadow);

            byte[] FBytes = ConvertBitmapToArray(this.Image);
            writer.Write(FBytes.Length);
            writer.Write(FBytes);
            if (HasMask)
            {
                byte[] MaskFBytes = ConvertBitmapToArray(this.MaskImage);
                writer.Write(MaskWidth);
                writer.Write(MaskHeight);
                writer.Write(MaskX);
                writer.Write(MaskY);
                writer.Write(MaskFBytes.Length);
                writer.Write(MaskFBytes);
            }
        }

        public static byte[] Compress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory,
                CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }

        static byte[] Decompress(byte[] gzip)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }


    }


}