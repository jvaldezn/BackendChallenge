import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:49154/api';

  login(formData) {
    return this.http.post(this.BaseURI + '/Currencies/Login', formData);
  }

  getCurrency(formData) {
    return this.http.get(this.BaseURI + `/Currencies/Get/${formData.Amount}/${formData.CurrencyFrom}/${formData.CurrencyTo}`);
  }
}
