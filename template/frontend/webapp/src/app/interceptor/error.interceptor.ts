import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({ providedIn: 'root' })
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private snackBar: MatSnackBar) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        
        let errorMessage = 'An unknown error occurred.';
        if (error.error instanceof ErrorEvent) {
          // Client-side error
          errorMessage = `Client-side error: ${error.error.message}`;
        } else {
          // Server-side error
          errorMessage = `Server error: ${error.status} - ${error.message}`;
        }
        console.error('API error occurred:', error);

        this.snackBar.open(error.message, 'Dismiss', {
          duration: 5000, // snack bar time to dismiss 5 seconds
          verticalPosition: 'top'
        });

        return throwError(() => new Error(errorMessage));
      })
    );
  }
}
