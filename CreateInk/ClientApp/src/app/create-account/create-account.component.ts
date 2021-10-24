import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private httpClient: HttpClient
  ) { }

  createAccountForm = this.formBuilder.group({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    username: '',
    confirmEmail:'',
    confirmPassword: '',
    birthDate: ''
  });

  userId: '';

  SERVER_URL = "https://localhost:44369/artist/create";

  ngOnInit(): void {
  }

  

  onSubmit(){
    let body = JSON.stringify(this.createAccountForm.value);
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
  }); 

    this.httpClient.post<any>(this.SERVER_URL, body, {headers: headers}).subscribe(data => {
      this.userId = data.id;
  })
  }
}
