using Microsoft.Win32;

namespace CsgoAntiCheatDudu.Utils
{
    public static class FileHandler
    {
       public static string ReadFile(string path, string fileName)
            {
                // The files used in this example are created in the topic
                // How to: Write to a Text File. You can change the path and
                // file name to substitute text files of your own.

                // Example #1
                // Read the file as one string.
                string text = System.IO.File.ReadAllText($@"{path}{fileName}");

                return text;
            }
       
       public static void WriteConfigurationFileCsGo(string path, string fileName)
       {
           var contentFileWebhook =
               "\"GSI v1.0.0\"\n{\n    \"uri\" \"http://localhost:5000/api/event\"\n    \"timeout\" \"5.0\"\n    \"buffer\"  \"1.1\"\n    \"throttle\" \"0.1\"\n    \"heartbeat\" \"1.0\"\n    \"auth\"\n{\n    \"token\" \"S8RL9Z6Y22TYQK45JB4V8PHRJJMD9DS9\"\n}\n    \"data\"\n        {\n            \"provider\"                        \"0\"\n            \"phase_countdowns\"                \"0\"\n            \"map_round_wins\"                  \"0\"\n            \"round\"                           \"0\"\n            \"bomb\"                            \"0\"\n            \"map\"                             \"0\"\n            \"player_match_stats\"              \"0\"\n            \"player_position\"                 \"0\"\n            \"player_weapons\"                  \"0\"\n            \"player_state\"                    \"0\"\n            \"player_id\"                       \"0\"\n\n            \"allgrenades\"                     \"0\"\n            \"allplayers_id\"                   \"1\"\n            \"allplayers_match_stats\"          \"0\"\n            \"allplayers_position\"             \"0\"\n            \"allplayers_state\"                \"0\"\n            \"allplayers_weapons\"              \"0\"\n        }\n}\n";
           File.WriteAllText($@"{path}\\{fileName}", contentFileWebhook);
       }
       
       public static bool FindCsGoPaste()
       {
           RegistryKey registryKey = null;

           if (Environment.Is64BitOperatingSystem)
               registryKey=   Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Valve\\Steam");
           else
               registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Valve\\Steam");
           
           var steamInstallationpath = registryKey.GetValue("InstallPath").ToString();
           var folderLibrarySteamContent = FileHandler.ReadFile($@"{steamInstallationpath}\steamapps\", "libraryfolders.vdf");
           var contentTreated = System.Text.RegularExpressions.Regex.Replace(folderLibrarySteamContent, @"\s+", ";").Replace("\"", "");
           
           var contentArray = contentTreated.Split(";");
           var listPaths = new List<string>();
           var aux = 0;
           for (int i = 0; i < contentArray.Length; i++)
           {
               if(contentArray[i]== "path")
                   listPaths.Add(contentArray[aux + 1]);
               aux++;
           }

           var isWritten = false;
           foreach (var path in listPaths)
           {
               if (Directory.Exists($@"{path}\steamapps\\common\\Counter-Strike Global Offensive\\csgo\\cfg"))
               {
                   isWritten = true;

                   WriteConfigurationFileCsGo($@"{path}\steamapps\\common\\Counter-Strike Global Offensive\\csgo\\cfg", "gamestate_integration_GSI.cfg");
                   
                   if(!File.Exists($@"{path}\steamapps\\common\\Counter-Strike Global Offensive\\csgo\\cfg\\gamestate_integration_GSI.cfg"))
                   {
                       return false;
                   }
               }
           }

           return isWritten;




       }
        
    }
}
