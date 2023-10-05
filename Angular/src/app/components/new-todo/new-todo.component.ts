import { Component, OnInit, Output, EventEmitter  } from '@angular/core';
import { FormGroup, FormControl , Validators, FormBuilder} from '@angular/forms';
import { Todo } from 'src/app/models/todo.model';
import { TodoService } from 'src/app/services/todo.service';
@Component({
  selector: 'app-new-todo',
  templateUrl: './new-todo.component.html',
  styleUrls: ['./new-todo.component.css']
})
export class NewTodoComponent implements OnInit{
  
  newTodo:Todo ={
    id:0,
    title:"",
    description:"",
    done:false
  };
  todoForm: FormGroup = new FormGroup({});

  @Output() newTodoEvent = new EventEmitter<Todo>();

  constructor(private todoService: TodoService){}
  
  ngOnInit(): void {
    this.todoForm = new FormGroup({
      title: new FormControl(this.newTodo.title, Validators.required),
      description: new FormControl(this.newTodo.description),
    });
  }

get title() { return this.todoForm.get('title'); }

get description() { return this.todoForm.get('description'); }

  

  onSubmit() {
    this.newTodo.title = this.todoForm.value.title;
    this.newTodo.description = this.todoForm.value.description;
    this.todoService.addTodo(this.newTodo).subscribe({
      next:(data)=>{
        this.newTodoEvent.emit(this.newTodo);
      }
    });
  }
}
