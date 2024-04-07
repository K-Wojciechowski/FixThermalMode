using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WixToolset.Dtf.WindowsInstaller;

namespace FixThermalMode.Setup.GenerateAppSettingsAction {
  public class CustomActions {
    private static string _logPrefix = "GenerateAppSettings: ";

    [CustomAction]
    public static ActionResult GenerateAppSettingsAction(Session session) {
      session.Log(_logPrefix + "Begin");
      var installDir = session.CustomActionData["INSTALLFOLDER"];
      var apiKey = $"ftm-{Guid.NewGuid()}";
      try {
        GenerateAppSettings(session, apiKey, installDir, "client");
        GenerateAppSettings(session, apiKey, installDir, "api");
      } catch (Exception exc) {
        session.Log(_logPrefix + exc.Message);
        session.Log(_logPrefix + "Failure");
        return ActionResult.Failure;
      }
      session.Log(_logPrefix + "Success");

      return ActionResult.Success;
    }

    private static void GenerateAppSettings(Session session, string apiKey, string installDir, string subDir) {
      var targetPath = Path.Combine(installDir, subDir, "appsettings.json");

      if (File.Exists(targetPath)) {
        session.Log($"{_logPrefix}{targetPath} already exists");
        return;
      }

      session.Log(_logPrefix + "installdir: " + string.Join(",", Directory.GetFiles(installDir)));
      session.Log(_logPrefix + "targetdir: " + string.Join(",", Directory.GetFiles(Path.Combine(installDir, subDir))));
      var sourcePath = Path.Combine(installDir, subDir, "appsettings-template.json");
      if (!File.Exists(sourcePath)) {
        session.Log($"{_logPrefix}{sourcePath} does not exist");
        throw new Exception($"{sourcePath} does not exist");
      }

      var contents = File.ReadAllText(sourcePath);
      File.WriteAllText(targetPath, contents.Replace("__ftmapikey", apiKey));
      session.Log($"{_logPrefix}{targetPath} generation successful.");
    }
  }
}
