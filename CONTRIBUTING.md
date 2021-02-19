# Contributing to Blamantic-UI

### :pill: Bugs and Enhancements
We use [Github Issues](https://github.com/AchievedOwner/BlamanticUI/issues) o track all bugs and enhancements, before raising a bug please check to see if it has already been raised. If you find it has already been raised add a :thumbsup: to the issue reactions to show you are also having the same issue. Please do not spam "+1", "bump" etc.

If you find that your issue has not already been raised please create a [new issue](https://github.com/AchievedOwner/BlamanticUI/issues/new).

### :bulb: Requesting Features
We also use [GitHub Issues](https://github.com/AchievedOwner/BlamanticUI/issues) for new feature requests. Before submitting a new issue please check to see if it has already been requested. If you find that your issue has not already been requested feel free create a [new issue](https://github.com/AchievedOwner/BlamanticUI/issues/new).

### :red_circle: Pull Requests Guide
> [master] is always current development branch, all pull request should be merged into this branch. We create the '*release/version*' branch after released from master, and all bugs for this release should be merged into the released branch and master branch.

Anyone can jump on the issues board and grab off bugs to fix. This is probably the best way to become a contributor to Blamantic. We only ask you to stick to these few rules to make it easier to merge/process your pull requests.

- When you implement a new feature or fix a bug think about backwards compatibility. If your change is backwards compatible it is most likely to be merged sooner since you won't need to wait for a breaking change update.
- Comments in code is necessary and must follow the [specification of C# code from Microsoft](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/language-specification/introduction).
- Please remember to synchronously modify the demo  after you modifying the component.

### :white_check_mark: Setup your enviroment
These few steps are the easiest way to setup your dev environment.

1. Fork the [main repository](https://github.com/AchievedOwner/BlamanticUI.git).
2. Clone your fork and add the main repository as a remote
```bash
$ git clone https://github.com/AchievedOwner/BlamanticUI.git
$ cd BlamanticUI-UI
$ git remote add origin https://github.com/AchievedOwner/BlamanticUI.git
$ git fetch origin
```
3. if necessary, Checkout a new branch with the BlamanticUI `master` branch as the base 
```bash
$ git checkout -b <BRANCH_NAME> origin/master
```