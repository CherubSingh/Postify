import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.models';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category.model';
import { environment } from 'src/environments/environment.development';
import { UpdateCategoryRequest } from '../models/Udate-Category-Request-model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  AddCategory(model: AddCategoryRequest) : Observable<void>
  {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/categories`, model);
  }
  GetAllCategories(): Observable<Category[]>
  {
    return this.http.get<Category[]>(`${environment.apiBaseUrl}/api/categories`);
  }
  GetCategoryById(id: string): Observable<Category>
  {
    return this.http.get<Category>(`${environment.apiBaseUrl}/api/categories/${id}`);
  }

  UpdateCategory(id: string, updateCategoryRequest: UpdateCategoryRequest): Observable<void>
  {
    return this.http.put<void>(`${environment.apiBaseUrl}/api/categories/${id}`, updateCategoryRequest);
  }
  
  DeleteCategory(id: string): Observable<Category>
  {
    return this.http.delete<Category>(`${environment.apiBaseUrl}/api/categories/${id}`);
  }
}
