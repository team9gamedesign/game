# game

### **git** instructions

We will be using the **git flow** workflow design. It helps us maintain our repository with a smaller amount of merge conflicts, in a more structured fashion, and in such a way that the code *hopefully* is better written. It works in the following way:

1. Code is never pushed to the `master` branch. The `master` branch is only used for releases or finished milestones. Code created in between these milestones are instead handled in a branch called `develop`. Once `develop` contains version that corresponds to a finished milestone or release, a pull request is made from `develop` into `master`.
2. The `develop` branch is where the application in its intermediary stages resides. However, this branch does not either receive any directly pushed commits. This is because if all of us were to push to the same branch when working on different features, many merge conflicts would occur. Instead, feature branches are used.
3. For every single task in the repository, a separate branch should be created. This branch should only exist for that feature, and once it is done, a pull request of it is made into `develop`. By doing this, each feature is structured into a branch, making it easy to see what commits are related to what part of the application.

Features in this repository will be handled by the Projects tab in the repository. In this tab, several projects will be active which contain tasks to be completed. All code related tasks will be assigned to issues in the repository, making them easily referencable in commit messages using the `#<issue_number>` syntax.

When working on a new feature in the repository, the following work flow is likely:

1. Make sure you're starting from `develop` by writing `git checkout develop`.
2. Create a new branch for the feature you're implementing. A good naming convention for the branches is `<issue_number>-<issue_name>`. Branches are created by writing `git checkout -b <branch_name>`. This will also move you to that branch.
3. Do your work and commit them to the branch. To push things to the remote repository, you have to write `git push --set-upstream origin <branch_name>` once. Then you can push by simply writing `git push`. When committing things related to any issues, reference them in the commit messages.
4. Once the feature is fully implemented and the branch is complete, create a pull request into `develop`. Furthermore, assign someone else to review your code. 
5. The person reviewing your code might notice some errors or poorly written code. You can commit new changes to the branch and the pull request will be automatically updated. When the reviewer finally is happy, that person can merge the contents into `develop`.

A general guideline is to merge `develop` into your feature branch whenever you come back to it. This will minimize the amount of merge conflicts when doing the pull request into `develop`. To do this, stand in your feature branch and write `git merge develop`. This might cause some merge conflicts, but they are most likely more easily fixable.
