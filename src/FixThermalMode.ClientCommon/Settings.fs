(*
 * FixThermalMode
 * Copyright © 2024 Krzysztof Wojciechowski
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
 *)

namespace FixThermalMode.ClientCommon

open System
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Hosting

type Settings = { ApiKey: string; ApiUrl: string }

module SettingsProvider =
    let getSettings () =
        let host = Host.CreateDefaultBuilder()
                       .UseContentRoot(AppContext.BaseDirectory)
                       .Build()
        let configuration = host.Services.GetService(typedefof<IConfiguration>) :?> IConfiguration
        let apiKey = configuration.GetValue<string>("ApiKey")
        let apiUrl = configuration.GetValue<string>("ApiUrl")
        { ApiKey = apiKey; ApiUrl = apiUrl }
