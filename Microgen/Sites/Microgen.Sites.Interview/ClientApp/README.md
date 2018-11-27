# ClientApp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.0.8.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).



Scenario Outline: Register with valid details
    Given I am on the registration page
        And I have completed the form with <email> <organisation> <password> and <passwordConfirmation>
    When I have clicked on the register button
    Then I will be logged in as <username>
        And my account will be assigned the role of <role>

        Examples: 
        | email     | organisation | password  | passwordConfirmation | username  | role  |
        | usernamea | Bytes        | password1 | password1            | usernamea | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernamec | Bytes        | password3 | password3            | usernamec | Admin |
        | usernamed | Bytes        | password4 | password4            | usernamed | Admin |
        | usernamee | Bytes        | password5 | password5            | usernamee | Admin |

Scenario Outline: Register with invalid details
    Given I am on the registration page
        And I have completed the form with <email> <organisation> <password> and <passwordConfirmation>
    When I have clicked on the register button
    Then I will get an error message

        Examples: 
        | email             | organisation    | password   | passwordConfirmation | 
        | Jonesa@mojito.com | Bytes           | 1LTIuta&Sc | wrongpassword      | 
        | Jonesb@mojito.com | Bytes           | 1LTIuta&Sc | 1LTIuta&Sc         | 
        | Jonesc@mojito.com | No Organisation | 1LTIuta&Sc | 1LTIuta&Sc         | 
