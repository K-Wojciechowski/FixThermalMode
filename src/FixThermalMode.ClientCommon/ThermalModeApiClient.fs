(*
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
 *)

namespace FixThermalMode.ClientCommon

open FsHttp

module ThermalModeApiClient =
    let private settings = lazy SettingsProvider.getSettings ()

    let private getMessage response =
        async {
            let! message = response |> Response.toTextAsync

            return
                if message.Trim().Length > 0 then
                    message
                else
                    $"{response.statusCode}"
        }

    let getFsAsync () =
        async {
            let! response =
                http {
                    GET settings.Value.ApiUrl
                    AuthorizationBearer settings.Value.ApiKey
                }
                |> Request.sendAsync

            let! message = response |> getMessage
            let statusCode = int response.statusCode

            return
                { Success = statusCode >= 200 && statusCode < 300
                  Message = message }
        }

    let setFsAsync newMode =
        let url = settings.Value.ApiUrl + newMode

        async {
            let! response =
                http {
                    POST url
                    AuthorizationBearer settings.Value.ApiKey
                }
                |> Request.sendAsync

            let! message = response |> getMessage
            let statusCode = int response.statusCode

            return
                { Success = statusCode >= 200 && statusCode < 300
                  Message = message }
        }

    let getAsync () = Async.StartAsTask(getFsAsync ())

    let setAsync newMode = Async.StartAsTask(setFsAsync newMode)

    let get () =
        getFsAsync () |> Async.RunSynchronously<ApiResponse>

    let set newMode =
        setFsAsync newMode |> Async.RunSynchronously<ApiResponse>

