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

  updateTodo(id:number,updatedTodo: Todo):Observable<Todo>
  {
    return this.http.put<Todo>(this.todoUrl+id,updatedTodo);
  }

  deleteTodo(id:number):Observable<Todo>
  {
    return this.http.delete<Todo>(this.todoUrl+id);
  }
  addTodo(newTodo: Todo):Observable<Todo>
  {
    return this.http.post<Todo>(this.todoUrl,newTodo);
  }
  
}
