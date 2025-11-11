' FixThermalMode
' Copyright © 2024-2025 Krzysztof Wojciechowski
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <https://www.gnu.org/licenses/>.

Imports FixThermalMode.ClientCommon

Module Program
  Private Sub PrintError(message As String)
    Console.ForegroundColor = ConsoleColor.Red
    Console.WriteLine(message)
    Console.ResetColor()
  End Sub

  Private Function HandleApiResponse(apiResponse As ApiResponse)
    If Not apiResponse.Success Then
      PrintError(apiResponse.Message)
      Return 1
    End If

    Console.WriteLine(apiResponse.Message)
    Return 0
  End Function

  Private Async Function AsyncMain(args As String()) As Task(Of Integer)
    If (args.Length = 0) Then
      Return HandleApiResponse(Await ThermalModeApiClient.getAsync())
    ElseIf (args.Length = 1) Then
      Dim newMode = args(0)
      Return HandleApiResponse(Await ThermalModeApiClient.setAsync(newMode))
    End If
    PrintError("At most one argument can be provided.")
    Return 2
  End Function

  Function Main(args As String()) As Integer
    Return AsyncMain(args).Result
  End Function
End Module
