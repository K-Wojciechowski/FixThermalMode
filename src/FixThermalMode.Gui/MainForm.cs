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

using System.Media;
using FixThermalMode.ClientCommon;
using FixThermalMode.Constants;
using FixThermalMode.Gui.Properties;

namespace FixThermalMode.Gui;

public partial class MainForm : Form {
  private ToolStripMenuItem[] ModeMenuItems => new[] { performanceMenuItem, optimizedMenuItem, quietMenuItem, coolMenuItem };

  private bool _ignoreClose = true;

  private string _currentMode = "";

  private const string ModeCaptionFormat = "Fix Thermal Mode ({0})";

  private const string UnknownModeCaption = "Fix Thermal Mode";

  public MainForm() {
    InitializeComponent();
    WindowState = FormWindowState.Minimized;
    ShowInTaskbar = false;
  }

  private async void MainForm_Load(object sender, EventArgs e) {
    try {
      var apiResponse = await ThermalModeApiClient.getAsync();

      if (apiResponse.Success) {
        UpdateUiWithNewMode(apiResponse.Message);
      }
    } catch {
      // Ignore exceptions here, the user will be notified later
    }
  }

  private void UpdateUiWithNewMode(string newMode) {
    _currentMode = newMode.ToLowerInvariant();

    var menuItemToCheck = _currentMode switch {
      Modes.Optimized => optimizedMenuItem,
      Modes.Cool => coolMenuItem,
      Modes.Quiet => quietMenuItem,
      Modes.Performance => performanceMenuItem,
      _ => null
    };

    var icon = _currentMode switch {
      Modes.Optimized => Resources.optimized,
      Modes.Cool => Resources.cool,
      Modes.Quiet => Resources.quiet,
      Modes.Performance => Resources.performance,
      _ => Resources.app
    };

    var captionModeName = _currentMode switch {
      Modes.Optimized => "Optimized",
      Modes.Cool => "Cool",
      Modes.Quiet => "Quiet",
      Modes.Performance => "Performance",
      _ => null
    };

    var caption =
      captionModeName == null
      ? UnknownModeCaption
      : string.Format(ModeCaptionFormat, captionModeName);

    foreach (var modeMenuItem in ModeMenuItems) {
      modeMenuItem.Checked = modeMenuItem == menuItemToCheck;
    }

    notifyIcon.Icon = icon;
    notifyIcon.Text = caption;
  }

  private async Task SetModeInternal(string newMode) {
    try {
      var apiResponse = await ThermalModeApiClient.setAsync(newMode);

      if (apiResponse.Success) {
        UpdateUiWithNewMode(newMode);
      } else {
        MessageBox.Show(apiResponse.Message, "Failed to change thermal mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    } catch (Exception exc) {
      MessageBox.Show(exc.ToString(), "Failed to change thermal mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private async Task SetMode(string newMode) => await SetModeInternal(newMode);

  private async void performanceMenuItem_Click(object sender, EventArgs e) => await SetMode(Modes.Performance);

  private async void optimizedMenuItem_Click(object sender, EventArgs e) => await SetMode(Modes.Optimized);

  private async void quietMenuItem_Click(object sender, EventArgs e) => await SetMode(Modes.Quiet);

  private async void coolMenuItem_Click(object sender, EventArgs e) => await SetMode(Modes.Cool);

  private async void autoFixMenuItem_Click(object sender, EventArgs e) {
    progressBar.Value = 0;
    Opacity = 1;
    WindowState = FormWindowState.Normal;

    var modeToRestore = _currentMode;
    var intermediaryMode = modeToRestore == Modes.Performance ? Modes.Optimized : Modes.Performance;
    await SetModeInternal(intermediaryMode);
    progressBar.Value += 1;

    for (int i = progressBar.Value + 1; i < progressBar.Maximum; i++) {
      await Task.Delay(2);
      progressBar.Value = i;
    }

    await SetModeInternal(modeToRestore);
    progressBar.Value = progressBar.Maximum;
    await Task.Delay(500);

    WindowState = FormWindowState.Minimized;
    Opacity = 0;
  }

  private void aboutMenuItem_Click(object sender, EventArgs e) {
    var aboutBox = new AboutBox();
    aboutBox.ShowDialog();
  }

  private void quitMenuItem_Click(object sender, EventArgs e) {
    Application.Exit();
  }

  private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
    if (_ignoreClose && e.CloseReason == CloseReason.UserClosing) {
      SystemSounds.Beep.Play();
      _ignoreClose = false;
      e.Cancel = true;
    }
  }

  private void notifyIcon_Click(object sender, EventArgs e) {
    notifyIconMenu.Show(this, Control.MousePosition);
  }
}
