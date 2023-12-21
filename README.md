# Coding Assessment

This repository contains a coding assessment I completed. The goal of the coding assessment was to test my coding skills in .NET/C#. The focus is applied
on scalability and maintainability of code. For that reason, design patterns and architectural patterns are applied (MVC, Strategy Pattern, Factory Pattern, ... ).

This repo contains limited documentation on requirements and design choices, which can be found in FileReaderApp_documentation.pdf. 

The assignment itself can be found in the repo, but here is a brief overview of the requirements:

* the program itself can be a CLI application
* the program requires input from the user: the file extension, whether the file is encrypted or not and the privilige rights of the user (user or admin)
* the program will then handle reading the file, following files should be able to processed: .txt, .json , .xml. It will output the file contents
* the program should be able to read decrypted files. The decryption algorithm is defined as a base64 at this moment.
* the program should allow or reject the user from reading specific types of files based on its profile: e.g. user can read .txt files, an admin can read .txt, .json, .xml files
