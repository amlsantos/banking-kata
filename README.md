![build](https://github.com/amlsantos/banking-kata/actions/workflows/build.yml/badge.svg)
![test](https://github.com/amlsantos/banking-kata/actions/workflows/test.yml/badge.svg)

# Banking Kata

## Overview

This sample repo presents my implementation of a basic banking system, using TDD and the specifications outlined in the [Banking Kata](https://kata-log.rocks/banking-kata) exercise.

## The task

The task involves creating a simple banking system that supports the following features:

1. **Account Balance:** Users should be able to inquire about their account balance.
2. **Deposit Funds:** Users should be able to deposit funds into their account.
3. **Withdraw Funds:** Users should be able to withdraw funds from their account.

Additionally, there are some edge cases and business rules to consider:

- Users should not be able to withdraw more funds than are available in their account.
- Each transaction should have a timestamp associated with it.
- Users should be able to view their transaction history.

## Technologies

- .net8
- c#12
- xunit 2.4
- FluentAssertions 7

## Your Task (Example Statement)

The following is an example statement to illustrate how the system should behave:

```plaintext
Given a user has an account with an initial balance of $0.00
When they deposit $500.00
And then withdraw $100.00
And inquire about their balance
Then they should see the following transactions and balance:

- Deposit +$500.00 (timestamp)
- Withdraw -$100.00 (timestamp)

Current Balance: $400.00

Date        Amount  Balance
24.12.2015   +500      500
23.8.2016    -100      400
```
## Built with SOLID Principles and Object Calisthenics

This project was built with adherence to the SOLID principles:

- **S - Single Responsibility Principle (SRP):** Each class should have a single responsibility.
- **O - Open/Closed Principle (OCP):** Software entities (classes, modules, functions, etc.) should be open for extension but closed for modification.
- **L - Liskov Substitution Principle (LSP):** Subtypes must be substitutable for their base types without altering the correctness of the program.
- **I - Interface Segregation Principle (ISP):** A class should not be forced to implement interfaces it does not use.
- **D - Dependency Inversion Principle (DIP):** High-level modules should not depend on low-level modules. Both should depend on abstractions.

The codebase also adheres to the rules of Object Calisthenics:

1. **Only One Level of Indentation per Method**
2. **Don't Use the ELSE Keyword**
3. **Wrap All Primitives and Strings**
4. **First-Class Collections**
5. **One Dot per Line**
6. **Don't Abbreviate**
7. **Keep All Entities Small**
8. **No Classes With More Than Two Instance Variables**
9. **No Getters/Setters/Properties**

These principles and rules ensure a robust and maintainable codebase.

## Getting Started

```bash
git clone https://github.com/amlsantos/banking-kata.git
dotnet restore
dotnet run --project .\src\UI\UI.csproj
```
## Running Tests
```bash
dotnet test
```
## Acknowledgments

- https://www.youtube.com/watch?v=eFwcCOK-XBY
- https://developerhandbook.stakater.com/content/architecture/object-calisthenics.html

Feel free to reach out if you have any questions or suggestions!
