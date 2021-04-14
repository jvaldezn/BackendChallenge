import { ToastrService } from 'ngx-toastr';
import { UserService } from './../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
  formCurrency = {
    CurrencyFrom: '',
    CurrencyTo: '',
    Amount: ''
  }

  constructor(private router: Router, private service: UserService, private toastr: ToastrService) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/home');
  }

  onSubmit(form: NgForm) {
    this.service.getCurrency(form.value).subscribe(
      (res: any) => {
        console.log(res)
        this.toastr.success(`Amount Converted: ${res.amountConverted}`, 'Successfully!');
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Something wrong happen.', 'Error!');
        else
          console.log(err);
      }
    );
    //this.service.getCurrency(form.value);
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
}
