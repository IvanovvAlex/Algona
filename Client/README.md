# Client

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 16.2.5.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.

<!-- Architecture Description-->

## Root Module

<!-- used to inject other modules, services, global routing and to bootstrap the app -->

! --- App module --- ! - app.component.html - app.component.css - app.component.ts - app.component.spec.ts

! --- App-routing module --- !

## Core Module

<!-- - to contain singleton services and components
needed only once in the application -->

## Shared Module

<!-- - to contain all common components,
directives and pipes used by a lot of places -->

    - Interfaces/types/enums - typization folder
    - material module
    - pipes
    - validators
    - interceptors

## Auth Module

<!-- To contain auth guards, auth components (Login, Regsiter) and their services -->

    - Guards
    - Login component
    - Register component
    - Auth Service -> Logout functionality

## Features Module

<!-- to contain Feature sub-modules with their components and their services -->

<!-- Desing and Typography information -->

## Coloration

Color codes: use codes from material - Primary: - Accent: - Warn:

## Language

Main language: English
