# Passwordle

## Introduction
**Passwordle** is an unwinnable game where you try to guess the password

# Video Walkthrough
Here's a walkthrough of the implemented features:

<img src='https://raw.githubusercontent.com/edithngundi/Passwordle/main/passwordle.gif' title='Video Walkthrough' width='1000' height='500' alt='Video Walkthrough' />

GIF created with [Kap](https://getkap.co/) for macOS

## How to Play
- You have 5 attempts to guess the correct password.
- The password can include any number, letter (uppercase or lowercase), or special character.
- Enter your guess and submit it to receive feedback for each character.

## Feedback System
After each guess, each character in your attempt will change color to indicate how close you are to the correct password:
- **Green**: The character is correct and in the proper position.
- **Orange**: The character is correct but in the wrong case (uppercase/lowercase).
- **Yellow**: The character is within 10 steps of the correct character in the ASCII sequence.
- **Red**: The character is more than 10 steps away from the correct character in the ASCII sequence.

## Rules
- The character set includes numbers (0-9), letters (A-Z, a-z), and 32 special characters.
- The indexing of characters for feedback purposes is as follows: Numbers are indexed 1-10, letters are indexed 11-36 (for each case), and special characters follow thereafter.

## Getting Started
[EASIER OPTION] You can find the came on Itch.io at https://edithngundi.itch.io/passwordle and its accessible on any browser

[HARDER OPTION] Feel free to also clone this repository and running the game in Unity. To do this ensure you have Unity Hub and Unity Editor installed on your device. This repository is missing some library packages (files were too large to upload on GitHub) so ensure you also install relevant packages

Thank you for playing the Passwordle, and good luck!