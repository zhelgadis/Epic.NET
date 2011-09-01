---
layout: post
title: GIT workflow
---
Epic is very complex. We need talented programmers with real world
experience and high technical skills to complete the journey.

However we need a long term strategy to keep the project's management fluent and to avoid unnecessary waste of time.

Thus, if you like to contribute to Epic here you can find some advice on how to
set up your environment rapidly.

Meet us!
--------
To meet new contributors we created a [mailing list][1] quite early.

Since we have previous experience in framework development, we know that keeping
track of the path that lead to a decision is often more important that the 
decision itself. As a consequence, if you join us, you have to partecipate to our brainstorms and decisions via the mailing list itself.

The mailing list keeps an informal tone, but you have to know the 
[netiquette][2] and to be respectful about the other contributors' opinions.

Fork the code base
------------------
First of all, you need a [Github][3] account. If you are new to git, please
take a look to the [Pro Git book][4] and follow the github's help on [forks][5]
and in [collaborative development models][6] (we adopt the Fork + Pull model).

As for version control we adopt this general rules:

* **Follow the devel branch.** The **master** branch is for 
  public milestones only; code flows from devel to master when we all agree 
  about it's stability.
* **Don’t develop on the devel branch.** Always create a branch 
  specific to the activity you’re working on. 
  If you are fixing a bug, name the branch by issue # and description. 
  For example, if you’re working on Issue #123, a documentation enhancement, 
  your development branch should be called 123-documentation-enhancement. 
  If you decide to work on another issue mid-stream, create a new branch for 
  that issue, don’t work on both in one branch.
* **A single development branch should represent changes related to a single 
  issue.** If you decide to work on another issue, create another branch.
* **Send pull requests from the branch to devel.** Your request will be 
  commented, discussed and will hopefully merged in the codebase.
* **Update your devel branch as needed.** Once your request has been accepted
  you can update the devel branch.
  
### Step-by-step ###

1. Fork on GitHub (click Fork button)
2. Clone to computer (`$ git clone git@github.com:you/Epic.NET.git`)
3. Don’t forget to cd into your repo: (`$ cd Epic.NET/`)
4. Set up remote upstream (`$ git remote add upstream git://github.com/Shamar/Epic.NET.git`)
5. Create a branch for the activity (`$ git checkout -b 123-class-rename`, if you don’t have a bug report no worries just skip the number)
6. Develop on your brandnew branch. _[Time passes, the main Epic.NET repository accumulates new commits]_
7. Commit changes to issue branch. (`$ git add . ; git commit -m 'commit message'`)
8. Fetch upstream (`$ git fetch upstream`)
9. Update local devel (`$ git checkout devel; git pull upstream devel`)
10. Repeat steps 5-8 till development is complete
11. [rebase][7] issue branch (`$ git checkout 123-class-rename; git rebase devel`)
12. Push branch to GitHub (`$ git push origin 123-class-rename`)
13. Issue pull request (Click Pull Request button)

During rebase you may need to resolve conflicts that occur when a file on the 
development trunk and one of your files have both been changed. 
**Please, don't panic.**

Just before you pull
--------------------
We will require that you sign a Contributor Agreement (still under definition). 
Indeed, we are planning to develop a sustainable (yet [ethic][9]) business model 
based on [selling exceptions][10] for **specific** applications. 
In this way, we hope to keep the project both free and alive.

Soon I'll write about the reasons that made me release Epic under the 
[GNU Affero General Public License][8], has I realized recently that such decision 
has some point of interess.

BTW, you will retain ownership of the copyright and patent claims in your 
contributions and have the same rights to use or license the contributions 
which you would have had without entering into the agreement (except for assigning exclusive licenses).

You only need to sign the contributor license agreement once; it applies to 
all stuff that you send us. However, if you will not sign the agreement, we 
will not be able to accept any contribute of yours.



[1]: https://groups.google.com/group/epic-net/ "Epic's mailing list"
[2]: http://tools.ietf.org/html/rfc1855 "Netiquette Guidelines"
[3]: https://github.com/
[4]: http://progit.org/book/
[5]: http://help.github.com/fork-a-repo/
[6]: http://help.github.com/send-pull-requests/
[7]: http://progit.org/book/ch3-6.html
[8]: http://epic.tesio.it/license.html
[9]: http://www.vatican.va/holy_father/benedict_xvi/speeches/2011/august/documents/hf_ben-xvi_spe_20110818_intervista-madrid_en.html "Ethics should guide economics"
[10]: http://www.fsf.org/blogs/rms/assigning-copyright "Stallman on linking exceptions."
