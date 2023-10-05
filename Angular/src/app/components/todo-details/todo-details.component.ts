import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Todo } from 'src/app/models/todo.model';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-todo-details',
  templateUrl: './todo-details.component.html',
  styleUrls: ['./todo-details.component.css']
})
export class TodoDetailsComponent implements OnInit
{

  todoForm!: FormGroup;
  todo:Todo ={
    id:0,
    title:"",
    description:"",
    done:false
  };

  id: number=1;
  constructor(private formBuilder: FormBuilder,private route: ActivatedRoute, private todoService:TodoService,private router: Router) {}

  ngOnInit() {
    this.todoForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['']
    });

    this.route.params.subscribe(params => {
      this.id = +params['id']; 
      this.todoService.getTodo(this.id)
      .subscribe({
        next:(data)=>{
          this.todo=data;
          this.todoForm.patchValue(this.todo);
        },
        error : (err)=>{ this.router.navigate(['/']); }
      });
    });
    
  }

  get title() { return this.todoForm.get('title'); }
  
  onSubmit() {
    debugger;
    this.todo.title = this.todoForm.value.title;
    this.todo.description = this.todoForm.value.description;
    this.todoService.updateTodo(this.todo.id,this.todo).subscribe({
      next:(data)=>{
          this.todo=data;
      }
    });
  }

  deleteTodo(id: number) {
    this.todoService.deleteTodo(this.todo.id).subscribe({
      next:(data)=>{
        this.router.navigate(['/'])
      }
    });
    
    }
}
