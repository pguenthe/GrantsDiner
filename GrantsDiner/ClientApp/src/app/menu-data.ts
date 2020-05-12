import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MenuItem } from './interfaces/menu';
import { Observable } from 'rxjs';

@Injectable()
export class MenuDataService {
  constructor(private http: HttpClient) { }

  getMenuItems(): Observable<MenuItem[]>  {
    return this.http.get<MenuItem[]>('/api/menu');
  }

  getCategories(): Observable<string[]> {
    return this.http.get<string[]>('/api/menu/categories');
  }

  getMenuItemsByCategory(cat:string):Observable<MenuItem[]> {
    return this.http.get<MenuItem[]>(`/api/menu/categories/${cat}`);
  }
}
