# SysInfo
Displays information about your system.

Compile using Microsoft Visual Studio 2019. Older versions not guaranteed to work. Needs .NET Framework 4 Client Profile to work.

## Compile without contributing
Download the source files. (DON'T DOWNLOAD THE SOURCE FILES FROM THE RELEASES SECTION!) To compile, choose `Release | AnyCPU`, go to the Build tab, press Build Solution, and you're done. Go to SysInfo\bin\Release to see the actual program.

## Contribute to project
Download and install git [here](https://git-scm.com/downloads).

### Fork the repo
Click the `Fork` button in the top-right corner of the screen. This will create a repo in your account.

### Clone the repo
Click the `Clone` button in the top-right corner of the screen.

Now clone the forked repository to your machine. Go to your GitHub account, open the forked repository, click on the `Code` button and then click the ![alt text](https://i.ibb.co/NTwxwVp/githubcopy.png "Copy to Clipboard") icon.

Open up git Bash and type in the following:

`git clone url you copied`  where "url you copied" is the URL of your forked GitHub repo.

For example:

`git clone https://github.com/username/SysInfo.git "destination path"`

where `username` is your GitHub username and "destination path" is the path where you want the cloned repo to be placed on your computer. Here you're copying the contents of the first-contributions repository on GitHub to your computer.

### Create a branch

Open git Bash. Type in the following:

`cd "the-path-where-you-placed-the-cloned-repo"`

`git checkout -b branch-name`

Don't close git yet!

### Make changes and commit them

Now, you can fix the code from here (if there's something wrong). **MAKE SURE TO EMPTY THE bin AND obj FOLDERS!**

Don't forget to put your name in the CONTRIBUTORS.md file!

After you're done fixing the code and testing it (and emptying the bin and obj folders), type this into git Bash:

`git add -A`

And commit the changes:

`git commit -m "your message"`

replacing `your message` with anything e.g. `git commit -m "Changed some code bla bla bla"`

Don't close git yet!

### Push the changes to GitHub

After that, you need to push the changes to GitHub to ACTUALLY show the changes. Type this:

`git push -u origin your-branch-name`

Replace `your-branch-name` with your branch name.

### Submit your changes for me to review

If you go to your repository on GitHub, you'll see a `Compare & pull request` button. Click on that button.

Submit the pull request.

Soon, if the changes passed, I'll be merging all your changes into the master branch of this project. You will get a notification email once thechanges have been merged.

#### Language: VB.NET

## Description

This is a simple application that displays information (Windows version, build, CPU, etc.) about your system.
Works on Vista, 7, 8, 8.1, and Windows 10. XP not yet tested.

# Changelog

## SysInfo version 1.0.0.0b now released!

Yeah, it was a quick transition from alpha to beta...

OK, here are the changes:

+added the ability to export the information as a .snfo file

+added tooltips

+enabled XP Visual Styles

+added Windows home path and drive type (HDD, SSD, etc.)

+replaced checkbox with radio buttons to switch between basic and advanced system information

+updated the About section

-SysInfo now always runs as administrator due to adding the drive type as it will give an unhandled exception (access denied error) if not run as admin. 

If you have discovered bugs, please post in Issues.

‎

Copyright © OpenCode 2020

Made by Kian Gabriel Arambulo

<sup>Last updated: December 20, 2020</sup>

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=kiangabrielarambulo%40gmail.com&currency_code=PHP)

[![License: CC BY-NC-SA 4.0](https://licensebuttons.net/l/by-nc-sa/4.0/80x15.png)](https://creativecommons.org/licenses/by-nc-sa/4.0/)