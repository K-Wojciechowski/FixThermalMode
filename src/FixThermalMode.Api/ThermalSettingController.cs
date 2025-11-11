/*
 * FixThermalMode
 * Copyright © 2024-2025 Krzysztof Wojciechowski
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System.Net;
using DellFanManagement.DellSmbiosSmiLib;
using FixThermalMode.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixThermalMode.Api;

[ApiController]
[Authorize(Roles = ApiKeyAuthenticationHandler.RoleName, AuthenticationSchemes = ApiKeyAuthenticationHandler.SchemeName)]
[Route("")]
public class ThermalSettingController : ControllerBase {
  private readonly ILogger<ThermalSettingController> _logger;

  public ThermalSettingController(ILogger<ThermalSettingController> logger) {
    _logger = logger;
  }

  [HttpGet(Name = "GetThermalSetting")]
  [Authorize]
  public ActionResult<string> Get() {
    var thermalSetting = DellSmbiosSmi.GetThermalSetting();
    var message = thermalSetting switch {
      ThermalSetting.Error => Modes.Error,
      ThermalSetting.Optimized => Modes.Optimized,
      ThermalSetting.Cool => Modes.Cool,
      ThermalSetting.Quiet => Modes.Quiet,
      ThermalSetting.Performance => Modes.Performance,
      _ => Modes.UnknownMode
    };

    return message is Modes.Error or Modes.UnknownMode ? InternalServerError(message) : Ok(message);
  }

  [HttpPost("{newMode:alpha}")]
  public ActionResult<string> Set([FromRoute] string newMode) {
    var thermalSetting = newMode.ToLowerInvariant() switch {
      Modes.Optimized => ThermalSetting.Optimized,
      Modes.Cool => ThermalSetting.Cool,
      Modes.Quiet => ThermalSetting.Quiet,
      Modes.Performance => ThermalSetting.Performance,
      _ => ThermalSetting.Error
    };


    if (thermalSetting == ThermalSetting.Error) {
      _logger.LogError("Unknown thermal mode {StringMode}", newMode);
      return BadRequest("unknown thermal mode");
    }

    _logger.LogInformation("Trying to set thermal mode {Mode} (requested as {StringMode})", thermalSetting, newMode);

    var success = DellSmbiosSmi.SetThermalSetting(thermalSetting);

    if (success) {
      _logger.LogInformation("Successfully set thermal mode {Mode} (requested as {StringMode})", thermalSetting, newMode);
      return Get();
    } else {
      _logger.LogError("Failed to set thermal mode {Mode} (requested as {StringMode})", thermalSetting, newMode);
      return InternalServerError("failed to set mode");
    }
  }

  private ObjectResult InternalServerError(string message)
    => StatusCode((int)HttpStatusCode.InternalServerError, message);
}
