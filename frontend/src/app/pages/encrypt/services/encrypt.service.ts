import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { EncryptBody } from './interfaces';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EncryptService {
  private URL = 'exercise';

  public constructor(private readonly httpClient: HttpClient) {}

  public encrypt(body: EncryptBody): Observable<string> {
    const options: Object = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      responseType: 'text',
    };

    return this.httpClient.post<string>(
      `${environment.API_URL}/${this.URL}/encrypt`,
      body,
      options
    );
  }
}
