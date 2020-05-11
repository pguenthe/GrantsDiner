import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MenuItem } from './interfaces/menu';

@Injectable()
export class MenuDataService {
  constructor(private http: HttpClient) { }

  getMenuItems() {
    return this.http.get<MenuItem[]>('/api/menu');
  }
}
