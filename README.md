# SPELL CHECKER 2000

MSA Module Two - Andrew Lai

## Main Functionality

App has two tabs on its main page: Spell Check Page and History Page.

The spell check page contains an editor input for the user to input a piece of text that is to be spell checked with a push of a button "CHECK NOW". Once pressed it will display the words detected to be incorrect (whether it be a grammatical or spelling error) and suggests the closest probability replacement for the block of the input text. Once this is done, it records the suggestions in the history database to be displayed later down the line.

The history page contains a list of the words of incorrect and suggestions that have been recommended in the past spell checks, stored in the history database. The history page also allows the user to clear the history with a "CLEAR HISTORY" button, but without a warning prompt first.

## API Used

Main Microsoft Cognitive Service used for this app is the Bing Spell Checker API.

The database service containing the history is provided by Azure Easy Tables service.

