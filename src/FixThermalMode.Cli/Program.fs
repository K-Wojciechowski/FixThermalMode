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

open FixThermalMode.ClientCommon
open System

let printError (message: string) =
    Console.ForegroundColor <- ConsoleColor.Red
    Console.WriteLine(message)
    Console.ResetColor()

let handleApiResponse (apiResponse: ApiResponse) =
    match apiResponse with
    | { Success = false; Message = message } ->
        printError message
        1
    | { Message = message } ->
        Console.WriteLine(message)
        0

let getCurrentMode () = ThermalModeApiClient.get () |> handleApiResponse

let setMode newMode =
    ThermalModeApiClient.set newMode |> handleApiResponse

let tooManyArguments () =
    printError "At most one argument can be provided."
    2

[<EntryPoint>]
let main args =
    match args |> Array.toList with
    | [ newMode ] -> setMode newMode
    | [] -> getCurrentMode ()
    | _ -> tooManyArguments ()
