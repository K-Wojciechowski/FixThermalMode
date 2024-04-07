# Fix Thermal Mode

A utility to quickly change the thermal mode on Dell laptops.

**Warning: this software is provided “AS-IS” and the authors DO NOT take responsibility for any hardware failure that may occur.**

## Downloads

[You can find a MSI installer in GitHub Releases.](https://github.com/K-Wojciechowski/FixThermalMode/releases)

## Thermal Modes?

The thermal management on Dell laptops can work in four modes: *Performance,
Optimized, Quiet, Cool*. Typically, those modes can be controlled by using an
application provided by Dell (like My Dell or Dell Power Manager).

Not all users are happy to stay on one mode at all times. When using the laptop
in one’s lap, the *Cool* mode may be more appropriate, but when the laptop is
on a desk, the *Optimized* mode will probably be a better choice (since *Cool*
has worse performance).

Also, the laptop may sometimes apply thermal throttling. While it’s best to
fix the cause of this issue, and avoid your computer catching fire, you
sometimes just can’t do any better.

## What does this do?

It adds an icon to the ~~system tray~~ notification area. Clicking on this icon
reveals a menu that lets you choose your preferred thermal mode. There’s also
an *Auto Fix* option, that temporarily changes the mode to *Performance* for 5
seconds and restores the previous mode (if *Performance* is already set, the
temporary mode is *Optimized*).

There is also a command-line version available. Both applications communicate
with a REST API that runs as a Windows service.

## F#? Visual Basic.NET?!

While the REST API and Windows Forms GUI are written in C#, there’s also some
F# and Visual Basic.NET code.

The CLI and the client library are written in F#, because I wanted to play with
the language and see how to get stuff done with it.

There is also an alternate CLI written in Visual Basic.NET, for no good reason
at all. But hey, this project is written in [all three .NET
languages](https://devblogs.microsoft.com/dotnet/update-to-the-dotnet-language-strategy/)!
(That list lacks C++/CLI and PowerShell, but they are not owned by the core .NET team).

## Dependencies

This project is built on top of [DellFanManagement by Aaron A.
Kelley](https://github.com/AaronKelley/DellFanManagement). That project uses
the GPL 3 license, so this project is under the GPL 3 license as well.

To run this, you need .NET 8 and both the ASP.NET Core and Windows Desktop runtimes.

100% of the code in this project was written without the aid of GitHub Copilot, ChatGPT, and other random noise generators.
