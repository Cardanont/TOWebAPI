import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'True Omni quick assessment test';
  companies: any;

  constructor(private http: HttpClient) {}


  ngOnInit(): void {
    this.getCompanies();
  }

  getCompanies() {
    this.http.get('https://localhost:7190/api/companies').subscribe(response => {
      this.companies = response;
    }, error =>{
      console.log(error);
    });
  }
}

