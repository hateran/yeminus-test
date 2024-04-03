import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { FibonacciBody } from './interfaces';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FibonacciService {
  private URL = 'exercise';

  public constructor(private readonly httpClient: HttpClient) {}

  public validate(body: FibonacciBody): Observable<boolean> {
    const options: Object = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      responseType: 'text',
    };

    return this.httpClient.post<boolean>(
      `${environment.API_URL}/${this.URL}/validate-fibonacci`,
      body,
    //   options
    );
  }
}
