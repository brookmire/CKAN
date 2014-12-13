using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CKAN;
using Version = CKAN.Version;

namespace Tests
{
    static public class TestData
    {
        public static string DataDir()
        {
            // TODO: Have this actually walk our directory structure and find
            // t/data. This means we can relocate our test executable and
            // things will still work.
            string current = Directory.GetCurrentDirectory();

            return Path.Combine(current, "../../../../t/data");
        }

        public static string DataDir(string file)
        {
            return Path.Combine(DataDir(), file);
        }

        /// <summary>
        /// Returns the full path to DogeCoinFlag-1.01.zip
        /// </summary>
        public static string DogeCoinFlagZip()
        {
            string such_zip_very_currency_wow = Path.Combine(DataDir(), "DogeCoinFlag-1.01.zip");

            return such_zip_very_currency_wow;
        }

        /// <summary>
        /// Returns DogeCoinFlag.zip, with extra files inside.
        /// Great for testing filters.
        /// </summary>
        public static string DogeCoinFlagZipWithExtras()
        {
            return Path.Combine(DataDir(), "DogeCoinFlag-extra-files.zip");
        }

        /// <summary>
        /// Returns the full path to DogeCoinFlag-1.01-corrupt.zip
        /// </summary>
        public static string DogeCoinFlagZipCorrupt()
        {
            string such_zip_very_corrupt_wow = Path.Combine(DataDir(), "DogeCoinFlag-1.01-corrupt.zip");

            return such_zip_very_corrupt_wow;
        }


        ///<summary>
        /// DogeCoinFlag 1.01 info. This contains a bug where the
        /// install stanza doesn't actually refer to any files.
        ///</summary>
        public static string DogeCoinFlag_101_bugged()
        {
            return @"
                {
                    ""spec_version"": 1,
                    ""identifier"": ""DogeCoinFlag"",
                    ""install"": [
                        {
                        ""file"": ""GameData/DogeCoinFlag"",
                        ""install_to"": ""GameData""
                        }
                    ],
                    ""resources"": {
                        ""kerbalstuff"": {
                        ""url"": ""https://kerbalstuff.com/mod/269/Dogecoin%20Flag""
                        },
                        ""homepage"": ""https://www.reddit.com/r/dogecoin/comments/1tdlgg/i_made_a_more_accurate_dogecoin_and_a_ksp_flag/""
                    },
                    ""name"": ""Dogecoin Flag"",
                    ""license"": ""CC-BY"",
                    ""abstract"": ""Such flag. Very currency. To the mun! Wow!"",
                    ""author"": ""pjf"",
                    ""version"": ""1.01"",
                    ""download"": ""https://kerbalstuff.com/mod/269/Dogecoin%20Flag/download/1.01"",
                    ""comment"": ""Generated by ks2ckan"",
                    ""download_size"": 53647,
                    ""ksp_version"": ""0.25""
                }
            ";
        }

        public static CkanModule DogeCoinFlag_101_bugged_module()
        {
            return CkanModule.FromJson(DogeCoinFlag_101_bugged());
        }

        ///<summary>
        /// DogeCoinFlag 1.01 info. This doesn't contain any bugs.
        ///</summary>
        public static string DogeCoinFlag_101()
        {
            return @"
                {
                    ""spec_version"": 1,
                    ""identifier"": ""DogeCoinFlag"",
                    ""install"": [
                        {
                        ""file"": ""DogeCoinFlag-1.01/GameData/DogeCoinFlag"",
                        ""install_to"": ""GameData"",
                        ""filter"" : [ ""Thumbs.db"", ""README.md"" ],
                        ""filter_regexp"" : ""\\.bak$""
                        }
                    ],
                    ""resources"": {
                        ""kerbalstuff"": {
                        ""url"": ""https://kerbalstuff.com/mod/269/Dogecoin%20Flag""
                        },
                        ""homepage"": ""https://www.reddit.com/r/dogecoin/comments/1tdlgg/i_made_a_more_accurate_dogecoin_and_a_ksp_flag/""
                    },
                    ""name"": ""Dogecoin Flag"",
                    ""license"": ""CC-BY"",
                    ""abstract"": ""Such flag. Very currency. To the mun! Wow!"",
                    ""author"": ""pjf"",
                    ""version"": ""1.01"",
                    ""download"": ""https://kerbalstuff.com/mod/269/Dogecoin%20Flag/download/1.01"",
                    ""comment"": ""Generated by ks2ckan"",
                    ""download_size"": 53647,
                    ""ksp_version"": ""0.25""
                }
            ";
        }

        public static CkanModule DogeCoinFlag_101_module()
        {
            return CkanModule.FromJson(DogeCoinFlag_101());
        }

        // Identical to DogeCoinFlag_101, but with a spec version over 9000!
        public static string FutureMetaData()
        {
            return @"
                {
                    ""spec_version"": ""v9000.0.1"",
                    ""identifier"": ""DogeCoinFlag"",
                    ""install"": [
                        {
                        ""file"": ""DogeCoinFlag-1.01/GameData/DogeCoinFlag"",
                        ""install_to"": ""GameData"",
                        ""filter"" : [ ""Thumbs.db"", ""README.md"" ],
                        ""filter_regexp"" : ""\\.bak$""
                        }
                    ],
                    ""resources"": {
                        ""kerbalstuff"": {
                        ""url"": ""https://kerbalstuff.com/mod/269/Dogecoin%20Flag""
                        },
                        ""homepage"": ""https://www.reddit.com/r/dogecoin/comments/1tdlgg/i_made_a_more_accurate_dogecoin_and_a_ksp_flag/""
                    },
                    ""name"": ""Dogecoin Flag"",
                    ""license"": ""CC-BY"",
                    ""abstract"": ""Such flag. Very currency. To the mun! Wow!"",
                    ""author"": ""pjf"",
                    ""version"": ""1.01"",
                    ""download"": ""https://kerbalstuff.com/mod/269/Dogecoin%20Flag/download/1.01"",
                    ""comment"": ""Generated by ks2ckan"",
                    ""download_size"": 53647,
                    ""ksp_version"": ""0.25""
                }
            ";
        }

        public static Uri TestKAN()
        {
            return new Uri("../../../Tests/DATA/CKAN-meta-testkan.zip", UriKind.Relative);
        }

        public static string good_ksp_dir()
        {
            return Path.Combine(DataDir(), "KSP/KSP-0.25");
        }

        public static List<string> bad_ksp_dirs()
        {
            var dirs = new List<string>();
            dirs.Add(Path.Combine(DataDir(), "KSP/bad-ksp"));
            dirs.Add(Path.Combine(DataDir(), "KSP/missing-gamedata"));

            return dirs;
        }

        public static string kOS_014()
        {
            return @"
                {
                    ""spec_version"": 1,
                    ""name""     : ""kOS - Kerbal OS"",
                    ""identifier"" : ""kOS"",
                    ""abstract"" : ""A programming and automation environment for KSP craft."",
                    ""download"" : ""https://github.com/KSP-KOS/KOS/releases/download/v0.14/kOS.v14.zip"",
                    ""license""  : ""GPL-3.0"",
                    ""version""  : ""0.14"",
                    ""release_status"" : ""stable"",
                    ""ksp_version"" : ""0.24.2"",
                    ""resources"" : {
                        ""homepage"" : ""http://forum.kerbalspaceprogram.com/threads/68089-0-23-kOS-Scriptable-Autopilot-System-v0-11-2-13"",
                        ""manual""   : ""http://ksp-kos.github.io/KOS_DOC/"",
                        ""bugtracker"": ""https://github.com/KSP-KOS/KOS/issues"",
                        ""github""   : {
                            ""url""      : ""https://github.com/KSP-KOS/KOS"",
                            ""releases"" : true
                        }
                    },
                    ""install"" : [
                        {
                            ""file""       : ""GameData/kOS"",
                            ""install_to"" : ""GameData""
                        }
                    ]
                }"
            ;
        }

        public static CkanModule kOS_014_module()
        {
            return CkanModule.FromJson(kOS_014());
        }

        public static string KS_CustomAsteroids_string()
        {
            return File.ReadAllText(Path.Combine(DataDir(), "KS/CustomAsteroids.json"));
        }

        public static CkanModule FireSpitterModule()
        {
            return CkanModule.FromFile(Path.Combine(DataDir(), "Firespitter-6.3.5.ckan"));
        }

        public static string KspAvcJson()
        {
            return File.ReadAllText(Path.Combine(DataDir(), "ksp-avc.version"));
        }

        public static CkanModule ModuleManagerModule()
        {
            return CkanModule.FromFile(DataDir("ModuleManager-2.5.1.ckan"));
        }

        public static string ModuleManagerZip()
        {
            return DataDir("ModuleManager-2.5.1.zip");
        }

        /// <summary>
        /// A path to our test registry.json file. Please copy before using.
        /// </summary>
        public static string TestRegistry()
        {
            return DataDir("registry.json");
        }

        // Where's my mkdtemp? Instead we'll make a random file, delete it, and
        // fill its place with a directory.
        // Taken from https://stackoverflow.com/a/20445952
        public static string NewTempDir()
        {
            string temp_folder = Path.GetTempFileName();
            File.Delete(temp_folder);
            Directory.CreateDirectory(temp_folder);

            return temp_folder;
        }

        // Ugh, this is awful.
        public static void CopyDirectory(string src, string dst)
        {
            // Create directory structure
            foreach (string path in Directory.GetDirectories(src, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(path.Replace(src, dst));
            }

            // Copy files.
            foreach (string file in Directory.GetFiles(src, "*", SearchOption.AllDirectories))
            {
                File.Copy(file, file.Replace(src, dst));
            }
        }
    }

    public class RandomModuleGenerator
    {
        public Random Generator { get; set; }

        public RandomModuleGenerator(Random generator)
        {
            Generator = generator;
        }

        public CkanModule GeneratorRandomModule(
            KSPVersion kspVersion = null,
            List<RelationshipDescriptor> conflicts = null,
            List<RelationshipDescriptor> depends = null,
            List<RelationshipDescriptor> sugests = null,
            List<String> provides = null,
            string identifier = null)
        {
            var mod = new CkanModule
            {
                name = Generator.Next().ToString(CultureInfo.InvariantCulture),
                @abstract = Generator.Next().ToString(CultureInfo.InvariantCulture),
                identifier = identifier??Generator.Next().ToString(CultureInfo.InvariantCulture),
                spec_version = new Version(1.ToString(CultureInfo.InvariantCulture)),
                ksp_version = kspVersion ?? new KSPVersion("0." + Generator.Next()),
                version = new Version(Generator.Next().ToString(CultureInfo.InvariantCulture))
            };
            mod.ksp_version_max = mod.ksp_version_min = new KSPVersion(null);
            mod.conflicts = conflicts;
            mod.depends = depends;
            mod.suggests = sugests;
            mod.provides = provides;
            return mod;
        }
    }
}

