import { Component, OnInit } from '@angular/core';
import { Todo } from 'src/app/models/todo.model';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css']
})
export class TodosComponent implements OnInit {

  todo:Todo ={
    id:0,
    title:"",
    description:"",
    done:false
  };
  todos: Todo[]=[];

  constructor(private todoService : TodoService){}

  ngOnInit(): void {
    this.getTodos();
  }

  getTodos()
  {
    this.todoService.getTodos()
    .subscribe({
      next:(data)=>{
        this.todos=data;
        //reorder todos
        const doneTodos = this.todos.filter(todo => todo.done);
        const undoneTodos = this.todos.filter(todo => !todo.done);
        this.todos = [...undoneTodos, ...doneTodos];
      }
    });
  }

  onDoneChanged(todo: Todo) {
    todo.done = !todo.done;
    this.todoService.updateTodo(todo.id,todo).subscribe({
      next:(data)=>{
        this.getTodos();
      }
    });
  }
}
