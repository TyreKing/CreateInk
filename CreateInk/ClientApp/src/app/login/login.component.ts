import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private httpClient: HttpClient
  ) { }

  loginForm = this.formBuilder.group({
    username: '',
    password: ''
  });
  SERVER_URL = "https://localhost:44369/artist/authenticate";
  user: [
    '',
    ''
  ];


  ngOnInit(): void {
  }

  onSubmit() {
    let body = JSON.stringify(this.loginForm.value);
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    this.httpClient.post<any>(this.SERVER_URL, body, { headers: headers }).subscribe(data => {
      this.user = data;

    });
  }

}

