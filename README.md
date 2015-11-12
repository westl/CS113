# CS113
Our game will be an educational side-scrolling game where the objective is to collect resources to perform various science based tasks in order to progress through the levels.

# Meeting times
Tuesdays and Thursdays before class at 6:30, expect meetings to be 30 minutes to an hour. Essentially we will use this time to create issues in github and keep everyone on track. 

# Branches for development
We will keep the master branch clean by not pushing to it. Therefore i've created a branch for everyone to use
```
Alicia - art
Marissa - level
Melissa - menu
Kasean - programming-kasean
Lamar - programming-lamar
```

Instructions : 
 - Open the git bash
 - type  ```git fetch origin```  this should grab all the remote branches and create local copies onto your computer
 - type  ```git checkout < branchname >``` for example ```git checkout programming-lamar``` , this should put you on your branch
 - When you have made a change to a file and want to save it, type  ```git add .```, this will add all changed files to preparation, then type  ```git commit -m < message >``` , for example ```git commit -m "updating sprites"```, finally you'll want to type  ```git push origin < branchname >``` for example ```git push origin art``` . This will push all of your changes up to your designated branch and they can then be accessed by other members of the team. 
