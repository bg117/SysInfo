# Changelog

## SysInfo version 1.0.0.7b

VERY BIG UPDATE!!!!!!!!!

This version might have skipped a few versions, but it's OK. I have started from scratch since version 1.0.0.3b (which will never be released) and remade the whole thing in WPF and C#. I am so happy about how it turned out. This changed the overall look of the program from a simple, WinForms project to a complicated and beautiful work of art with the help of WPF and some other tools. 'Nuff said, here are the changes:

+redesigned the app from scratch

+used C# instead of VB.NET and WPF instead of Windows Forms

+added a resolution changer

+more interactive style

+Fluent "design"

+more of a Windows-ish style (Settings app)

+more features such as context menus, tooltips, and beautiful design

+added a menu for easy access to common controls

+added the System menu (right-click title bar thing)

+added animations

+added tabs

+added icons to common elements

-removed support for XP

We are investigating an issue with the Performance tab which causes the application to crash on virtual machines (and possibly real machines as well). Stay tuned for fixes.

If you have discovered bugs, please post in Issues.

## SysInfo version 1.0.0.2b (CHRISTMAS UPDATE)

MERRY CHRISTMAS YA FILTHY ANIMALS!

You might be thinking: "Why did it take 4 days to release this instead of the usual 1 day?"

Well the answer is this: I was adding new features AND waiting for Christmas! I have added new features such as:

+added support for Windows XP (x64 version and the normal one)

+added a new Performance* tab

+extended the title bar

+replaced radio buttons with checkbox (to make the form less cluttered)

+moved the Help and Export buttons to the title bar

+changed the title bar color to match Visual Studio's "Blue" theme

+replaced Close and Help icons to make it more Microsoft-y

+replaced Loading bar with Continuous style

-removed most of the PNG files and replaced it with ICO icons

<sup>* = Performance tab is still in early stages. Please report in Issues if you find any bugs.</sup>

## SysInfo version 1.0.0.1b is here

This is a pretty minor update. This update changes looks and functionality.

Changes:

+**Finally, custom title bars!**

+added a button to switch between XP Visual Styles and Classic

+replaced About and Save buttons for Windows 10 (Windows 8.1 and lower versions not affected)

+replaced PC icon for Windows 10 (Windows 8.1 and lower versions not affected)

If you have discovered bugs, please post in Issues.

## SysInfo version 1.0.0.0b now released!

Yeah, it's quite a quick transition from alpha to beta...

OK, here are the changes:

+added the ability to export the information as a .snfo file

+added tooltips

+enabled XP Visual Styles

+added Windows home path and drive type (HDD, SSD, etc.)

+replaced checkbox with radio buttons to switch between basic and advanced system information

+updated the About section

-SysInfo now always runs as administrator due to adding the drive type as it will give an unhandled exception (access denied error) if not run as admin. 

If you have discovered bugs, please post in Issues.

Copyright © OpenCode 2020

Made by Kian Gabriel Arambulo

<sup>Last updated: Febuary 2, 2021</sup>
