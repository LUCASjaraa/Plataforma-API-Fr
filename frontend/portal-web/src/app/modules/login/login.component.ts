import { Component, OnInit, ElementRef, OnDestroy } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { AuthService } from '../../shared/services/auth.service'



export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  loginForm: FormGroup;
  submitted = false;

  validEmailLogin: boolean = false;
  validPasswordLogin: boolean = false;

  matcher = new MyErrorStateMatcher();


  constructor(private formBuilder: FormBuilder,
             private authService: AuthService){
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]],
      password: ['', Validators.required]
    });
  }

  isFieldValid(form: FormGroup, field: string) {
    return true //!form.get(field).valid && form.get(field).touched;
  }

  displayFieldCss(form: FormGroup, field: string) {
    return {
      'has-error': this.isFieldValid(form, field),
      'has-feedback': this.isFieldValid(form, field)
    };
  }

  ngOnInit() {

  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    console.log("onSubmit login", this.loginForm.value);
    let userinfo = {
        "Username": "string",
        "Password": "string"
    };
    this.authService.login(userinfo).subscribe(response => {
        if (response.success) {
            console.log('response.success', response);
        }

    }, error => {
        if (error) {
        }
    }
    );

    if (this.loginForm.invalid) {
      return;
    }
  }

  emailValidationLogin(e:any){
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (re.test(String(e).toLowerCase())) {
        this.validEmailLogin= true;
    } else {
      this.validEmailLogin = false;
    }
  }

  passwordValidationLogin(e:any){
    if (e.length > 5) {
        this.validPasswordLogin = true;
    }else{
      this.validPasswordLogin = false;
    }
  }



}
