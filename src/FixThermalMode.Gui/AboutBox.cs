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

namespace FixThermalMode.Gui;
public partial class AboutBox : Form {
  public AboutBox() {
    InitializeComponent();
    var version = typeof(AboutBox).Assembly.GetName().Version?.ToString() ?? "0.0.0.0";
    headingLabel.Text = $"Fix Thermal Mode v{version}";
  }

  private void okButton_Click(object sender, EventArgs e)
    => Close();
}
