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

where `username` is your GitHub username and "destination path" is the path where you want the cloned repo to be placed on your computer. Here you're copying the contents of the SysInfo repository on GitHub to your computer.

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

Soon, if the changes passed, I'll be merging all your changes into the master branch of this project. You will get a notification email once the changes have been merged.
