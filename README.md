# Limbo Slack Bot
Limbo is a small CLI utility that allows querying for GitHub issues/pull-requests, and sending notifications via Slack. The motivation stemmed from a dev team with members working simultanously on several clients/projects; the average time for pull-requests to be closed was growing. Limbo was developed as an exploration of .NET Core, and to help give team members automatic reminders on open pull requests, across organizations, projects, and members.


## Authentication
Limbo currently works with a GitHub username and personal access token. The personal access token should have the "Repo" scope. Unfortunately, there is not any other more fine-grained controls. However, Limbo is very transparent in commands sent on your behalf, so feel free to audit how you token is used.

The second needed credentials are for your Slackbot integration. Since Limbo is meant to be a "self-hosted/on-prem" solution, Slack also utilized a simple custom integration Bot token.


## Runtime
.NET Core 1.1


## Configuration
All configuration is done via the "limbo.json" file. An example settings file "limbo.example.json" is provided. At this time, the settings file is expected with the name "limbo.json" in the current working directory.


## Roadmap
- Allow for embedded web server, opening the possibility to respond to Slack messages. Possible applications include:
  + Responding to requests to see open pull requests (rather than waiting on timer)
  + Allowing changing settings via messaging (ie: add user to whitelist, modify messages, etc...)
  + Allow users to automagically request a review from Slack (via message buttons?) [Maybe...]

- Setup continious integration which creates cross-platform binary releases

- Add unit tests

- Create docker image for easier deployment

- Add command to easily setup schedule tasks/cronjobs

- Smarter messages, based on length pull request has been open, etc...