[Back to README](../README.md)

## Frontend
Frontend is built with angular and uses Bootstrap mixed with MaterialUi to show screens.

- To run the frontend, you must use npm start.

## Security
- When logging in, the token is registered in the browser's local storage.

- In each API request, it will add the authentication token to the request header using an interceptor, the *TokenInterceptor*.
When making a request, if an unforeseen error occurs (any error other than status code 200), the error handling interceptor *ErrorInterceptor* displays a message on the screen.

- To protect the component's routes so that they are only displayed if the user is authenticated, the *AuthGuard* guard comes into action. It must be declared for use in each route in the routing file.

- To protect the component's routes by user profile, the *RoleGuard* guard comes into action. It is possible to select which profiles will have permission to the routes.

# Webapp

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 19.2.9.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Karma](https://karma-runner.github.io) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.