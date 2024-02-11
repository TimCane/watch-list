import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, Optional } from '@angular/core';
import {
  API_BASE_URL,
  GeneratedApiClientService,
} from './generated-api-client.service';

@Injectable({
  providedIn: 'root',
})
export class ApiClientService extends GeneratedApiClientService {
  constructor(
    @Inject(HttpClient) http: HttpClient,
    @Optional() @Inject(API_BASE_URL) baseUrl?: string
  ) {
    super(http, baseUrl);

    this.jsonParseReviver = (key: string, value: any) => {
      return this.customJsonParseReviver(key, value);
    };
  }

  customJsonParseReviver(key: string, value: any): any {
    if (value) {
      if (typeof value === 'string') {
        if (/^^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.\d+)?$/g.exec(value)) {
          return new Date(value);
        }
      }
    }

    return value;
  }
}
