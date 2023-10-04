import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../models/todo.model';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  todoUrl: string ="https://localhost:7231/api/Todo/";
  
  constructor(private http : HttpClient) { }

  getTodos() : Observable<Todo[]>
  {
    return this.http.get<Todo[]>(this.todoUrl);
  }
  getTodo(id:number) : Observable<Todo>
  { 
    return this.http.get<Todo>(this.todoUrl+id);
  }
}
