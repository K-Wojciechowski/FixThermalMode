/*
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
 */

namespace FixThermalMode.Constants;

public static class Modes {
  public const string Optimized = "optimized";
  public const string Cool = "cool";
  public const string Quiet = "quiet";
  public const string Performance = "performance";
  public const string Error = "error";
  public const string UnknownMode = "unknown mode";

  public static readonly string[] AllModes = new[] { Optimized, Cool, Quiet, Performance };
}
